using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

namespace ExcelExtensions
{
    public static class CExcel
    {

        // Do the translation from number base 10 to alpha base 26: 1=A, 2=B, ..., 27=AA, 28=AB, ...
        private static string IntToLetters(int value)
        {
            if (value > 0)
            {
                value--;
                return IntToLetters(value / 26) + (char)('A' + value % 26);
            }
            return "";
            /*
             * Non-recursive version
             * 
                string result = string.Empty;
                while (--value >= 0)
                {
                    result = (char)('A' + value % 26) + result;
                    value /= 26;
                }
                return result;
            */
        }

        //
        public static bool CreateExcelFile(this RSFrame rs, string filePath, string sheetName="Sheet 1")
        {
            // Initialize vars
            int _row = 1;
            int _col = 1;

            // Create the excel file and get some objects from it
            SpreadsheetDocument _excelDoc = Create(filePath,sheetName);
            WorkbookPart _wbPart = _excelDoc.WorkbookPart;
            Sheet _sheet = _wbPart.Workbook.Descendants<Sheet>().Where(
                           (s) => s.Name == sheetName).FirstOrDefault();

            Worksheet _ws = ((WorksheetPart)(_wbPart.GetPartById(_sheet.Id))).Worksheet;

            //Worksheet _worksheet = ((WorksheetPart)(_wbPart.GetPartById(_sheet.Id))).Worksheet;

            // Meter row.Append aquí, y quitar los getRow y compañia.

            // Go over the recordset to fill the excel cells
            rs.ToList().ForEach(_rowdata =>
            {
                _rowdata.ItemArray.ToList().ForEach(_columndata =>
                {
                    AddCell(_ws,_wbPart, IntToLetters(_col) + _row.ToString(), _columndata.ToString(), 0, true);
                    _col++;
                });
                _row++;
                _col = 1;
            });


            //// Save and close the document
            _excelDoc.WorkbookPart.Workbook.Save();
            _excelDoc.Close();
            return true;
        }

        // Create an empty excel file
        public static SpreadsheetDocument Create(string filepath, string sheetName)
        {
            // Create a spreadsheet document by supplying the filepath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.
                Create(filepath, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = sheetName
            };
            sheets.Append(sheet);

            // Add the table part for the shared strings table
            var stringTablePart = workbookpart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = workbookpart.AddNewPart<SharedStringTablePart>();
            }
            stringTablePart.SharedStringTable = new SharedStringTable();

            return spreadsheetDocument;
        }

        // Add a new cell
        public static bool AddCell(Worksheet ws, WorkbookPart wbPart, string addressName, string value,UInt32Value styleIndex, bool isString)
        {
            SheetData _sheetData = ws.GetFirstChild<SheetData>();
            UInt32 _rowNumber = GetRowIndex(addressName);
            Row row = GetRow(_sheetData, _rowNumber);

            Cell _cell = new Cell();
            _cell.CellReference = addressName;
            row.InsertBefore(_cell, null);

            if (isString)
            {
                // Either retrieve the index of an existing string,
                // or insert the string into the shared string table
                // and get the index of the new item.
                int stringIndex = InsertSharedStringItem(wbPart, value);

                _cell.CellValue = new CellValue(stringIndex.ToString());
                _cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            }
            else
            {
                _cell.CellValue = new CellValue(value);
                _cell.DataType = new EnumValue<CellValues>(CellValues.Number);
            }

            return true;
        }




        // Return the row at the specified rowIndex located within
        // the sheet data passed in via wsData. If the row does not
        // exist, create it.
        private static Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }

        // Given an Excel address such as E5 or AB128, GetRowIndex
        // parses the address and returns the row index.
        private static UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }

        // Given the main workbook part, and a text value, insert the text into 
        // the shared string table. Create the table if necessary. If the value 
        // already exists, return its index. If it doesn't exist, insert it and 
        // return its new index.
        private static int InsertSharedStringItem(WorkbookPart wbPart, string value)
        {
            int index = 0;
            bool found = false;
            var stringTablePart = wbPart
                .GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

            // If the shared string table is missing, something's wrong.
            // Just return the index that you found in the cell.
            // Otherwise, look up the correct text in the table.
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
            }

            var stringTable = stringTablePart.SharedStringTable;
            if (stringTable == null)
            {
                stringTable = new SharedStringTable();
            }

            // Iterate through all the items in the SharedStringTable. 
            // If the text already exists, return its index.
            foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    found = true;
                    break;
                }
                index += 1;
            }

            if (!found)
            {
                stringTable.AppendChild(new SharedStringItem(new Text(value)));
                //stringTable.Save();
            }

            return index;
        }

        /********************************************************************************************************************************/























    /*
        public static SpreadsheetDocument Create(string filepath,string sheet1)
                {
                    // Create a spreadsheet document by supplying the filepath.
                    // By default, AutoSave = true, Editable = true, and Type = xlsx.
                    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.
                        Create(filepath, SpreadsheetDocumentType.Workbook);

                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Add Sheets to the Workbook.
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                        AppendChild<Sheets>(new Sheets());

                    // Append a new worksheet and associate it with the workbook.
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = sheet1
                    };
                    sheets.Append(sheet);


                    workbookpart.Workbook.Save();

                    // Close the document.
                    spreadsheetDocument.Close();

                                return spreadsheetDocument;
                }

      

                // Given a Worksheet and an address (like "AZ254"), either return a 
                // cell reference, or create the cell reference and return it.
                private static Cell InsertCellInWorksheet(Worksheet ws, WorkbookPart wbPart, string addressName, string value)
                {
                    SheetData sheetData = ws.GetFirstChild<SheetData>();
                    Cell cell = null;

                    UInt32 rowNumber = GetRowIndex(addressName);
                    Row row = GetRow(sheetData, rowNumber);

                    // If the cell you need already exists, return it.
                    // If there is not a cell with the specified column name, insert one.  
                    Cell refCell = row.Elements<Cell>().
                        Where(c => c.CellReference.Value == addressName).FirstOrDefault();
                    if (refCell != null)
                    {
                        cell = refCell;
                    }
                    else
                    {
                        cell = CreateCell(row, addressName);
                    }

                    int stringIndex = InsertSharedStringItem(wbPart, value);
                    cell.CellValue = new CellValue(value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                    return cell;
                }

                // Add a cell with the specified address to a row.
                private static Cell CreateCell(Row row, String address)
                {
                    Cell cellResult;
                    Cell refCell = null;

                    // Cells must be in sequential order according to CellReference. 
                    // Determine where to insert the new cell.
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        if (string.Compare(cell.CellReference.Value, address, true) > 0)
                        {
                            refCell = cell;
                            break;
                        }
                    }

                    cellResult = new Cell();
                    cellResult.CellReference = address;

                    row.InsertBefore(cellResult, refCell);
                    return cellResult;
                }

                // Return the row at the specified rowIndex located within
                // the sheet data passed in via wsData. If the row does not
                // exist, create it.
                private static Row GetRow(SheetData wsData, UInt32 rowIndex)
                {
                    var row = wsData.Elements<Row>().
                    Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
                    if (row == null)
                    {
                        row = new Row();
                        row.RowIndex = rowIndex;
                        wsData.Append(row);
                    }
                    return row;
                }

                // Given an Excel address such as E5 or AB128, GetRowIndex
                // parses the address and returns the row index.
                private static UInt32 GetRowIndex(string address)
                {
                    string rowPart;
                    UInt32 l;
                    UInt32 result = 0;

                    for (int i = 0; i < address.Length; i++)
                    {
                        if (UInt32.TryParse(address.Substring(i, 1), out l))
                        {
                            rowPart = address.Substring(i, address.Length - i);
                            if (UInt32.TryParse(rowPart, out l))
                            {
                                result = l;
                                break;
                            }
                        }
                    }
                    return result;
                }

                // Given the main workbook part, and a text value, insert the text into 
                // the shared string table. Create the table if necessary. If the value 
                // already exists, return its index. If it doesn't exist, insert it and 
                // return its new index.
                private static int InsertSharedStringItem(WorkbookPart wbPart, string value)
                {
                    int index = 0;
                    bool found = false;
                    var stringTablePart = wbPart
                        .GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

                    // If the shared string table is missing, something's wrong.
                    // Just return the index that you found in the cell.
                    // Otherwise, look up the correct text in the table.
                    if (stringTablePart == null)
                    {
                        // Create it.
                        stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
                    }

                    var stringTable = stringTablePart.SharedStringTable;
                    if (stringTable == null)
                    {
                        stringTable = new SharedStringTable();
                    }

                    // Iterate through all the items in the SharedStringTable. 
                    // If the text already exists, return its index.
                    foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
                    {
                        if (item.InnerText == value)
                        {
                            found = true;
                            break;
                        }
                        index += 1;
                    }

                    if (!found)
                    {
                        stringTable.AppendChild(new SharedStringItem(new Text(value)));
                       // stringTable.Save();
                    }

                    return index;
                }
        */
    }


}

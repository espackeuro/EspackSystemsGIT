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

        private static string IntToLetters(int value)
        {
            string result = string.Empty;
            while (--value >= 0)
            {
                result = (char)('A' + value % 26) + result;
                value /= 26;
            }
            return result;
        }

        public static bool CreateExcelFile(this RSFrame rs, string filePath, string sheet1="Sheet 1")
        {
            int _row;
            int _col;

            var _excelDoc = Create(filePath,sheet1);
            var wbPart = _excelDoc.WorkbookPart;

            Sheet sheet = wbPart.Workbook.Descendants<Sheet>().Where(
                           (s) => s.Name == sheet1).FirstOrDefault();

            Worksheet ws = ((WorksheetPart)(wbPart.GetPartById(sheet.Id))).Worksheet;


            _row = 1;
            rs.ToList().ForEach(_rowdata =>
            {

                _col = 1;

                _rowdata.ItemArray.ToList().ForEach(_columndata =>
                {

                    Cell cell = InsertCellInWorksheet(ws, IntToLetters(_col) + _row.ToString());


                    _col++;
                });
                _row++;
            }); 

                
                
           _excelDoc.WorkbookPart.Workbook.Save();

            //// Close the document.
            _excelDoc.Close();
            return true;
        }

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

            return spreadsheetDocument;

            //workbookpart.Workbook.Save();

            //// Close the document.
            //spreadsheetDocument.Close();
        }



        // Given a Worksheet and an address (like "AZ254"), either return a 
        // cell reference, or create the cell reference and return it.
        private static Cell InsertCellInWorksheet(Worksheet ws, string addressName)
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
            return cell;
        }

        // Add a cell with the specified address to a row.
        private static  Cell CreateCell(Row row, String address)
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



    }


}

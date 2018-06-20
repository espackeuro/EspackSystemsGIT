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

        // Create an excel file with a sheet named [sheetName] and current data the of recordset
        public static bool SaveExcelFile(this RSFrame rs, string filePath, string sheetName="Sheet 1",bool showColumnNames=true)
        {
            // Initialize vars
            int _row = 1;
            int _col = 1;

            // Create an empty excel file and get some objects from it
            SpreadsheetDocument _excelDoc = Create(filePath,sheetName);
            WorkbookPart _wbPart = _excelDoc.WorkbookPart;
            Sheet _sheet = _wbPart.Workbook.Descendants<Sheet>().Where((s) => s.Name == sheetName).FirstOrDefault();
            Worksheet _ws = ((WorksheetPart)(_wbPart.GetPartById(_sheet.Id))).Worksheet;
            SharedStringTablePart _stringTablePart = _wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            SheetData _sheetData = _ws.GetFirstChild<SheetData>();
            Row _excelRow;

            _excelDoc.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            WorkbookStylesPart stylesPart = _excelDoc.WorkbookPart.WorkbookStylesPart;

            stylesPart.Stylesheet = new Stylesheet();
            stylesPart.Stylesheet.Fonts = new Fonts();

            Font _fontBody = new Font(new FontSize() { Val = 12 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "Tahoma" });

            stylesPart.Stylesheet.Fonts.Append(_fontBody);
                        UInt32Value fontBodyId = Convert.ToUInt32(stylesPart.Stylesheet.Fonts.ChildElements.Count - 1);
/*                        stylesPart.Stylesheet.CellFormats = new CellFormats();
                        stylesPart.Stylesheet.CellFormats.Append(new CellFormat() { FontId = fontBodyId, FillId = 0, BorderId = 0, ApplyFont = true });
                        */
            //UInt32Value fontBodyId = 0;

            if (showColumnNames)
            {
                Font _fontTitle = new Font(new Bold(), new FontSize() { Val = 12 },new Color() { Rgb=new HexBinaryValue() { Value="000000" } }, new FontName() { Val="Tahoma" });
                stylesPart.Stylesheet.Fonts.Append(_fontTitle);
                UInt32Value fontTitleId = 0;// Convert.ToUInt32(stylesPart.Stylesheet.Fonts.ChildElements.Count - 1);
               // stylesPart.Stylesheet.CellFormats.Append(new CellFormat() { FontId = fontTitleId, FillId = 0, BorderId = 0, ApplyFont = true });

                _excelRow = new Row();
                _excelRow.RowIndex = (uint)_row;
                _sheetData.Append(_excelRow);


                rs.Fields.ToList().ForEach(_field =>
                {
                    AddCell(_sheetData, _stringTablePart, _ws, _wbPart, _excelRow, _col, _field.ToString(), fontTitleId, true);
                    _col++;
                });
                _row++;
            }

            // Go over the recordset to fill the excel cells
            rs.ToList().ForEach(_rowdata =>
            {
                _col = 1;
                _excelRow = new Row();
                _excelRow.RowIndex = (uint)_row;
                _sheetData.Append(_excelRow);
                _rowdata.ItemArray.ToList().ForEach(_columndata =>
                {
                    AddCell(_sheetData,_stringTablePart, _ws, _wbPart, _excelRow, _col, _columndata.ToString(),fontBodyId, true);
                    _col++;
                });
                _row++;
            });

            //// Save and close the document
            _excelDoc.WorkbookPart.Workbook.Save();
            _excelDoc.Close();
            return true;
        }

        // Create an empty excel file
        private static SpreadsheetDocument Create(string filepath, string sheetName)
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
            SharedStringTablePart stringTablePart = workbookpart.AddNewPart<SharedStringTablePart>();
            stringTablePart.SharedStringTable = new SharedStringTable();

            return spreadsheetDocument;
        }

        // Add a new cell
        //public static bool AddCell(SharedStringTablePart stringTablePart, Worksheet ws, WorkbookPart wbPart, string addressName, string value, UInt32Value styleIndex, bool isString)
        public static bool AddCell(SheetData sheetData,SharedStringTablePart stringTablePart, Worksheet ws, WorkbookPart wbPart, Row theRow, int col,string value, UInt32Value styleIndex, bool isString)
        {
            // Add a new cell to theRow
            Cell _cell = new Cell();
            _cell.CellReference = theRow.RowIndex.ToString()+IntToLetters(col);
            theRow.InsertBefore(_cell, null);

            if (isString)
            {
                // Either retrieve the index of an existing string,
                // or insert the string into the shared string table
                // and get the index of the new item.
                int stringIndex = InsertSharedStringItem(stringTablePart.SharedStringTable,wbPart, value);

                _cell.CellValue = new CellValue(stringIndex.ToString());
                _cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            }
            else
            {
                _cell.CellValue = new CellValue(value);
                _cell.DataType = new EnumValue<CellValues>(CellValues.Number);
            }
            _cell.StyleIndex = styleIndex;
            return true;
        }

        // Given the main workbook part, and a text value, insert the text into 
        // the shared string table.
        private static int InsertSharedStringItem(SharedStringTable stringTable, WorkbookPart wbPart, string value)
        {
            int _index = 0;
            bool _found = false;

  
            // Iterate through all the items in the SharedStringTable. 
            // If the text already exists, return its index.
            foreach (SharedStringItem _item in stringTable.Elements<SharedStringItem>())
            {
                if (_item.InnerText == value)
                {
                    _found = true;
                    break;
                }
                _index++;
            }

            if (!_found)
                stringTable.AppendChild(new SharedStringItem(new Text(value)));

            return _index;
        }

    }


}

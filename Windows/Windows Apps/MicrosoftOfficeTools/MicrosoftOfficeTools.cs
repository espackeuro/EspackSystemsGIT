using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CommonTools.CT;

namespace MicrosoftOfficeTools
{
    public static class MSTools
    {
        private static Application wordApp;
        public static string ConvertWordToPDF(string filePath)
        {
            try
            {
                //var app = new Microsoft.Office.Interop.Word.Application();
                var doc = wordApp.Documents.Open(filePath, ReadOnly: true);
                string pdfDocName = string.Format(@"{0}\{1}.pdf", Path.GetDirectoryName(filePath),Path.GetFileNameWithoutExtension(filePath));
                doc.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                //app.Quit();
                return pdfDocName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static byte[] ConvertWordToPDF(byte[] wordDocData)
        {
            byte[] _result;
            var tempWordFilePath = ByteArrayToFile(wordDocData);
            var tempPDFFilePath = ConvertWordToPDF(tempWordFilePath);
            _result = FileToByteArray(tempPDFFilePath);
            File.Delete(tempWordFilePath);
            File.Delete(tempPDFFilePath);
            return _result;
        }
        static MSTools()
        {
            wordApp = new Microsoft.Office.Interop.Word.Application();
        }
        //static ~MSTools()
        //{
        //    app.Quit();
        //}
    }
}

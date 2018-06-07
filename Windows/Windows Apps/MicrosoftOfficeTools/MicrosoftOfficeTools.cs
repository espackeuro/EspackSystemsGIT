using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOfficeTools
{
    public static class MSTools
    {

        public static string ConvertWordToPDF(string filePath)
        {
            try
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                var doc = app.Documents.Open(filePath, ReadOnly: true);
                string pdfDocName = string.Format(@"{0}\{1}.pdf", Path.GetDirectoryName(filePath),Path.GetFileNameWithoutExtension(filePath));
                doc.ExportAsFixedFormat(pdfDocName, WdExportFormat.wdExportFormatPDF);
                doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                app.Quit();
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
            var tempWordFilePath = string.Format(@"{0}{1}", Path.GetTempPath(), Path.GetRandomFileName());
            using (var fileStream = File.Create(tempWordFilePath))
            {
                fileStream.Write(wordDocData, 0, wordDocData.Length);
            }
            var tempPDFFilePath = ConvertWordToPDF(tempWordFilePath);
            using (var fileStream = File.OpenRead(tempPDFFilePath))
            {
                _result = (new BinaryReader(fileStream)).ReadBytes((int)fileStream.Length);
            }
            File.Delete(tempWordFilePath);
            File.Delete(tempPDFFilePath);
            return _result;
        }

    }
}

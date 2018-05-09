using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
namespace pdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            var doc = app.Documents.Open(@"D:\Users\Rafa\Documents\Analysed log.docx", ReadOnly:true);
            doc.ExportAsFixedFormat(@"D:\Users\Rafa\Documents\Analysed log.pdf", WdExportFormat.wdExportFormatPDF);
            doc.Close();
            app.Quit();
            
            var appx = new Microsoft.Office.Interop.Excel.Application();
            var docx = appx.Workbooks.Open(@"D:\Users\Rafa\Documents\Transfers 19 partial-20-21-22-23.xlsx", ReadOnly: true);
            docx.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, @"D:\Users\Rafa\Documents\Transfers 19 partial-20-21-22-23.pdf", XlFixedFormatQuality.xlQualityStandard);
            docx.Close();
            appx.Quit();
        }
    }
}

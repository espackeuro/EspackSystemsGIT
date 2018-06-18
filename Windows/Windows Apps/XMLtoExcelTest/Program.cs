using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

namespace XMLtoExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateExcel.Create(@"d:\Text.xlsx");
        }
    }
}
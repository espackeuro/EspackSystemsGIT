using EdiWeave.Core.Model.Edi;
using EdiWeave.Framework.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var ediStream = File.OpenRead(@"\\valsrv03\sistemas\test\DELFORGA-SLHINJECTOPLAST 29082018 1047323639.edi");
            List<EdiItem> edifactItems;
            using (var ediReader = new EdifactReader(ediStream, "EdiFabric.Templates.Edifact"))
            {
                edifactItems = ediReader.ReadToEnd().ToList();
            }
        }


    }

}

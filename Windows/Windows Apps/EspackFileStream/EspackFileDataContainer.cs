using System;
using System.IO;
using System.Collections.Generic;
using static CommonTools.CT;
using EspackFormControlsNS;
using System.Timers;

namespace EspackFormControlsNS
{
    public class EspackFileDataContainer : EspackDataContainer
    {
        //private string tmpFileDataPath;
        private List<string> GarbageFiles = new List<string>();
        private Timer timer;
        public string TempFileDataPath { get; private set; } = "";
        public string FileName { get; set; } = "";
        public EspackFileDataContainer()
        {
            timer = new Timer(5000) { Enabled = true };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TryDeleteGarbage();
        }

        public void WriteTempFile(string extension="")
        {
            if ((TempFileDataPath ?? "") != "")
            {
                GarbageFiles.Add(TempFileDataPath);
            }
            if (Value != null)
                TempFileDataPath = ByteArrayToFile(Data,extension);
            else TempFileDataPath = "";
        }
        public override void UpdateEspackControl()
        {
            base.UpdateEspackControl();
            WriteTempFile(Path.GetExtension(FileName));
        }

        private bool TryDeleteGarbage()
        {
            bool _result = true;
            if (GarbageFiles.Count != 0)
            {
                var gbarray = GarbageFiles.ToArray();
                foreach (var f in gbarray) 
                {
                    try
                    {
                        File.Delete(f);
                        GarbageFiles.Remove(f);
                    }
                    catch (Exception ex)
                    {
                        _result = false;
                    }
                };
            }
            return _result;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            TryDeleteGarbage();
        }
    }
}

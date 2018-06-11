using System;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using static CommonTools.CT;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EspackFormControls
{
    public class EspackDataContainer : EspackFormControlCommon
    {
        public byte[] Data { get; private set; }
        public override object Value { get => Data; set => Data = (byte[])value; }
        public override string Caption { get; set; }
        public string DBDataField { get; set; }
        public string DBCodeField { get; set; }
        public string DBTable { get; set; }

        public override void ClearEspackControl()
        {
            Data = null;
        }

        public override void UpdateEspackControl()
        {
            Value = ParentDA.SelectRS[DBDataField] is System.DBNull ? null : ParentDA.SelectRS[DBDataField];
        }
    }

    public class EspackFileDataContainer : EspackDataContainer
    {
        //private string tmpFileDataPath;
        private List<string> GarbageFiles = new List<string>();

        public string TempFileDataPath { get; private set; } = "";
        public void writeTempFile()
        {
            TempFileDataPath = ByteArrayToFile(Data);
            TryDeleteGarbage();
        }
        public override void UpdateEspackControl()
        {
            base.UpdateEspackControl();
            if ((TempFileDataPath ?? "") != "")
            {
                GarbageFiles.Add(TempFileDataPath);
            }
            if (Value != null)
                writeTempFile();
            else TempFileDataPath = "";
        }

        private bool TryDeleteGarbage()
        {
            bool _result = true;
            var gbarray = GarbageFiles.ToArray();
            if (GarbageFiles.Count != 0)
            {
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
            TryDeleteGarbage();
            base.Dispose(disposing);
        }
    }

}

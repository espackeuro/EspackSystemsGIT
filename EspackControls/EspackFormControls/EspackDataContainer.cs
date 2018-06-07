using System;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EspackFormControls
{
    public class EspackDataContainer : EspackFormControlCommon
    {
        public byte[] Data { get; private set; }
        public override object Value { get => Data; set => Data=(byte[])value; }
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
            Value = ParentDA.SelectRS[DBCodeField.ToString()];
        }
    }



}

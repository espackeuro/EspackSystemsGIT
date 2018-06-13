using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EspackFormControls
{
    public class EspackDataContainer : EspackFormControlCommon
    {
        public byte[] Data { get; private set; }
        public override object Value { get => Data; set => Data = value == null ? null : (byte[])value; }
        public override string Caption { get; set; }
        public override bool ReadOnly { get; set; }
        public override void ClearEspackControl()
        {
            Data = null;
        }

        public override void UpdateEspackControl()
        {
            Value = ParentDA.SelectRS[DBField] is System.DBNull ? null : ParentDA.SelectRS[DBField];
        }
    }

}

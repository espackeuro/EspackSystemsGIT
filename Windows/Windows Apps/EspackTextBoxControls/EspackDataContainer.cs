using System.Drawing;
using EspackControls;
using AccesoDatosNet;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EspackFormControlsNS;

namespace EspackFormControlsNS
{
#if DEBUG
    public class EspackDataContainer : EspackFormControlCommonMiddle
#else
    public class EspackDataContainer : EspackFormControlCommon
#endif
    {
        public byte[] Data { get; private set; }
        public override object Value { get => Data; set => Data = value == null ? null : (byte[])value; }
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

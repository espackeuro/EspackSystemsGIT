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
    public class EspackString : EspackFormControlCommonMiddle
#else
    public class EspackString : EspackFormControlCommon
#endif
    {
        public string Data { get; private set; }
        public override object Value { get => Data; set => Data = value.ToString() == null ? "" : value.ToString(); }
        public override bool ReadOnly { get; set; }
        public override void ClearEspackControl()
        {
            Data = "";
        }

        public override void UpdateEspackControl()
        {
            Value = ParentDA.SelectRS[DBField] is System.DBNull ? null : ParentDA.SelectRS[DBField];
        }
    }

}

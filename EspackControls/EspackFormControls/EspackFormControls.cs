using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using AccesoDatosNet;
using System.Threading.Tasks;

namespace EspackFormControls
{


    public interface EspackFormControl : EspackControl
    {
        bool IsCTLMOwned { get; set; }
        EspackLabel CaptionLabel { get; set; }
        string Caption { get; set; }
        DA ParentDA { get; set; }
        cAccesoDatosNet ParentConn { get; set; }
        DynamicRS DependingRS { get; set; }
        Point Location { get; set; }


        //List<StaticRS> ExternalControls;//list of possible external controls, the key is the parameter name and the object is the control
        //List<EspackControl> DependingControls { get; set; } //list of those controls which have me as external control
        //void AddRS(string pFieldName, EspackControl pControl);

    }
    public class ChangeEventArgs : EventArgs
    {
        public string CurrentValue { get; set; }
        public List<int> Index { get; set; }
        public string NewValue { get; set; }

    }
    public class AfterItemCheckEventArgs : ItemCheckEventArgs
    {
        public AfterItemCheckEventArgs(int Index, CheckState CurrentValue, CheckState NewValue) : base(Index, CurrentValue, NewValue) { }

        public string ListCurrentValue { get; set; }
        public string ListNewValue { get; set; }

    }
}

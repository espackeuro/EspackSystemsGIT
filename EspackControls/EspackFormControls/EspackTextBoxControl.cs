using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EspackFormControls
{
#if DEBUG
    public class EspackTextBoxControl : EspackFormControlCommonMiddle
    #else
    public class EspackTextBoxControl : EspackFormControlCommon
#endif
    {
        public override bool ReadOnly { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void ClearEspackControl()
        {
            throw new NotImplementedException();
        }

        public override void UpdateEspackControl()
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EspackTextBoxControl
            // 
            this.Name = "EspackTextBoxControl";
            this.Size = new System.Drawing.Size(366, 32);
            this.ResumeLayout(false);

        }
    }
}

using System.Windows.Forms;
using System.Drawing;

namespace EspackFormControls
{
    //public class EspackQuery : EspackControl
    //{
    //    EspackControlTypeEnum EspackControlType { get; set; }
    //    EnumStatus Status { get; set; }
    //    Point Location { get; set; }
    //    object Value { get; set; }
    //    string DBField { get; set; }
    //    bool Add { get; set; }
    //    bool Upp { get; set; }
    //    bool Del { get; set; }
    //    int Order { get; set; }
    //    bool PK { get; set; }
    //    bool Search { get; set; }
    //    object DefaultValue { get; set; }
    //    Type DBFieldType { get; set; }
    //    void UpdateEspackControl(EspackControlTypeEnum pUpdateType);
    //    void ClearEspackControl();



    //    public string Query { get; set; }


    //}

    public class EspackLabel : Label
    {

        EspackFormControl ParentControl { get; set; }
        public string Caption
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
                if (ParentControl != null)
                {
                    Location = new Point(60, ParentControl.Location.Y);//ParentControl.Location.X - PreferredWidth - 6
                }
            }
        }


        public EspackLabel(string pCaption, EspackFormControl pParentControl)
        {
            ParentControl = pParentControl;
            Caption = pCaption;
            Margin = new Padding(0, 0, 0, 0);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

}

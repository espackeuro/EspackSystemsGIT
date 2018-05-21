using System;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;

namespace EspackFormControls
{
    public class EspackString : EspackFormControl
    {
        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public EspackControlTypeEnum EspackControlType { get; set; }
        private string theString { get; set; }

        private EnumStatus status;

        public EnumStatus GetStatus()
        {
            return status;
        }

        public void SetStatus(EnumStatus value)
        {
            status = value;
        }

        public DynamicRS DependingRS { get; set; }
        public cAccesoDatosNet ParentConn { get; set; }
        public Point Location { get; set; }
        public bool Protected { get; set; }
        public object Value
        {
            get
            {
                return theString;
            }
            set
            {
                if (theString != (string)value)
                {
                    var oldValue = theString;
                    theString = value.ToString();
                    OnValueChanged(new ValueChangedEventArgs(oldValue, value));
                }
                
            }
        }

        public string DBField { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public int Order { get; set; }
        public bool PK { get; set; }
        public bool Search { get; set; }
        public object DefaultValue { get; set; } = "";
        public Type DBFieldType { get; set; }

        public event EventHandler TextChanged;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public void UpdateEspackControl()
        {
            theString = ParentDA.SelectRS[DBField.ToString()].ToString();
        }
        public void ClearEspackControl()
        {
            if (DefaultValue != null)
                theString = DefaultValue.ToString();
            else
                theString = "";
        }

        public void OnValueChanged(ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public EspackLabel CaptionLabel { get; set; }
        public DA ParentDA { get; set; }
        public string Caption { get; set; }

        public string Text
        {
            get
            {
                return theString;
            }

            set
            {
                theString = value; ;
            }
        }

        public string Name
        {
            get
            {
                return theString;
            }

            set
            {
                theString = value; ;
            }
        }
    }

}

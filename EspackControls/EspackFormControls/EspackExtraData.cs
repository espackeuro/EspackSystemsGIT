using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.Data;

namespace EspackFormControls
{
    public class EspackExtraData : EspackFormControl
    {
        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public EspackControlTypeEnum EspackControlType { get; set; }

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
        private List<EspackControl> LinkedItems { get; set; } = new List<EspackControl>();
        //private string[][] ExtraDataArray;
        public bool Protected { get; set; }

        public void AddLinkedItem(EspackControl Item)
        {
            Item.Add = Add;
            Item.Upp = Upp;
            Item.Del = Del;
            Item.Order = 0;
            Item.PK = false;
            LinkedItems.Add(Item);
            Item.ExtraDataLink = this;
        }

        private void SetExtraDataValue(string key, string newValue)
        {
            var cosa = LinkedItems.FirstOrDefault(o => o.DBField == key);
            if (cosa != null)
                cosa.Value = newValue;
            //theString = string.Join("|", LinkedItems.Select(p => string.Format("{0}={1}", p.DBField, p.Value)).ToArray());
        }
        private string GetExtraDataValue(string key)
        {
            //var ExtraDataArray = (ExtraData.Split('|')).Select(i => i.Split('=')).ToArray();
            return LinkedItems.First(o => o.DBField == key).Value.ToString();
        }

        public object Value
        {
            get
            {
                return string.Join("|", LinkedItems.Select(p => string.Format("{0}={1}", p.DBField, p.Value)).ToArray()); 
            }
            set
            {
                ClearEspackControl();
                if (((string)value ?? "") != "")
                {
                    var ExtraDataArray = (value.ToString().Split('|')).Select(i => i.Split('=')).ToList();
                    ExtraDataArray.ForEach(o => SetExtraDataValue(o[0], o[1]));
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

        public void UpdateEspackControl()
        {
            Value = ParentDA.SelectRS[DBField.ToString()].ToString();
        }
        public void ClearEspackControl()
        {
            LinkedItems.ForEach(i => i.Value = "");
        }
        public EspackLabel CaptionLabel { get; set; }
        public DA ParentDA { get; set; }
        public string Caption { get; set; }

        public string Text
        {
            get
            {
                return Value.ToString();
            }

            set
            {
                Value = value; ;
            }
        }

        public string Name
        {
            get
            {
                return Value.ToString();
            }

            set
            {
                Value = value; ;
            }
        }
    }

}

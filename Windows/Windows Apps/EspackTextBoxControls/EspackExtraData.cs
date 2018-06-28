using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.Data;

namespace EspackFormControlsNS
{
    public class EspackExtraData : EspackFormControlCommon
    {


        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
        }


        private List<EspackControl> LinkedItems { get; set; } = new List<EspackControl>();
        //private string[][] ExtraDataArray;


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

        public override object Value
        {
            get
            {
                return string.Join("|", LinkedItems.Select(p => string.Format("{0}={1}", p.DBField, p.Value)).ToArray()); 
            }
            set
            {
                var oldValue = Value;
                ClearEspackControl();
                if (((string)value ?? "") != "")
                {
                    var ExtraDataArray = (value.ToString().Split('|')).Select(i => i.Split('=')).ToList();
                    ExtraDataArray.ForEach(o => SetExtraDataValue(o[0], o[1]));
                }
                if (oldValue != value)
                    OnValueChanged(new ValueChangedEventArgs(oldValue, value));
            }
        }

        public override void UpdateEspackControl()
        {
            Value = ParentDA.SelectRS[DBField.ToString()].ToString();
        }
        public override void ClearEspackControl()
        {
            LinkedItems.ForEach(i => i.Value = "");
        }

        public override string Text
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

        public new string Name
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

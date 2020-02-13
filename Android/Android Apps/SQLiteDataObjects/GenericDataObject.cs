using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IData;
using SQLite;

namespace SQLiteDataObjects
{

    

    public class GenericRecord:IExtendedRecord
    {
        public virtual int IdReg { get; set; }
        public dataStatus Status { get; set; }
        public virtual bool Transferred { get; set; }
        public virtual string ProcedureParameters()
        {
            string result="";
            foreach (var prop in this.GetType().GetProperties())
            {
                result += $"{prop.Name}={prop.GetValue(this,null)},";
            }
            return result;
        }

    }
}
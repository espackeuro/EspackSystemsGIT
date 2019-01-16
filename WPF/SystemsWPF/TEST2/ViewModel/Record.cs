using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TEST2.ViewModel
{
    //Class for the GUI to display and modify products.
    //All product properties the GUI can touch are strings.
    //A single integer property, ProductId, is for database use only.
    //It is assigned by the DB when it creates a new product.  It is used
    //to identify a product and must not be modified by the GUI.
    public class Record
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //For DB use only!
        private int? _idreg;
        public int? _IdReg { get { return _idreg; } }

        private string elCampo1;
        public string ElCampo1
        {
            get { return elCampo1; }
            set { elCampo1 = value; OnPropertyChanged(new PropertyChangedEventArgs("ElCampo1"));
                }
        }


        private int? elCampo2;
        public int? ElCampo2
        {
            get { return elCampo2; }
            set { elCampo2 = value; OnPropertyChanged(new PropertyChangedEventArgs("ElCampo2")); }
        }



        public Record()
        {
        }

        public Record(int idreg, string elCampo1, int? elCampo2)
        {
            this._idreg = idreg;
            ElCampo1 = elCampo1;
            ElCampo2 = elCampo2;
        }

        public void CopyRecord(Record r)
        {
            this._idreg = r._IdReg;
            this.ElCampo1 = r.ElCampo1;
            this.elCampo2 = r.ElCampo2;
        }

        //Creating a new product in the DB assigns the ProductId
        //Update the ProductId from the value in the corresponding SqlProduct
        public void RecordAdded2DB(SqlRecord sqlRecord)
        {
            this._idreg = sqlRecord.IdReg;
        }


        public bool MatchesFilter(Record filter)
        {
            var currentType = this.GetType();
            foreach (PropertyInfo p in currentType.GetProperties())
            {

                if (currentType.GetProperty(p.Name).GetValue(this, null) == null && currentType.GetProperty(p.Name).GetValue(filter, null) != null)
                    return false;
                if (currentType.GetProperty(p.Name).GetValue(this, null) != null && currentType.GetProperty(p.Name).GetValue(filter, null) != null)
                {
                    if (!currentType.GetProperty(p.Name).GetValue(this, null).ToString().Contains(currentType.GetProperty(p.Name).GetValue(filter, null).ToString()))
                        return false;
                }

            }
            return true;
        }
        public bool IsClean()
        {
            var currentType = this.GetType();
            foreach (PropertyInfo p in currentType.GetProperties())
            {
                if (currentType.GetProperty(p.Name).GetValue(this, null) != null && currentType.GetProperty(p.Name).GetValue(this, null).ToString() != "")
                    return false;
            }
            return true;
        }
    } //class Product


    //Communiction to/from SQL uses this class for product
    //It has a decimal, not string, definition for UnitCost
    //Consversion routines SqlProduct <--> Product provided
    public class SqlRecord
    {
        public int IdReg { get; set; }
        public string ElCampo1 {get; set;}
        public int? ElCampo2 {get; set;}


        public SqlRecord() { }

        public SqlRecord(int idreg, string elCampo1, int? elCampo2)
        {
            IdReg = idreg;
            ElCampo1 = elCampo1;
            ElCampo2 = elCampo2;
        }

        public SqlRecord(Record r)
        {
            IdReg = r._IdReg ?? -1;
            ElCampo1 = r.ElCampo1;
            ElCampo2 = r.ElCampo2;
        }

        public Record SqlProduct2Product()
        {
            return new Record(IdReg, ElCampo1, ElCampo2);
        } //SqlProduct2Product()
    }

}

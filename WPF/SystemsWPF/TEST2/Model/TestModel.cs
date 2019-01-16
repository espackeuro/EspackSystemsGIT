using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using TEST2;
using TEST2.ViewModel;
using System.Data.Entity.Core.Objects;

namespace TEST2.Model
{
    public class TestModel
    {
        public bool hasError = false;
        public string errorMessage;

        public MyObservableCollection<Record> GetRecords()
        {
            hasError = false;
            MyObservableCollection<Record> products = new MyObservableCollection<Record>();
            try
            {
                TESTEntities ef = new TESTEntities();
                var query = from q in ef.TestTable
                            select new SqlRecord
                            {
                                IdReg = q.idreg,
                                ElCampo1 = q.elCampo1,
                                ElCampo2 = q.elCampo2
                            };
                foreach (SqlRecord sr in query)
                    products.Add(sr.SqlProduct2Product());
            } //try
            catch (Exception ex)
            {
                errorMessage = "GetRecords() error, " + ex.Message;
                hasError = true;
            }
            return products;
        } //GetProducts()


        public bool UpdateRecord(Record r)
        {
            hasError = false;
            ObjectParameter msg = new ObjectParameter("@msg", "");
            try
            {
                SqlRecord sr = new SqlRecord(r);
                TESTEntities ef = new TESTEntities();
                ef.pTestTableUpp(msg, sr.IdReg, sr.ElCampo1, sr.ElCampo2);
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
            if (msg.Value.ToString()!="OK")
            {
                errorMessage = "Update error, " + msg.Value.ToString();
                hasError = true;
            }
            return (!hasError);
        } //UpdateProduct()



        public bool DeleteRecord(int? idreg)
        {
            hasError = false;
            ObjectParameter msg = new ObjectParameter("msg", "");
            try
            {
                TESTEntities ef = new TESTEntities();
                ef.pTestTableDel(msg,idreg);
            }
            catch (Exception ex)
            {
                errorMessage = "Delete error, " + ex.Message;
                hasError = true;
            }
            if (msg.Value.ToString() != "OK")
            {
                errorMessage = "Delete error, " + msg.Value.ToString();
                hasError = true;
            }
            return !hasError;
        }// DeleteProduct()


        public bool AddRecord(Record dr)
        {
            hasError = false;
            ObjectParameter msg = new ObjectParameter("msg", "");
            ObjectParameter idreg = new ObjectParameter("idreg", 0);
            try
            {
                SqlRecord r = new SqlRecord(dr);
                TESTEntities dc = new TESTEntities();
                dc.pTestTableAdd(msg,idreg, r.ElCampo1, r.ElCampo2);
                r.IdReg = (int)idreg.Value;
                dr.RecordAdded2DB(r);    //update corresponding Record ProductId using SqlProduct
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
            if (msg.Value.ToString() != "OK")
            {
                errorMessage = "Add error, " + msg.Value.ToString();
                hasError = true;
            }
            return !hasError;
        } //AddProduct()
    } //class StoreDB
}

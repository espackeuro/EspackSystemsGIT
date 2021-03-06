using System.Linq;
using System.Threading.Tasks;
using System;

namespace RadioLogisticaDeliveries
{
    public class dataChecking : cData
    {
        public string Rack { get; set; }
        public string Serial { get; set; }
        public override infoData Info
        {
            get
            {
                return new infoData()
                {
                    c0 = "Serial:",
                    c1 = Serial,
                    c2 = "",
                    c3 = ""
                };
            }
        }
        public override async Task<bool> doCheckings()
        {
            //check if Rack is set
            if (Values.CurrentRack == "")
            {
                _errorMessage = "Rack not set, read rack first.";
                Status = dataStatus.ERROR;
                return false;
            }
            //check if already checked
            var query = await Values.SQLidb.db.Table<SerialTracking>().Where(r => r.Serial == Data).ToListAsync();
            if (query.Count() != 0)
            {
                _errorMessage = "Serial already checked.";
                Status = dataStatus.ERROR;
                return false;
            }
            query.Clear();
            query = null;

            //check if present and get serial data
            var query2 = await Values.SQLidb.db.Table<Labels>().Where(r => r.Serial == Data).ToListAsync();
            if (query2.Count() == 0)
            {
                _errorMessage = string.Format("Wrong serial {0}.", Serial);
                Status = dataStatus.ERROR;
                query2.Clear();
                query2 = null;
                return false;
            }
            var _LabelRack = query2[0].rack;
            if (_LabelRack != Values.CurrentRack)
            {
                _errorMessage = String.Format("Rack mismatch\n  {0} => {1}", Serial, _LabelRack);
                Status = dataStatus.ERROR;
                return false;
            }
            Status = dataStatus.READ;
            return true;
        }

        public override async Task<bool> ToDB()
        {
            try
            {
                await Values.SQLidb.db.InsertAsync(new ScannedData() { Action = "CHECK", Rack = Rack, Serial = Serial, Service = Values.gService, Session=Values.gSession, Transmitted=false });
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                _status = dataStatus.ERROR;
                return false;
            }
            _status = dataStatus.DATABASE;
            try
            {
                await Values.SQLidb.db.InsertAsync(new SerialTracking() { Serial = Data });
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                _status = dataStatus.ERROR;
                return false;
            }
            return true;
        }
    }
}
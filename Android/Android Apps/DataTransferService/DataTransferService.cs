using Android.App;
using Android.OS;
using System;
using System.Threading.Tasks;
using Android.Content;
using System.Timers;
using IData;
using System.Collections.Generic;
using AccesoDatosXML;
using System.Linq;
using SQLiteDataObjects;

namespace DataTransferService
{
    [Service]
    public class DataTransferService : Service
    {
        public NetworkStatusMonitor Monitor { get; set; }
        public bool Started { get; set; } = false;
        public bool Active { get; set; } = false;
        public bool Kill { get; set; } = false;
        public List<ExtendedTable> ListsToTransfer { get; } = new List<ExtendedTable>();
        public bool Transmitting { get; private set; } = false;
        public cAccesoDatosXML conn;
        private bool connectionWorking = false;

        public event EventHandler<TransmissionErrorEventArgs> TransmissionError;
        protected virtual void OnTransmissionError(TransmissionErrorEventArgs e)
        {
            TransmissionError?.Invoke(this, e);
        }

        public void SetConn(cAccesoDatosXML oConn)
        {
            conn = oConn.Clone();
            conn.DataBase = "Procesos";
        }


        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        private System.Timers.Timer elTimer;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Monitor = new NetworkStatusMonitor(this);
            Monitor.NetworkStatusChanged += Monitor_NetworkStatusChanged;
            Monitor.Start();
            elTimer = new System.Timers.Timer(5000);
            elTimer.Elapsed += ElTimer_Elapsed;
            elTimer.AutoReset = true;
            elTimer.Enabled = true;
            Started = true;
            Kill = false;
            //new Task(async () => await DoWork()).Start();
            return StartCommandResult.Sticky;
        }

        private void Monitor_NetworkStatusChanged(object sender, EventArgs e)
        {
            var netstatus = Monitor.State;
            connectionWorking = (netstatus == NetworkState.ConnectedData || netstatus == NetworkState.ConnectedWifi);
        }

        public override void OnDestroy()
        {
            elTimer.Stop();
            elTimer.Dispose();
            Started = false;
            Active = false;
        }
        private async void ElTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Kill)
            {
                StopSelf();
                return;
            }
            if (Active && connectionWorking)
            {
                await Transfer();
            }
        }

        public override bool StopService(Intent name)
        {
            elTimer.Stop();
            elTimer.Dispose();
            return base.StopService(name);
        }

        public async Task Transfer()
        {
            if (Transmitting)
                return;
            Transmitting = true;
            foreach (var IndividualList in ListsToTransfer.Where(o=> o.HasItemsToTransfer))
            {
                while(IndividualList.HasItemsToTransfer && connectionWorking)
                {
                    var itemToTransfer = IndividualList.ItemToTransfer;
                    using (SPXML sp = new SPXML(conn, "pLaunchProcess_ReadingSessionControl"))
                    {
                        //SPXML _sp = new SPXML(Values.gDatos, "pLaunchProcess_ReadingSessionControl");
                        sp.AddParameterValue("@DB", IndividualList.DataBase);
                        sp.AddParameterValue("@ProcedureName", IndividualList.ProcedureName);
                        sp.AddParameterValue("@Parameters", itemToTransfer.ProcedureParameters());
                        sp.AddParameterValue("@TableDB", "");
                        sp.AddParameterValue("@TableName", "");
                        sp.AddParameterValue("@TablePK", "");
                        try
                        {
                            await sp.ExecuteAsync();
                            if (sp.LastMsg.Substring(0, 2) != "OK")
                            {
                                Transmitting = false;
                                OnTransmissionError(new TransmissionErrorEventArgs() { ErrorMessage = sp.LastMsg });
                                return;
                            }
                            else
                            {
                                itemToTransfer.Status = dataStatus.TRANSMITTED;
                            }
                        }
                        catch (Exception ex)
                        {
                            Transmitting = false;
                            OnTransmissionError(new TransmissionErrorEventArgs() { ErrorMessage = ex.Message });
                            return;
                        }
                    }
                    {

                    }
                }
            }
        }
    }
    public class TransmissionErrorEventArgs:EventArgs
    {
        public string ErrorMessage { get; set; }
    }
}

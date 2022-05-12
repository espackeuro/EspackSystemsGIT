using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AccesoDatosXML;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using CommonTools;

namespace RadioSequencing
{

    class SqlServerCommands
    {
        // Crear los 2 contenedores de callbacks
        public event EventHandler<AsyncTaskResponse> Callback;
        public event EventHandler<AsyncTaskResponse> ErrorCallback;

        private readonly SynchronizationContext SyncContext;

        private cAccesoDatosXML Conn { get; set; }
        private void SendMessage(string Text, string extra=null)
        {
            SyncContext.Post(e => triggerCallback(new AsyncTaskResponse(Text, extra)), null);
        }
        private void SendError(string Text, string extra=null)
        {
            SyncContext.Post(e => triggerErrorCallback(new AsyncTaskResponse(Text, extra)), null);
        }

        public SqlServerCommands(cAccesoDatosXML conn)
        {
            SyncContext = AsyncOperationManager.SynchronizationContext;
            Conn = conn;
        }
        private void triggerCallback(AsyncTaskResponse response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            Callback.Invoke(this, response);
        }
        private void triggerErrorCallback(AsyncTaskResponse response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            ErrorCallback.Invoke(this, response);
        }


        //SQL Commands
        public async Task<CPendingDataReading> CheckUnclosedSessions()
        {
            SendMessage("Searching for non closed sessions with this device");
            var _result = new CPendingDataReading();
            using (var _rs = new XMLRS($"Select IdSession,xusr from SequencingSessionCab where dbo.CheckFlag(flags,'CLOSED')=0 and datediff(MINUTE,xfec,getdate())<120 and ScannerID='{Values.MyDeviceInfo.DeviceCode}' order by xfec desc", Conn))
            {
                await _rs.OpenAsync();
                if (_rs.RecordCount != 0)
                {
                    SendMessage($"Found unclosed session {_rs["IdSession"]}");
                    _result.SessionID = _rs["IdSession"].ToString();
                    _result.UserCode = _rs["xusr"].ToString();
                    using (var det = new XMLRS($"Select SequenceNumber,TicketVIN,TicketPartnumber,LabelPartnumber,LabelExtraData from SequencingSessionDet where IdSession='{_result.SessionID}' order by Line", Conn))
                    {
                        await det.OpenAsync();
                        while (!det.EOF)
                        {
                            var _d = new DataReading();
                            var extra = det["LabelExtraData"].ToString();
                            _d.SequenceNumber = det["SequenceNumber"].ToString();
                            _d.Batch = extra != "" ? extra.Split('|')[0].Split(':')[1] : "";
                            _d.PartnumberLabel = det["LabelPartnumber"].ToString();
                            _d.PartnumberSeqLabel = det["TicketPartnumber"].ToString();
                            _d.VINNr = det["TicketVIN"].ToString();
                            _d.TrollLocation = extra != "" ? extra.Split('|')[1].Split(':')[1] : "";
                            _d.Qty = 1;
                            _result.Readings.Add(_d);
                            SendMessage($"Found Sequence {_d.SequenceNumber}");
                            det.MoveNext();
                        }
                    }
                }
                else
                {
                    SendMessage("No pending sessions found.");
                    return null;
                }
            }
            return _result;
        }
        public async Task<DeviceInfo> GetDeviceInfo(string deviceSerial)
        {
            SendMessage("Getting device info.");
            var _result = new DeviceInfo();
            _result.Serial = deviceSerial;
            using (var _rs = new XMLRS($"Select CM,Code, MainCOD3 from Sistemas..ItemsCab where Serial='{deviceSerial}'", Conn))
            {
                await _rs.OpenAsync();
                if (_rs.RecordCount == 0)
                {
                    SendError("Device not found in Espack Inventory.");
                    return _result;
                }
                _result.CM = _rs["CM"].ToString();
                _result.DeviceCOD3 = _rs["MainCOD3"].ToString();
                _result.DeviceCode = _rs["Code"].ToString();
                SendMessage($"Device found {_result.CM} assigned to {_result.DeviceCOD3} warehouse");
            }
            return _result;
        }
        public async Task<CPendingDataReading> CreateNewSession(string system, string customerService, string cod3, string userCode, string serial)
        {
            SendMessage("Creating new session.");
            var _result = new CPendingDataReading();
            int _minSeq;
            int _maxSeq;
            var _sp = new SPXML(Conn, "pSequencingSessionCabAdd");
            //_sp.AddParameterValue("msg", _msg);
            _sp.AddParameterValue("System", system);
            _sp.AddParameterValue("CustomerService", customerService);
            _sp.AddParameterValue("COD3", cod3);
            _sp.AddParameterValue("UserCode", userCode);
            _sp.AddParameterValue("DeviceSerial", serial);
            await _sp.ExecuteAsync();
            if (_sp.LastMsg.Substring(0, 2) != "OK")
            {
                SendError($"Error returned by SQL Server:\n {_sp.LastMsg}");
                return _result;
            }
            _result.SessionID = _sp.LastMsg.Substring(3);
            _result.UserCode = userCode;
            _minSeq = _sp.Parameters["@MinSequence"].Value.ToInt();
            _maxSeq = _sp.Parameters["@MaxSequence"].Value.ToInt();
            SendMessage($"New session created {_result.SessionID}");
            SendMessage($"Assigning sequences from {_minSeq} to {_maxSeq}");
            for (int i = _minSeq; i <= _maxSeq; i++)
            {
                var _d = new DataReading();
                _d.SequenceNumber = i.ToString();
                _result.Readings.Add(_d);
            }

            return _result;
        }

        public async Task<List<SPartNumber>> GetServicePartnumbers(string service)
        {
            var _result = new List<SPartNumber>();
            SendMessage("Getting partnumbers");
            using (var _rs = new XMLRS($"select partnumber,prefix,base,suffix from logistica..referencias where servicio='{service}' and dbo.CheckFlag(flags,'OBS')=0", Conn))
            {
                await _rs.OpenAsync();
                SendMessage("@@startprogress", _rs.RecordCount.ToString());
                //ProgressChecks.Indeterminate = false;
                //ProgressChecks.Max = _rs.RecordCount;
                //ProgressChecks.Progress = 0;
                foreach (var r in _rs.Rows)
                {
                    //await Values.SQLidb.db.InsertAsync(new Referencias { partnumber = _rs["partnumber"].ToString(), pnBase = _rs["base"].ToString(), pnPrefix = _rs["prefix"].ToString(), pnSuffix = _rs["suffix"].ToString() });
                    var _part = new SPartNumber() { Base = _rs["base"].ToString(), Prefix = _rs["prefix"].ToString(), Suffix = _rs["suffix"].ToString() };
                    SendMessage("@@progressplus");
                    SendMessage(_part.PartNumber);
                    _result.Add(_part);
                    _rs.MoveNext();
                }
                //ProgressChecks.Indeterminate = true;
                //Values.sFt.CheckQtyTotal= _rs.Rows.Count;
                //Values.sFt.UpdateInfo();
            }
            SendMessage("Done");
            SendMessage("@@endprogress");
            return _result;
        }
        public class AsyncTaskResponse
        {

            public AsyncTaskResponse(string msg, string extraData = "")
            {
                Message = msg;
                ExtraData = extraData;
            }

            public string Message { get; }
            public string ExtraData { get; }
        }
    }
}
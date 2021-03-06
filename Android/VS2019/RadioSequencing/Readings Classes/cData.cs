
using System.Collections.Generic;
using System.Linq;
using CommonTools;
using System.Collections;
using System.Threading.Tasks;
using CommonAndroidTools;
using Android.Content;
using System;

namespace RadioSequencing
{
    public enum dataStatus { NONE, WARNING, ERROR, READ, DATABASE, TRANSMITTED }
    public class cData
    {

        protected string _errorMessage = "";
        protected string _warningMessage = "";
        public dataStatus _status = dataStatus.NONE;
        public string Data { get; set; }
        public dataStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (Context == null)
                {
                    throw new Exception("Context not set.");
                }
                _status = value;
                switch (_status)
                {
                    case dataStatus.READ:
                        cSounds.Scan(Context);
                        break;
                    case dataStatus.WARNING:
                        cSounds.Warning(Context);
                        break;
                    case dataStatus.ERROR:
                        cSounds.Error(Context);
                        break;
                }
            }
        }
        public Context Context { get; set; } = null;
        public virtual infoData Info { get; }
        public virtual string Error
        {
            get
            {
                return string.Format("Error: {0}", _errorMessage);
            }
        }
        public virtual string Warning
        {
            get
            {
                return string.Format("Warning: {0}", _warningMessage);
            }
        }
        public void PushInfo()
        {
            switch (Status)
            {
                case dataStatus.WARNING:
                    Values.iFt.SetMessage(Warning);
                    //Values.iFt.pushInfo(this.Info);
                    return;
                case dataStatus.ERROR:
                    Values.iFt.SetMessage(Error);
                    return;
            }
            Values.iFt.SetMessage("");
            //Values.iFt.pushInfo(this.Info);
        }

        public void UpdateCurrent()
        {
            switch (Status)
            {
                case dataStatus.WARNING:
                    Values.iFt.SetMessage(Warning);
                    //Values.iFt.pushInfo(Info);
                    //Values.iFt.updateMainLine(Info);
                    return;
                case dataStatus.ERROR:
                    Values.iFt.SetMessage(Error);
                    return;
            }
            Values.iFt.SetMessage("");
            //Values.iFt.updateMainLine(Info);
        }

        public virtual Task<bool> doCheckings() { return Task.FromResult(false); }
        public virtual Task<bool> ToDB() { return Task.FromResult(false); }
        public virtual void Transmit() { }

    }
}
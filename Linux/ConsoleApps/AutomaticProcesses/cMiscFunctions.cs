using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AutomaticProcesses
{
    static class cMiscFunctions
    {
        public enum eFileType { HTML, PDF, XLS, TXT }
        public enum eOrientation { PORTRAIT, LANDSCAPE }
        
        static string Service = "";

        public static string PathSeparator()
        {
            //return pDebug ? "\\" : "/";
            return RunningOnLinux() ? "/" : "\\";
        }

        public static bool RunningOnLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }

        public static string DefaultValues(string Value) //valores_defecto($valor)
        {
            string _result = "";
            switch (Value.ToUpper())
            {
                case "HOY":
                case "TODAY":
                    //$res=date("d-m-Y");
                    _result = DateTime.Today.ToString("dd-MM-yyyy");
                    break;
                case "AYER":
                case "YESTERDAY":
                    //$res = strftime('%d-%m-%Y', DateAdd('w', -1, time()));
                    _result = DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy");
                    break;
                case "AÑO":
                case "ANYO":
                case "YEAR":
                    //$res = date("Y");
                    _result = DateTime.Today.Year.ToString();
                    break;
                case "MES":
                case "MONTH":
                    //$res = date("n");
                    _result = DateTime.Today.Month.ToString();
                    break;
                case "PRIMERDIAMES":
                case "FIRSTMONTHDAY":
                    //$res = date("1-m-Y");
                    //_result = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("d-M-Y");
                    _result = DateTime.Today.ToString("01-MM-yyyy");

                    break;
                case "PRIMERDIAAÑO":
                case "PRIMERDIAANYO":
                case "FIRSTYEARDAY":
                    //$res = date("1-1-Y");
                    _result = DateTime.Today.ToString("01-01-yyyy");
                    break;
                case "SERVICIO":
                case "SERVICE":
                    //$res =$_SESSION['proveedor'];
                    _result = Service; // not used for AutomaticProcesses, it is only for Portal
                    break;
                default:
                    //$res =$valor;
                    _result = Value;
                    break;
            }
            return _result;
        }

        public static Dictionary<int, string> CheckArgs(string Params)
        {
            Dictionary<int, string> _params = new Dictionary<int, string>();
            if (Params.Trim() != "")
            {
                foreach (string _param in Params.Trim().Split(" "))
                {
                    _params.Add(_params.Count + 1, DefaultValues(_param));
                }
            }
            return _params;
        }

    }
  
}

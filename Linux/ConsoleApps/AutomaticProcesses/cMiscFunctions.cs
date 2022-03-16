using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AutomaticProcesses
{
    static class cMiscFunctions
    {
        public enum eFileType { HTML, PDF, XLS, TXT }
        public enum eOrientation { PORTRAIT, LANDSCAPE }

        static string Service = "";

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
                    _result = Service;
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

        public static string CodeHTML(string html)
        {
            System.Text.RegularExpressions.Regex _regHtml = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string _result = _regHtml.Replace(HttpUtility.HtmlEncode(html), "");
            return _result;
        }

        // translated from origina PHP code: define the style string for html
        private static void GetStyle(ref string style, ref string value)
        {
            string _styleStr = "";
            
            // Compatibility with old queries for portalnet (<strong></strong> -> [N])
            if (value.StartsWith("&lt;strong&gt;"))
                value = value.Replace("&lt;strong&gt;", "[N]").Replace("&lt;/strong&gt;", "");

            //gestion de estilos, si el campo empieza con [ busca [IDCNSK]
            if (value.StartsWith("["))
            {
                _styleStr = value.Substring(1, value.IndexOf("]") - 1);
                value = value.Substring(value.IndexOf("]") + 1);

                for (int _i = 0; _i < _styleStr.Length; _i++)
                {
                    switch (_styleStr.Substring(_i, 1))
                    {
                        case "I":
                            style += " text-align:left;";
                            break;
                        case "D":
                            style += " text-align:right;";
                            break;
                        case "C":
                            style += " text-align:center;";
                            break;
                        case "N":
                            style += " font-weight:bold;";
                            break;
                        case "S":
                            style += " text-decoration: underline;";
                            break;
                        case "K":
                            style += " font-style: italic;";
                            break;
                    }
                }
            }
            else
            {
                int _dummy;
                if (Int32.TryParse(value, out _dummy)) style += " text-align:right;";
            }
        }

        // translated from origina PHP code: define the HTML code for the header
        //private static void Header(ref int row, ref int page, ref string html, ref Dictionary<string, string> rowData, string title, ref int cols, string[] titles)
        private static string Header(bool firstPage, Dictionary<string, string> rowData, string title, ref int cols, string[] titles)
        {
            int _hidden;
            string _field, _style, _value;
            string _html = "";

            cols = rowData.Count;
            if (!firstPage)
                _html += "</table></div>";

            _html += "<div id='Cabecera' style='position:absolute; top:0; left:0;'>";
            _html += "<table width='100%'><tr><td class='titulo'>" + HttpUtility.HtmlEncode("ESPACK EUROLOGÍSTICA") + "</td><td class='timestamp'>" + DateTime.Now.ToString("r") + "</td></tr>";

            if (firstPage)
                _html += $"<tr><td class='subtitulo' colspan=2>{title}</td></tr>";

            _html += "</table></div><div id = 'Cuerpo'style='position:absolute; top:150; left:0;'>";
            _html += "<table class='tabla' align='center'>"; // End of header
            _html += "<tr class='cabecera'>";

            //row = 1;
            _hidden = 0;

            for (int _i = 0; _i < cols; _i++)
            {
                _field = rowData.ElementAt(_i).Key;
                if (!_field.StartsWith("&"))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(_field, "[c][0-9]"))
                    {
                        _field = " ";
                    }
                    else
                    {
                        _field = CodeHTML(_field);
                    }
                    _html += $"<td class='cabecera'>{_field}</td>";
                }
                else
                {
                    _hidden++;
                }
            }
            if (titles != null)
            {
                _html += "</tr><tr class='detalle'>";
                foreach (var _item in titles)
                {
                    _style = "";
                    _value = _item;
                    GetStyle(ref _style, ref _value);
                    _html += $"<td class='cabecera'><div style='{_style}'>{_value}</div></td>";
                }
                //row = 2;
            }
            //page++;
            cols -= _hidden;
            _html += "</tr>";

            return _html;

        }

        // translated from origina PHP code: define the HTML code for the query results
        public static string ProcessHTML(Dictionary<int, Dictionary<string, string>> data, string title, string orientation, bool noBand = false, bool excel = false)
        {
            string _stage = "";
            string _html = "";
            string _extra = (noBand ? "border-bottom-style: solid;" : "");
            int fontSize = 11;

            _html = "<html><head>";
            if (!excel)
            {
                _html += "<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">";
            }
            else
            {
                _html += "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"";
                _html += "xmlns:x=\"urn:schemas-microsoft-com:office:excel\"";
                _html += "xmlns=\"http://www.w3.org/TR/REC-html40\">";
                _html += "<head><meta http-equiv=Content-Type content=\"text/html; charset=windows-1252\">";
                _html += "<meta name = ProgId content=Excel.Sheet>";
                _html += "<meta name=Generator content=\"Microsoft Excel 11\"";
            }

            _html += "<style type='text/css'>";
            _html += ".titulo {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 20pt;";
            _html += "font-weight: bold;";
            _html += "text-align: left;";
            _html += "}";
            _html += ".tabla {";
            _html += "page-break-after: always;";
            _html += "}";
            _html += ".timestamp {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 12pt;";
            _html += "font-weight: bold;";
            _html += "text-align: right;";
            _html += "}";
            _html += ".subtitulo {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 14pt;";
            _html += "font-weight: bold;";
            _html += "text-align: left;";
            _html += "}";
            _html += ".cabecera {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize};";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".titulo_tabla {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize+3};";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".detalle {";
            _html += "font-family: Courier;";
            _html += "font-size: {fontSize};";
            _html += $"{_extra}}}";
            _html += ".fondogris {";
            _html += "background-color: #CCCCCC;";
            _html += "}";
            _html += "</style></head><body>";

            bool _firstLine = true;
            bool _firstPage = true;
            string _bgColor= "FFFFFF";
            string _styleIni, _style;
            int _cols = 0;
            string[] _titles = null;
            string _value;

            Dictionary<string, string> _currentRow;

            for (int _i = 0; _i < data.Count; _i++)
            {
                _currentRow = data.Values.ElementAt(_i);
                if (_firstLine)
                {
                    _html += Header(_firstPage, _currentRow, title, ref _cols, _titles);
                    _firstLine = false;
                    _firstPage = false;
                }

                // For banded results
                if (!noBand)                
                    _bgColor = _bgColor == "DDDDDD" ? "FFFFFF" : "DDDDDD";

                _styleIni = $"color:#000000; background-color:#{_bgColor};";

                if (_currentRow.ElementAt(0).Key=="&COLOR")
                {
                    if(_currentRow.ElementAt(0).Value.Length==12)
                        _styleIni = " color:#" + _currentRow.ElementAt(0).Value.Substring(0, 6) + "; background-color:#" + _currentRow.ElementAt(0).Value.Substring(6, 6) + ";";
                }

                _html += $"<tr class='detalle' style='{_styleIni}'>";

                // Go for each field
                foreach (var _field in _currentRow)
                {
                    // Prepare the field value for HTML code
                    _value = CodeHTML(_field.Value);

                    // When the field name starts with &, it requires a special treatment
                    if (!_field.Key.StartsWith("&"))
                    {
                        // If the field value contains the string [Titulo], it is a title and it has to be shown as it
                        if (_value.IndexOf("[Titulo]") != -1)
                        {
                            _value = _value.Replace("[Titulo]", "");
                            /*
                             * Salto de página a implementar
                            if (($numfilas - ($fila % $numfilas))< 4) {//si el t�tulo est�?en las �ltimas 4 filas, insertamos un salto y lo ponemos en la p�gina siguiente
                                        $msg.= "<td colspan=$cols>---</td></tr>";
                                       cabecera($fila,$pagina,$msg,$rst, '',$cols, '');
                                        $msg.= "<tr class='detalle' style='$style'>\n";
                            */
                            if (false)
                            {
                                _html += $"<td colspan={_cols}>---</td></tr>";
                                Header(_firstPage, _currentRow, "", ref _cols, null);
                                _html += $"<tr class='detalle' style='{_style}'>";
                            }

                            _html += $"<td colspan={_cols}>--------</td></tr><tr><td {_extra} class='titulo_tabla' colspan={_cols}>{_value}</td></tr>"; //insertamos el t�tulo sin [Titulo]
                            _i++;
                            _currentRow = data.Values.ElementAt(_i);

                            /*
                             * Control de líneas (por ver si es necesario).
                           ($linea % 2)== 1 ?$linea += 1:$linea;//para que siempre empiece con el mismo color
                                   $fila += 2;
                            ....
                           */
                            _titles = _currentRow.Keys.ToList().Where(x => !x.StartsWith("&")).Select(x => CodeHTML(_currentRow[x])).ToArray();
                            _html += "<tr>";
                            foreach (var _item in _titles)
                            {
                                _value = _item;
                                _style = _styleIni;
                                GetStyle(ref _style, ref _value);
                                _html += ((_value == "") ? "<td>&nbsp</td>" : $"<td {_extra} class='cabecera'><div style='{_style}'>" +  HttpUtility.HtmlEncode(_value) )+ "</div></td>";
                            }
                            break;
                        }
                        _style = _styleIni;
                        
                        // Process the style prefixes: [D], [I], etc...
                        GetStyle(ref _style,ref _value);

                        _html += (_value == "" ? "<td><div>" : $"<td {_extra} class='detalle'><div style='{_style}'>")+ $"{_value}</div></td>";
                        
                    }

                }
                _html += "</tr>";
            }
            _html+= "</table></body></html>"; //insertamos el pie de p�gina con los n�meros de p�gina

            return _html;
        }
    }
            /*

                $font_b = Font_Metrics::get_font("Courier", "bold"); ;
    $text_height = Font_Metrics::get_font_height($font_b, $fontsize);

      

    $orientacion = strtoupper($orientacion);
    $numfilas = ($orientacion == 'LANDSCAPE')?intval(300 /$text_height):(($orientacion == 'PORTRAIT')?intval(470 /$text_height):999999); //calculamos las l�neas por p�gina para los casos portrait, landscape y resto
    $fila = 0;
    $linea = 0;
    $pagina = 1;
    $rst->MoveFirst();
    $cols = 0;
    $tit = false;
    $titulos = '';
        }

    }*/
}

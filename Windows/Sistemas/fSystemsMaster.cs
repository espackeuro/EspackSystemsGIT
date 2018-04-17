using AccesoDatosNet;
using CommonTools;
using CommonToolsWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sistemas
{
    public partial class fSystemsMaster : Form
    {
        public fSystemsMaster()
        {
            InitializeComponent();

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pMasterSystemsAdd";
            CTLM.sSPUpp = "pMasterSystemsUpp";
            CTLM.sSPDel = "pMasterSystemsDel";
            CTLM.DBTable = "MasterSystems";

            //Header
            CTLM.AddItem(txtSystemCode, "SystemCode", true, true, true, 1, true, true);
            CTLM.AddItem(txtDescription, "Description", true, true, false, 0, false);
            CTLM.AddItem(cboDatabase, "DB", true, true, false, 0, false, true);
            CTLM.AddItem(txtApp, "App", true, true, false, 0, false, true);
            CTLM.AddItem(txtVersion, "Version", true, true, false, 0, false, true);
            CTLM.AddItem(lstLocations, "Locations", true, true, false, 0, false, true);
            CTLM.AddItem(lstUserPositions, "UserPositions", true, true, false, 0, false, true);
            CTLM.AddItem(lstAreas, "Areas", true, true, false, 0, false, true);
            CTLM.AddItem(lstRequiredUserFlags, "RequiredUserFlags", true, true, false, 0, false, true);

            CTLM.AddItem(lstFlags, "flags", true, true, false, 0, false, true);

            cboDatabase.Source("Select name from sys.databases order by name");
            lstLocations.Source("Select cod3,nombre from vSedes order by nombre");
            lstUserPositions.Source("Select PositionCode, Convert(varchar,MinSecurityLevel)+'-'+PositionDescription from MasterUserPositions order by MinSecurityLevel");
            lstAreas.Source("Select idArea,Description from MasterAreas order by idArea");
            lstRequiredUserFlags.Source("select codigo,descFlagEng from flags where tabla='Users' order by DescFlagEng");
            lstFlags.Source("select codigo,descFlagEng from flags where tabla='MasterSystems' order by DescFlagEng");


            CTLM.AddDefaultStatusStrip();
            CTLM.Start();
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            CTLM.BeforeButtonClick += CTLM_BeforeButtonClick;
        }
        private void CTLM_BeforeButtonClick(object sender, CTLMantenimientoNet.CTLMEventArgs e)
        {
            switch (CTLM.Status)
            {
                case EnumStatus.ADDNEW:
                case EnumStatus.EDIT:
                    {
                        if (txtVersion != txtNetVersion)
                        {
                            txtVersion.Text = txtNetVersion.Text;
                        }
                    }
                    break;
            }
        }
        private void CTLM_AfterButtonClick(object sender, CTLMantenimientoNet.CTLMEventArgs e)
        {
            string _COD3 = "";
            FileVersionInfo _localFileVersion;
            switch (CTLM.Status)
            {
                case EnumStatus.NAVIGATE:
                case EnumStatus.SEARCH:
                    {
                        if (isEspackIP(ref _COD3) && txtSystemCode.Text != "")
                        {
                            using (var _RS = new StaticRS(string.Format("Select APPServer from sistemas..NetworkSedes where COD3='{0}'", _COD3), Values.gDatos))
                            {
                                _RS.Open();
                                if (!_RS.EOF)
                                {
                                    string _pathToExe = string.Format(@"\\{0}\raiz\media\shares\APPS_CS\{1}\{2}", _RS["AppServer"].ToString(), txtSystemCode.Text.ToLower(), txtApp.Text.ToString().ToLower());
                                    //_pathToExe = @"\\valsrv02\raiz\media\shares\APPS_CS\almacenaje\almacenaje.exe";
                                    try
                                    {
                                        _localFileVersion = FileVersionInfo.GetVersionInfo(_pathToExe);
                                        txtNetVersion.Text = _localFileVersion.FileVersion.ToString();
                                        if (txtNetVersion.Text != txtVersion.Text)
                                            txtNetVersion.BackColor = Color.LightSalmon;
                                        else
                                            txtNetVersion.BackColor = txtVersion.BackColor;
                                    }
                                    catch (SecurityException se)
                                    {
                                        MessageBox.Show(se.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch 
                                    {
                                        // MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtNetVersion.Text = "";
                                        txtNetVersion.BackColor = txtVersion.BackColor;
                                    }
                                }

                            }
                        }
                    }
                    break;
            }
        }

        private bool isEspackIP(ref string COD3)
        {
            //#if DEBUG
            //            COD3 = "OUT";
            //            return false;
            //#else
            int _zone;
            var _IP = Values.gDatos.IP.GetAddressBytes();
            if (_IP[0] == 10)
                _zone = _IP[1];
            else
                _zone = _IP[2];
            using (var _RS = new StaticRS(string.Format("Select COD3 from GENERAL..Sedes where zone='{0}'", _zone), Values.gDatos))
            {
                _RS.Open();
                if (_RS.RecordCount == 0)
                {
                    COD3 = "OUT";
                    return false;
                }
                COD3 = _RS["COD3"].ToString();
            }
            return true;
            //#endif
        }

        private void btnReloadVersions_Click(object sender, EventArgs e)
        {
            btnReloadVersions.Enabled = false;
            try
            {
                CTLM.ClearValues();
                txtNetVersion.Text = "";
                CTLM.SetStatus(EnumStatus.SEARCH);
                CTLM.Button_Click("btnOk");
                Application.DoEvents();
                while (!CTLM.EOF)
                {
                    CTLM.ShowRSValues();
                    Application.DoEvents();
                    if (txtVersion.Text != txtNetVersion.Text)
                    {
                        int i = CTLM.RSPosition;
                        CTLM.SetStatus(EnumStatus.EDIT);
                        txtVersion.Text = txtNetVersion.Text;
                        CTLM.Button_Click("btnOk");
                        Application.DoEvents();
                        CTLM.ClearValues();
                        txtNetVersion.Text = "";
                        CTLM.SetStatus(EnumStatus.SEARCH);
                        CTLM.Button_Click("btnOk");
                        Application.DoEvents();
                        CTLM.setRSPosition(i);
                    }
                    txtNetVersion.Text = "";
                    CTLM.Button_Click("btnNext");
                }
            } catch (Exception ex)
            {
                btnReloadVersions.Enabled = true;
                throw ex;
            }
            btnReloadVersions.Enabled = true;
        }
        private bool generateXMLSystems()
        {
            int contador=0;
            string servidor = "";
            // lets get the counter for the XML file version
            using (var getContador= new SP(Values.gDatos, "pGetContador"))
            {
                getContador.AddParameterValue("Contador", contador);
                getContador.AddParameterValue("Serv", servidor);
                getContador.AddParameterValue("Codigo", "XMLSystems");
                try
                {
                    getContador.Execute();
                }
                catch (Exception ex)
                {
                    CTWin.MsgError(ex.Message);
                    return false;
                }
                if (getContador.LastMsg.Substring(0, 2) != "OK")
                {
                    CTWin.MsgError(getContador.LastMsg);
                    return false;
                }
                contador = Convert.ToInt32(getContador.ReturnValues()["@Contador"]);
            }
            // create the root of the XML doc
            XDocument xmlDocument;
            string _xml = string.Format(
@"<?xml version='1.0' encoding='utf - 8'?>
<!--{0} systems file-->
<systemsfile version='{0}'>
<specials>
</specials>
<systems>
</systems>
</systemsfile>", contador);
            xmlDocument = XDocument.Parse(_xml);
            var serverSystemsPath = "\\\\VALSRV02\\APPS_CS";
            //get files in apps directory
            var serverSystemsDir = Directory.GetFiles(serverSystemsPath).Where(f => Path.GetExtension(f)==".zip");
            //create the rootDir element
            foreach (var filePath in serverSystemsDir)
            {
                var fileInfo = new FileInfo(filePath);
                var xSpecialElement = new XElement("special", new XAttribute("name", Path.GetFileNameWithoutExtension(filePath)));
                var xSElement = new XElement("File",new XAttribute("path", filePath.Replace(serverSystemsPath, "").Replace(fileInfo.Name,"").Substring(1)), new XAttribute("fileName", fileInfo.Name), new XAttribute("fileSize", fileInfo.Length), new XAttribute("fileTime", fileInfo.LastWriteTime));
                xSpecialElement.Add(xSElement);
                xmlDocument.Descendants("specials").FirstOrDefault().Add(xSpecialElement);
            }
            var directories = Directory.GetDirectories(serverSystemsPath);
            foreach (var directoryPath in directories)
            {
                var dirInfo = new DirectoryInfo(directoryPath);
                var xSystemElement = new XElement("system", new XAttribute("name",dirInfo.Name));
                xSystemElement.Add(xmlFromDirectory(directoryPath, serverSystemsPath));
                xmlDocument.Descendants("systems").FirstOrDefault().Add(xSystemElement);
            }
            var localXmlFile = "d:\\APPS_CS\\systems.xml";
            xmlDocument.Save(localXmlFile);
            return true;
        }

        private XElement xmlFromDirectory(string baseDir, string serverSystemsPath)
        {
            var files = Directory.GetFiles(baseDir);
            XElement xResult = new XElement("Directory",new XAttribute("path", baseDir.Replace(serverSystemsPath, "").Substring(1)));
            foreach (var filePath in files)
            {
                var fileInfo = new FileInfo(filePath);
                var xElement = new XElement("File", new XAttribute("path", filePath.Replace(serverSystemsPath, "").Replace(fileInfo.Name, "").Substring(1)), new XAttribute("fileName", fileInfo.Name), new XAttribute("fileSize", fileInfo.Length), new XAttribute("fileTime", fileInfo.LastWriteTime));
                xResult.Add(xElement);
            }
            var directories = Directory.GetDirectories(baseDir);
            foreach (var directoryPath in directories)
            {
                xResult.Add(xmlFromDirectory(directoryPath, serverSystemsPath));
            }
            return xResult;
        }

        private void btnXMLFile_Click(object sender, EventArgs e)
        {
            generateXMLSystems();
        }
    }
}

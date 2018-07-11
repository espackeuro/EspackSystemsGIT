using System;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonTools;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using EspackFormControlsNS;
using static Sistemas.Values;
namespace Sistemas
{
    public partial class fUsers : Form
    {
        private string _prevStatus;
        public fUsers()
        {
            InitializeComponent();
            
            //CTLM definitions
            //Who
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "pAddUsers";
            CTLM.sSPUpp = "pUppUsers";
            CTLM.sSPDel = "";
            CTLM.AddItem(txtUserCode, "UserCode", true, true, false, 1, true, true);
            CTLM.AddItem(txtName, "Name", true, true, false, 0, false, true);
            CTLM.AddItem(txtSurname1, "Surname1", true, true, false, 0, false, true);
            CTLM.AddItem(txtSurname2, "Surname2", true, true, false, 0, false, true);
            CTLM.AddItem(txtUserNumber, "UserNumber", false, true, false, 0, false, true);
            //Where
            CTLM.AddItem(cboCOD3, "MainCOD3", true, true, false, 1,false, true);
            CTLM.AddItem(txtDesCod3, "desCOD3", CTLMControlTypes.NoSearch);
            CTLM.AddItem(listCOD3, "COD3", true, true, false, 1, false, true);
            CTLM.AddItem(cboPosition, "Position", true, true, false, 1, false, true);
            CTLM.AddItem(cboPositionLevel, "PositionLevel", false, true, false, 0, false, true);
            CTLM.AddItem(cboSecurityLevel, "SecurityLevel", true, true, false, 0, false, true);
            CTLM.AddItem(cboArea, "area", true, true, false, 0, false, true);
            //Systems
            CTLM.AddItem(txtPWD, "Password", false, true, false, 0, false, false);
            CTLM.AddItem(txtPasswordEXP, "PasswordEXP", false, true, false, 0, false, false);
            CTLM.AddItem(txtPIN, "PIN", false, true, false, 0, false, false);
            CTLM.AddItem(cboDomain, "domain", true, false, false, 0, false, true);
            CTLM.AddItem(txtEmail, "emailAddress", false, false, false, 0, false, true);
            CTLM.AddItem(txtQuota, "EmailQuota", false, true, false, 0, false, false);
            CTLM.AddItem(lstFlags, "Flags", true, true, false, 0, false, true);
            CTLM.AddItem(txtTicket, "Ticket", CTLMControlTypes.NoSearch);
            CTLM.AddItem(txtTicketExp, "TicketExp", CTLMControlTypes.NoSearch);
            CTLM.AddItem(lstEmailAliases, "Aliases",true,true,false,0,false,false,pSPAddParamName: "alias", pSPUppParamName: "alias");
            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = string.Format("(Select * from vUsers where isnull(PositionLevel,50)>={0}) B", SecurityLevel);
            CTLM.ReQuery = true;
            cboCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3", txtDesCod3);
            listCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");
            listCOD3.ValueChanged += ListCOD3_Changed;
            cboDomain.Source("Select domain from domain where domain<>'ALL' order by domain");
            cboPosition.Source(string.Format("select PositionCode,PositionDescription from MasterUserPositions where MinSecurityLevel>={0} order by MinSecurityLevel", SecurityLevel), txtPosition);
            cboPositionLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboSecurityLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboArea.Source(string.Format("select idArea from MasterAreas order by idArea", SecurityLevel));
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='Users'");
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            CTLM.Start();
            _prevStatus = listCOD3.Text;
            cboCOD3.ComboBox.SelectedValueChanged += delegate
            {
                if (cboCOD3.SelectedValue != null && (CTLM.Status==EnumStatus.EDIT || CTLM.Status==EnumStatus.ADDNEW))
                    listCOD3.CheckItem(cboCOD3.Text);
            };
            
            listCOD3.CheckedListBox.ItemCheck += delegate (object sender, ItemCheckEventArgs e)
            {
                if ((e.NewValue==CheckState.Unchecked) && (listCOD3.keyItem(e.Index)==cboCOD3.Text) && (CTLM.Status==EnumStatus.EDIT || CTLM.Status==EnumStatus.ADDNEW))
                {
                    MessageBox.Show("Cannot remove Main COD3 from COD3 list", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.NewValue = CheckState.Checked;
                    return;
                }
                if (CTLM.Status == EnumStatus.EDIT)
                    lstEmailAliases.UpdateEspackControl();
            };
            txtSurname1.Validating += TxtSurname1_Validating;

            //this.FormClosed += FUsers_FormClosed;
        }

        private bool changeAliases = false;
        private void ListCOD3_Changed(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue.ToString() != "")
            {
                changeAliases = true;
            }
        }


        private void TxtSurname1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            {
                //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                if (CTLM.Status == EnumStatus.ADDNEW)
                {
                    if (txtUserCode.Text == "" && txtSurname1.Text != "")
                    {
                        var _possible = CT.ToASCII(txtName.Text.Substring(0, 1) + txtSurname1.Text).ToLower();
                        gDatos.AdoCon.Open();
                        SqlCommand query = new SqlCommand("SELECT 0 from Users where UserCode=@UserCode; ", gDatos.AdoCon);
                        query.Parameters.AddWithValue("@UserCode", "");
                        for (var i = 2; i < 100; i++)
                        {
                            query.Parameters["@UserCode"].Value = _possible;
                            var reader = query.ExecuteReader();
                            if (!reader.HasRows)
                                break;
                            _possible = _possible + i.ToString();
                            reader.Close();
                        }
                        gDatos.AdoCon.Close();
                        txtUserCode.Text = _possible;
                    }
                }
            };
        }

        private void CTLM_AfterButtonClick(object sender, CTLMEventArgs e)
        {
            Application.DoEvents();
            if (lstFlags.Text.Split('|').Contains("EMAIL"))
            {
                if (changeAliases)
                {
                    lstEmailAliases.Source("select Address,a2=Address from mail..aliasCAB a where exists( select 0 from dbo.Split(a.COD3,'|') where valor in (select valor from dbo.Split('" + listCOD3.Value + "','|'))) and dbo.CheckFlag(a.flags,'STATIC')=0 order by address");
                    lstEmailAliases.UpdateEspackControl();
                    Application.DoEvents();
                    changeAliases = false;
                }
            }
            else
            {
                lstEmailAliases.DataSource = null;
                changeAliases = true;
            }
        }
    }
}

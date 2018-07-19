using AccesoDatos;
using AccesoDatosNet;
using CommonTools;
using CTLMantenimiento.Properties;
using EspackControls;
using EspackDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EspackFormControlsNS
{
    public enum CTLMControlTypes { PK, NoAddPK, AddUppSearch, AddUppNoSearch, AddSearch, AddNoSearch, UppSearch, UppNoSearch, Search, NoSearch}
    public enum CTLMButtonsEnum { btnAdd, btnUpp, btnDel, btnSearch, btnCancel, btnOk, btnNext, btnPrev, btnFirst, btnLast }
    public partial class CTLMantenimiento : UserControl
    {
        //private variables
        private EnumStatus mStatus;
        private List<EspackControl> mListItems = new List<EspackControl>();
        private DA mDA;
        private ToolStrip ToolStrip;
        private ToolStripButton btnAdd;
        private ToolStripButton btnUpp;
        private ToolStripButton btnDel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnSearch;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrev;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnCancel;
        private ToolStripButton btnOk;
        private StatusStrip mDefaultStatusStrip = null;

        //Events
        public event EventHandler<CTLMEventArgs> BeforeButtonClick; //launched when one of the buttons is pressed but before the action
        public event EventHandler<CTLMEventArgs> AfterButtonClick; //lauched after the action when one of the buttons is pressed
        protected virtual void OnBeforeButtonClick(CTLMEventArgs e)
        {
            EventHandler<CTLMEventArgs> handler = BeforeButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAfterButtonClick(CTLMEventArgs e)
        {
            EventHandler<CTLMEventArgs> handler = AfterButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Properties
        public cAccesoDatosNet Conn //the connection object
        {
            get
            {
                return mDA.Conn;
            }
            set
            {
                mDA.Conn = value;
            }
        }
        //? i dont remember what is this for
        public ToolStripStatusLabel MsgStatusInfoLabel { get; set; }
        public ToolStripStatusLabel MsgStatusLabel { get; set; }
        public ToolStripProgressBar StatusBarProgress { get; set; }
        //Properties with SPs but in string format, we will use this when assigning a SP_Controls by its name, it will assign the properties to the Insert, Update and Delete commands of the mDA connection
        public string sSPAdd //Insert
        {
            set
            {
                if (value != "") mDA.sSPAdd = value;
            }
            get
            {
                return mDA.sSPAdd;
            }
        }

        public string sSPUpp//Update
        {
            set
            {
                if (value != "") mDA.sSPUpp = value;
            }
            get
            {
                return mDA.sSPUpp;
            }
        }

        public string sSPDel//Delete
        {
            set
            {
                if (value != "") mDA.sSPDel = value;
            }
            get
            {
                return mDA.sSPDel;
            }
        }

        public SP SPAdd
        {
            get
            {
                return mDA.InsertCommand;
            }
        }
        public SP SPUpp
        {
            get
            {
                return mDA.UpdateCommand;
            }
        }
        public SP SPDel
        {
            get
            {
                return mDA.DeleteCommand;
            }
        }

        public bool ADD { get => sSPAdd != ""; }
        public bool UPP { get => sSPUpp != ""; }
        public bool DEL { get => sSPDel != ""; }
        //Property which holds the table name.
        public string DBTable { set; get; } //property to assign table name

        //Items List property, it holds all the Form items besides with extra ones needed 
        public List<EspackControl> CTLMItems
        {
            get
            {
                return mListItems;
            }
        }
        public List<EspackControl> CTLMItemsNotLinked
        {
            get
            {
                return mListItems.Where(i => i.ExtraDataLink == null).ToList();
            }
        }
        public EspackControl CTLMItem(string dbFieldName)
        {
            return mListItems.Where(x => x.DBField == dbFieldName).FirstOrDefault();
        }
        //ItemsPK List, it holds the PK items of the Items list
        public List<EspackControl> ItemsPK
        {
            get
            {
                return mListItems.Where(x => x.PK == true).ToList();
            }
        }

        public List<EspackControl> EDGVCs
        {
            get
            {
                return mListItems.Where(x => x is EspackDataGridViewControl).ToList();
            }
        }
        //ItemsDBField list of items with DBField
        public List<EspackControl> ItemsDBField
        {
            get
            {
                return mListItems.Where(x => x.DBField != "" && x.DBField != null).ToList();
            }
        }
        public List<EspackControl> ItemsOrdered
        {
            get
            {
                return mListItems.Where(x => x.Order != 0 && x.ExtraDataLink == null).OrderBy(o => Math.Abs(o.Order)).ToList();
            }
        }
        public List<EspackControl> ItemsFormControl
        {
            get
            {
                return mListItems.Where(x => !(x is EspackString)).ToList();
            }
        }

        public int RSPosition
        {
            get
            {
                return mDA.SelectRS.DS != null ? mDA.SelectRS.Index : 0;
            }
        }
        public bool EOF
        {
            get
            {
                return mDA.SelectRS.DS != null ? mDA.SelectRS.EOF : false;
            }
        }
        public bool BOF
        {
            get
            {
                return mDA.SelectRS.DS != null ? mDA.SelectRS.BOF : false;
            }
        }
        public void MoveNext()
        {
            if (Status == EnumStatus.NAVIGATE && !EOF)
            {
                mDA.SelectRS.MoveNext();
                ShowRSValues();
            }
        }
        public void MovePrevious()
        {
            if (Status == EnumStatus.SEARCH && !BOF)
            {
                mDA.SelectRS.MovePrevious();
                ShowRSValues();
            }
        }
        //public List<VSGrid.CtlVSGrid> VSGrids;

        //private int mRsPosition;
        //public int RSPosition { get; private set; } = -1;
        public void setRSPosition(int position)
        {
            mDA.SelectRS.Move(position, false);
            ShowRSValues();
        }
        //Query property, it constructs the SQL Query using the Items and the DBTable properties

        public string Query
        {
            get
            {
                string lSQL = "";
                List<string> lQueryFields = new List<string>();
                List<string> lWhereFields = new List<string>();
                List<string> lOrderFields = new List<string>();

                foreach (EspackControl Item in CTLMItems)
                {
                    if (Item.ExtraDataLink == null)
                    {
                        string lDelimiter = CT.IsNumericType(Item.DBFieldType) ? "" : "'";
                        if (Item.DBField != "" && Item.DBField != null)
                        {
                            lQueryFields.Add(Item.DBField);
                        }
                        if ((Item.PK || Item.Search) && Item.DBField != "")
                        {
                            string lValue = "@" + Item.DBField;
                            lWhereFields.Add("isnull(" + Item.DBField + ",'') like  '%'+convert(varchar(max),isnull(" + lValue + ",''))+'%'");
                        }
                    }
                }
                foreach (EspackControl lItem in ItemsOrdered)
                {
                    lOrderFields.Add(lItem.DBField + (lItem.Order > 0 ? "" : " DESC"));
                }
                //construnt the select clause
                lSQL = "Select " + string.Join(", ", lQueryFields) + " from " + DBTable;
                //add the where clause
                string lWhere = string.Join(" and ", lWhereFields);
                lWhere = lWhere != "" ? " Where " + lWhere : "";
                lSQL = lSQL + lWhere;
                //add the order clause
                string lOrder = string.Join(", ", lOrderFields);
                lOrder = lOrder != "" ? " Order by " + lOrder : "";
                lSQL = lSQL + lOrder;

                return lSQL;
            }
        }

        /*
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                //foreach (ToolStripItem item in Items)
                //{
                //    if (item.GetType().ToString() == "System.Windows.Forms.ToolStripButton")
                //    {
                //        item.Enabled = value;
                //    }
                //}
                base.Enabled = value;
            }
        }
        //Status property, it enables or disables the buttons for each status
        */


        public EnumStatus Status
        {

            get
            {
                return mStatus;
            }
        }
        // Clear property, if is true, after executing a procedure correctly, the form is cleared
        public bool Clear { set; get; }
        // Requery property, if its true, after executing a procedure correctly, the record is requeried
        public bool ReQuery { set; get; }
        //statusBar property, with the key shortcuts and the info panel
        public StatusStrip CTLStatusBar
        {
            get
            {
                return mDefaultStatusStrip;
            }
        }
        //public Form Parent { get; set; }

        //Constructor
        public CTLMantenimiento()
        {
            InitializeComponent();
            this.ToolStrip.Renderer = new MySR();
            this.ToolStrip.ItemClicked += CTLM_Click; // new System.EventHandler(CTLM_Click);
            this.AfterButtonClick += DefaultEventButtonClick;
            this.BeforeButtonClick += DefaultEventButtonClick;
            ParentChanged += CTLMantenimiento_ParentChanged;
            SetStatus(EnumStatus.SEARCH);
            mDA = new DA();
        }

        private void CTLMantenimiento_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
                Parent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        }

        public void SetStatus(EnumStatus value)
        {
            mStatus = value;
            switch (value)
            {
                case EnumStatus.ADDNEW:
                    {
                        btnAdd.Enabled = false;
                        btnUpp.Enabled = false;
                        btnDel.Enabled = false;
                        btnSearch.Enabled = false;
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = true;
                        break;
                    }
                case EnumStatus.EDIT:
                    {
                        btnAdd.Enabled = false;
                        btnUpp.Enabled = false;
                        btnDel.Enabled = false;
                        btnSearch.Enabled = true;
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = true;
                        break;
                    }
                case EnumStatus.DELETE:
                    {
                        btnAdd.Enabled = false;
                        btnUpp.Enabled = false;
                        btnDel.Enabled = false;
                        btnSearch.Enabled = true;
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = true;
                        break;
                    }
                case EnumStatus.SEARCH:
                    {
                        btnAdd.Enabled = true;
                        btnUpp.Enabled = false;
                        btnDel.Enabled = false;
                        btnSearch.Enabled = true;
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = true;
                        break;
                    }
                case EnumStatus.NAVIGATE:
                    {
                        btnAdd.Enabled = false;
                        btnUpp.Enabled = true;
                        btnDel.Enabled = true;
                        btnSearch.Enabled = true;
                        btnFirst.Enabled = true;
                        btnPrev.Enabled = true;
                        btnNext.Enabled = true;
                        btnLast.Enabled = true;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = true;
                        break;
                    }
                case EnumStatus.ADDGRIDLINE:
                case EnumStatus.EDITGRIDLINE:
                    {
                        btnAdd.Enabled = false;
                        btnUpp.Enabled = false;
                        btnDel.Enabled = false;
                        btnSearch.Enabled = false;
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnCancel.Enabled = true;
                        btnOk.Enabled = false;
                        break;
                    }

            }
            ItemsFormControl.ForEach(i => i.SetStatus(value));
            if (CTLStatusBar != null)
            {
                if (MsgStatusLabel != null)
                {
                    MsgStatusLabel.Text = value.ToString();
                }
            }
        }


        //Methods

        public void Start() //this method should be called always after the CTLM definition, it should be the last method to be called. 
                            //1st it provides the SQL query to the DataAdapter and assigns the parameters to its SelectRS object
                            //2nd it assigns the Type to each Item added.
        {
            KeyEnabler();
            mDA.SQL = Query;
            foreach (EspackControl Item in CTLMItems)
            {
                if (Item.PK || Item.Search)
                {
                    mDA.SelectRS.AddControlParameter("@" + Item.DBField, Item);
                }
                if (Item is EspackComboBox)
                {
                    Item.ClearEspackControl();
                }
            }
            foreach (EspackControl Item in ItemsDBField)
            {
                if (Item.DBFieldType != null)
                    Item.DBFieldType = mDA.Schema[Item.DBField].DataType;
            }
            foreach (EspackControl EDGVC in EDGVCs)
            {
                ((EspackDataGridViewControl)EDGVC).MsgStatusLabel = MsgStatusInfoLabel;
                ((EspackDataGridViewControl)EDGVC).Start();
            }
            SetStatus(EnumStatus.SEARCH);

        }
        //KeyEnabler, adds the parent_keydown method to the parent form keydown events
        public void KeyEnabler()
        {
            this.Parent.KeyDown += Parent_KeyDown;
        }
        //eventhandler
        private void Parent_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    if (btnSearch.Enabled)
                    {
                        Button_Click("btnSearch");
                        Button_Click("btnOk");
                    }
                    break;
                case Keys.F2:
                    if (btnOk.Enabled)
                    {
                        Button_Click("btnOk");
                    }
                    break;
                case Keys.F7:
                    if (btnUpp.Enabled)
                    {
                        Button_Click("btnUpp");
                    }
                    break;
                case Keys.F10:
                    if (btnAdd.Enabled)
                    {
                        Button_Click("btnAdd");
                    }
                    break;
                case Keys.Escape:
                    Button_Click("btnCancel");
                    break;
            }
        }

        // Methods
        //Default event handler for CTLM
        private void DefaultEventButtonClick(object source, CTLMEventArgs e)
        {
            return;
        }



        public void AddItem(object pDataContainer, string pDBField, CTLMControlTypes pControType = CTLMControlTypes.AddUppNoSearch,int pOrder = 1, object pDefValue = null, string pSPAddParamName = "", string pSPUppParamName = "", string pSPDelParamName = "", EspackExtraData pExtraDataLink = null)
        {
            switch (pControType)
            {
                case CTLMControlTypes.PK:
                    AddItem(pDataContainer, pDBField, ADD, UPP, DEL, pOrder, true, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.NoAddPK:
                    AddItem(pDataContainer, pDBField, false, UPP, DEL, pOrder, true, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.AddUppNoSearch:
                    AddItem(pDataContainer, pDBField, ADD, UPP, false, pOrder, false, false, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.AddUppSearch:
                    AddItem(pDataContainer, pDBField, ADD, UPP, false, pOrder, false, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.AddNoSearch:
                    AddItem(pDataContainer, pDBField, ADD, false, false, pOrder, false, false, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.AddSearch:
                    AddItem(pDataContainer, pDBField, ADD, false, false, pOrder, false, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.UppNoSearch:
                    AddItem(pDataContainer, pDBField, false, false, true, pOrder, false, false, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.UppSearch:
                    AddItem(pDataContainer, pDBField, false, false, true, pOrder, false, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.NoSearch:
                    AddItem(pDataContainer, pDBField, false, false, false, pOrder, false, false, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
                case CTLMControlTypes.Search:
                    AddItem(pDataContainer, pDBField, false, false, false, pOrder, false, true, pDefValue, pSPAddParamName, pSPUppParamName, pSPDelParamName, pExtraDataLink);
                    break;
            }
        }

        //AddControl: adds a Control to the Control collection

        public void AddItem(object pDataContainer, string pDBField = "")
        {
            AddItem(pDataContainer, pDBField, CTLMControlTypes.NoSearch);
        }
        public void AddItem(EspackDataGridViewControl VS)
        {
            AddItem(VS, "", CTLMControlTypes.NoSearch);
        }

        public void AddItem(object pDataContainer, string pDBField = "", bool pAdd = false, bool pUpp = false, bool pDel = false, int pOrder = 0, bool pPK = false,
            bool pSearch = false, object pDefValue = null, string pSPAddParamName = "", string pSPUppParamName = "", string pSPDelParamName = "", EspackExtraData pExtraDataLink = null)
        {
            EspackControl lControl;
            if (pDataContainer is string)
            {
                lControl = new EspackString() { Value = pDataContainer };
                lControl.EspackControlType = EspackControlTypeEnum.STATIC;
            }
            else
            {
                lControl = (EspackControl)pDataContainer;
                if (lControl is Control)
                    ((Control)lControl).TabIndex = CTLMItems.Count;
            }

            lControl.DBField = pDBField;
            if (pDBField != "")
            {
                lControl.Add = pAdd;
                lControl.Upp = pUpp;
                lControl.Del = pDel;
                lControl.Order = pOrder;
                lControl.PK = pPK;
                lControl.Search = pSearch;
                lControl.EspackControlType |= EspackControlTypeEnum.CTLM;
            }

            lControl.DefaultValue = pDefValue;
            if (lControl is EspackFormControlCommon)
            {
                ((EspackFormControlCommon)lControl).ParentDA = mDA;
                ((EspackFormControlCommon)lControl).ParentConn = Conn;
                ((EspackFormControlCommon)lControl).IsCTLMOwned = true;
            }
            mListItems.Add(lControl);
            if (lControl is Control && ! (lControl is EspackDataGridViewControl))
                ((Control)lControl).Enabled = (pAdd && Status == EnumStatus.ADDNEW) || (pUpp && Status == EnumStatus.EDIT) || (pDel && Status == EnumStatus.DELETE) || (pSearch && Status == EnumStatus.SEARCH);

            if (pExtraDataLink != null)
            {
                pExtraDataLink.AddLinkedItem(lControl);
            }
            else
            {
                if (pAdd)
                {
                    mDA.InsertCommand.AddControlParameter("@" + (pSPAddParamName == "" ? pDBField : pSPAddParamName), lControl);
                }
                if (pUpp)
                {
                    mDA.UpdateCommand.AddControlParameter("@" + (pSPUppParamName == "" ? pDBField : pSPUppParamName), lControl);
                }
                if (pDel)
                {
                    mDA.DeleteCommand.AddControlParameter("@" + (pSPDelParamName == "" ? pDBField : pSPDelParamName), lControl);
                }
            }
        }
        //adds the status strip to the parent form.
        public void AddDefaultStatusStrip()
        {
            mDefaultStatusStrip = new StatusStrip();
            //SizeType lSize = new SizeType(118, 17);
            int lLabelWidth = 75;
            mDefaultStatusStrip.Items.Add(new ToolStripStatusLabel("F2: OK") { Width = lLabelWidth, AutoSize = false });
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            mDefaultStatusStrip.Items.Add(new ToolStripStatusLabel("F7: Edit") { Width = lLabelWidth, AutoSize = false });
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            mDefaultStatusStrip.Items.Add(new ToolStripStatusLabel("F8: Search") { Width = lLabelWidth, AutoSize = false });
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            mDefaultStatusStrip.Items.Add(new ToolStripStatusLabel("F10: New") { Width = lLabelWidth, AutoSize = false });
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            mDefaultStatusStrip.Items.Add(new ToolStripStatusLabel("ESC: Clear") { Width = lLabelWidth, AutoSize = false });
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            MsgStatusInfoLabel = (new ToolStripStatusLabel("") { AutoSize = true });
            mDefaultStatusStrip.Items.Add(MsgStatusInfoLabel);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            StatusBarProgress = new ToolStripProgressBar() { Size = new Size(100, mDefaultStatusStrip.Height), Visible = false };
            mDefaultStatusStrip.Items.Add(StatusBarProgress);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());
            MsgStatusLabel = (new ToolStripStatusLabel(string.Empty));
            //MsgStatusLabel.Padding= new Padding((int)(this.Size.Width - 10), 0, 0, 0);
            MsgStatusLabel.Alignment = ToolStripItemAlignment.Right;
            MsgStatusLabel.Spring = true;
            mDefaultStatusStrip.Items.Add(MsgStatusLabel);
            this.FindForm().Controls.Add(mDefaultStatusStrip);
            this.FindForm().KeyPreview = true;
        }
        public void StatusBarProgressMarqueeStart()
        {
            StatusBarProgress.Style = ProgressBarStyle.Marquee;
            StatusBarProgress.Value = 0;
            StatusBarProgress.Minimum = 0;
            StatusBarProgress.Maximum = 50;
            StatusBarProgress.MarqueeAnimationSpeed = 50;
            StatusBarProgress.Visible = true;
        }
        public void StatusBarProgressStop()
        {
            StatusBarProgress.Style = ProgressBarStyle.Continuous;
            StatusBarProgress.MarqueeAnimationSpeed = 0;
            StatusBarProgress.Visible = false;
        }
        //ShowRSValues shows the actual values of actual record of mDA.SelectRS  
        delegate Task ShowRSValuesDelegate();
        delegate Task ClearValuesDelegate(bool PK = false);
        //public async Task ShowRSValues()
        //{
        //    foreach (EspackControl lItem in CTLMItems)
        //    {
        //        await lItem.UpdateEspackControl();
        //    }
        //}
        //public async Task ShowRSValues()
        //{
        //    try
        //    {
        //        foreach (EspackControl lItem in CTLMItems)
        //        {
        //            if (lItem is Control)
        //            {
        //                if (((Control)lItem).InvokeRequired)
        //                {
        //                    ShowRSValuesDelegate a = new ShowRSValuesDelegate(ShowRSValues);
        //                    this.Invoke(a);
        //                }
        //                else
        //                {
        //                    await lItem.UpdateEspackControl();
        //                }
        //            }
        //            else
        //            {
        //                await lItem.UpdateEspackControl();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //ClearValues Cleans the form and fills it with the default values 
        public void ShowRSValues()
        {
            foreach (EspackControl lItem in CTLMItemsNotLinked)
                try
                {
                    lItem.UpdateEspackControl();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("ERROR in Item {0}: {1}", lItem.Name, ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        public void ClearValues(bool PK = false)
        {
            //setRSPosition(0);
            if (PK)
                CTLMItemsNotLinked.Where(r => r.PK == false).ToList().ForEach(i =>
                {
                    try
                    {
                        i.ClearEspackControl();
                    } catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            else
                CTLMItemsNotLinked.ForEach(i =>
                {
                    try
                    {
                        i.ClearEspackControl();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "";

        }

        //What happens when you click OK
        private void Click_OK(string pButtonName = "btnOk")
        {
            Click_OK((CTLMButtonsEnum)Enum.Parse(typeof(CTLMButtonsEnum), pButtonName));
        }
        private void Click_OK(CTLMButtonsEnum pButtonName = CTLMButtonsEnum.btnOk)
        {
            switch (Status)
            {
                case EnumStatus.SEARCH:
                    {
                        mDA.SelectRS.Open();
                        if (mDA.SelectRS.EOF)
                        {
                            MessageBox.Show("No data found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                            SetStatus(EnumStatus.SEARCH);
                            ClearValues();
                            return;
                        }
                        try
                        {
                            ShowRSValues();
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        SetStatus(EnumStatus.NAVIGATE);
                        if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = mDA.SelectRS.RecordCount.ToString() + " Records returned by search.";
                        break;
                    }
                case EnumStatus.ADDNEW:
                    {
                        if (mDA.Conn.State == ConnectionState.Open)
                            mDA.Conn.Close();
                        mDA.InsertCommand.Execute();
                        if (mDA.InsertCommand.LastMsg.Substring(0, 2) != "OK")
                        {
                            MessageBox.Show("ERROR:" + mDA.InsertCommand.LastMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "ERROR:" + mDA.InsertCommand.LastMsg;
                            return;
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        if (Clear)
                        {
                            ClearValues();
                        }
                        else
                        {
                            if (ItemsPK.Count == 1 && mDA.InsertCommand.LastMsg.Length > 2) //if the msg is longer that 2 for example "OK/12345" it assigns the right side to the first key control
                            {
                                ItemsPK[0].Value = mDA.InsertCommand.LastMsg.Substring(3);
                            }
                        }
                        if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "Record added successfully :D!";
                        if (ReQuery)
                        {
                            ClearValues(true);
                            SetStatus(EnumStatus.SEARCH);
                            Click_OK(pButtonName);
                        }

                        if (EDGVCs.Count != 0)
                        {
                            SetStatus(EnumStatus.EDIT);
                            ((Control)EDGVCs[0]).Focus();
                        }
                        else
                            SetStatus(EnumStatus.SEARCH);
                        break;
                    }
                case EnumStatus.EDIT:
                    {
                        if (mDA.Conn.State == ConnectionState.Open)
                            mDA.Conn.Close();
                        mDA.UpdateCommand.Execute();
                        if (mDA.UpdateCommand.LastMsg.Substring(0, 2) != "OK")
                        {
                            MessageBox.Show("ERROR:" + mDA.UpdateCommand.LastMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "ERROR:" + mDA.UpdateCommand.LastMsg;
                            return;
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        if (Clear)
                        {
                            ClearValues();
                        }
                        if (ReQuery)
                        {
                            ClearValues(true);
                            SetStatus(EnumStatus.SEARCH);
                            Click_OK(pButtonName); ;
                        }
                        SetStatus(EnumStatus.SEARCH);
                        if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "Record updated successfully ;D!";
                        break;
                    }
                case EnumStatus.DELETE:
                    {
                        if (mDA.Conn.State == ConnectionState.Open)
                            mDA.Conn.Close();
                        mDA.DeleteCommand.Execute();
                        if (mDA.DeleteCommand.LastMsg.Substring(0, 2) != "OK")
                        {
                            MessageBox.Show("ERROR:" + mDA.DeleteCommand.LastMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StatusMsg("ERROR:" + mDA.DeleteCommand.LastMsg);
                            return;
                        }
                        ClearValues();
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));

                        SetStatus(EnumStatus.SEARCH);
                        if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = "Record deleted successfully X(!";
                        break;
                    }
            }
        }

        public void StatusMsg(string lMsg)
        {
            if (CTLStatusBar != null)
            {
                if (MsgStatusInfoLabel != null) MsgStatusInfoLabel.Text = lMsg;
            }
        }
        public void Button_Click(string pButtonName)
        {
            Button_Click((CTLMButtonsEnum)Enum.Parse(typeof(CTLMButtonsEnum), pButtonName));
        }
        public void Button_Click(CTLMButtonsEnum pButtonName) //lauched when clicked any button
        {
            try
            {
                CTLMEventArgs lCTLMEventArgs = new CTLMEventArgs(pButtonName);
                OnBeforeButtonClick(lCTLMEventArgs); //launched BeforeButtonClick Event
                if (lCTLMEventArgs.Cancel) { return; }
                switch (pButtonName)
                {
                    case CTLMButtonsEnum.btnAdd:
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName)); //Launched AfterButtonClick Event
                        SetStatus(EnumStatus.ADDNEW);
                        CTLMItems.Where(x => x.DefaultValue != null).ToList().ForEach(x => x.Value = x.DefaultValue);
                        break;
                    case CTLMButtonsEnum.btnUpp:
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName)); //Launched AfterButtonClick Event
                        SetStatus(EnumStatus.EDIT);
                        break;
                    case CTLMButtonsEnum.btnDel:
                        if (MessageBox.Show("This will delete the actual record. Are you sure?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            SetStatus(EnumStatus.DELETE);
                            Click_OK(pButtonName);
                        }
                        break;
                    case CTLMButtonsEnum.btnSearch:
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        SetStatus(EnumStatus.SEARCH);
                        break;
                    case CTLMButtonsEnum.btnCancel:
                        ClearValues();
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        SetStatus(EnumStatus.SEARCH);
                        break;
                    case CTLMButtonsEnum.btnOk:
                        Click_OK(pButtonName);
                        break;
                    case CTLMButtonsEnum.btnNext:
                        if (mDA.SelectRS.State == RSState.Open)
                        {
                            try
                            {
                                setRSPosition(RSPosition + 1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        break;
                    case CTLMButtonsEnum.btnPrev:
                        if (mDA.SelectRS.State == RSState.Open)
                        {
                            try
                            {
                                setRSPosition(RSPosition - 1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        break;
                    case CTLMButtonsEnum.btnFirst:
                        if (mDA.SelectRS.State == RSState.Open)
                        {
                            try
                            {
                                setRSPosition(0);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        break;
                    case CTLMButtonsEnum.btnLast:
                        if (mDA.SelectRS.State == RSState.Open)
                        {
                            try
                            {
                                setRSPosition(mDA.SelectRS.RecordCount - 1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        OnAfterButtonClick(new CTLMEventArgs(pButtonName));
                        break;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //eventhandler 
        private void CTLM_Click(object sender, ToolStripItemClickedEventArgs e)  //the Click Event
        {
            Button_Click(e.ClickedItem.Name);
        }

        private void InitializeComponent()
        {
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnUpp = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnOk = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnUpp,
            this.btnDel,
            this.toolStripSeparator1,
            this.btnSearch,
            this.toolStripSeparator2,
            this.btnFirst,
            this.btnPrev,
            this.btnNext,
            this.btnLast,
            this.toolStripSeparator3,
            this.btnCancel,
            this.btnOk});
            this.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.ToolStrip.Size = new System.Drawing.Size(300, 31);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "CTLMToolContainer";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::CTLMantenimiento.Properties.Resources.add24;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 28);
            this.btnAdd.Text = "Add a new element.";
            // 
            // btnUpp
            // 
            this.btnUpp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpp.Image = global::CTLMantenimiento.Properties.Resources.edit24;
            this.btnUpp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpp.Name = "btnUpp";
            this.btnUpp.Size = new System.Drawing.Size(28, 28);
            this.btnUpp.Text = "Edit current element.";
            // 
            // btnDel
            // 
            this.btnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDel.Image = global::CTLMantenimiento.Properties.Resources.del24;
            this.btnDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(28, 28);
            this.btnDel.Text = "Delete current element.";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearch.Image = global::CTLMantenimiento.Properties.Resources.search24;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 28);
            this.btnSearch.Text = "Search.";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = global::CTLMantenimiento.Properties.Resources.first24;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(28, 28);
            this.btnFirst.Text = "First Element.";
            // 
            // btnPrev
            // 
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = global::CTLMantenimiento.Properties.Resources.prev24;
            this.btnPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(28, 28);
            this.btnPrev.Text = "Previous Element.";
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::CTLMantenimiento.Properties.Resources.next24;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 28);
            this.btnNext.Text = "Next Element.";
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = global::CTLMantenimiento.Properties.Resources.last24;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(28, 28);
            this.btnLast.Text = "Last Element.";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = global::CTLMantenimiento.Properties.Resources.cancel24;
            this.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 28);
            this.btnCancel.Text = "Clear / Cancel.";
            // 
            // btnOk
            // 
            this.btnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOk.Image = global::CTLMantenimiento.Properties.Resources.ok24;
            this.btnOk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(28, 28);
            this.btnOk.Text = "Confirm action.";
            // 
            // CTLMantenimiento
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.ToolStrip);
            this.Name = "CTLMantenimiento";
            this.Size = new System.Drawing.Size(300, 31);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

    //Events for the control
    public class CTLMEventArgs : EventArgs
    {
        private CTLMButtonsEnum mButtonClick;
        public string ButtonClick
        {
            get
            {
                return mButtonClick.ToString();
            }
        }
        public bool Cancel { get; set; }
        public CTLMEventArgs(string pButtonClick)
        {
            mButtonClick = (CTLMButtonsEnum)Enum.Parse(typeof(CTLMButtonsEnum), pButtonClick);
            Cancel = false;
        }
        public CTLMEventArgs(CTLMButtonsEnum pButtonClick)
        {
            mButtonClick = pButtonClick;
            Cancel = false;
        }

    }

    public class MySR : ToolStripSystemRenderer
    {
        public MySR() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }

}



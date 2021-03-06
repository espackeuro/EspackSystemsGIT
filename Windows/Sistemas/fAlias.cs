﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistemas
{
    public partial class fAlias : Form
    {
        //
        public fAlias()
        {
            InitializeComponent();
            
            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "MAIL..pAddAliasCAB";
            CTLM.sSPUpp = "MAIL..pUppAliasCAB";
            CTLM.sSPDel = "MAIL..pDelAliasCAB";
            CTLM.DBTable = "MAIL..aliasCAB";

            //Header
            CTLM.AddItem(txtAddress, "Address", true, true, true, 1, true, true);
            CTLM.AddItem(txtLocalPart, "Local_Part");
            CTLM.AddItem(txtDomain, "Domain");
            CTLM.AddItem(lstFlags, "flags", true, true, false, 0, false, true);
            CTLM.AddItem(lstCOD3, "COD3", true, true, false, 0, false, true);

            lstFlags.Source("select codigo,descFlagEng from mail..flags where tabla='aliasCAB' order by DescFlagEng");
            lstCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "MAIL..pAddAliasDET";
            VS.sSPUpp = "";
            VS.sSPDel = "MAIL..pDelAliasDet";
            VS.DBTable = "MAIL..aliasDET";
            VS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Details
            VS.AddColumn("Address", txtAddress, "@Address", "", "@Address",pVisible: false);
            VS.AddColumn("Destinations", "gotoAddress", "@gotoAddress", "", "@gotoAddress", false, false, false, pWidth: 200, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: "select email from mail..vEmailListAll order by email");



            //VS Definitions
            VSExceptions.Conn = Values.gDatos;
            VSExceptions.sSPAdd = "MAIL..pAddAliasExceptionsDET";
            VSExceptions.sSPUpp = "";
            VSExceptions.sSPDel = "MAIL..pDelAliasExceptionsDet";
            VSExceptions.DBTable = "MAIL..aliasExceptionsDET";
            VSExceptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //Details
            VSExceptions.AddColumn("Address", txtAddress, "@Address", "", "@Address", pVisible: false);
            VSExceptions.AddColumn("Exceptions", "gotoAddress", "@gotoAddress", "", "@gotoAddress", false, false, false, pWidth: 200, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: "select email from mail..vEmailListAll order by email");

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.AddItem(VSExceptions);
            CTLM.Start();
            

        }

      
    }
}

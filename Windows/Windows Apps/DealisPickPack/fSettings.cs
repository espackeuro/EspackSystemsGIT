﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using CommonToolsWin;
using static DealerPickPack.Program;
using static CommonToolsWin.CTWin;

namespace DealerPickPack
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
            
            try
            {
                cboPrinters.Enabled = true;
                // [dvalles] 20210923: Change this query to be the same as in the scanner (no more ETIQUETAS..datosEmpresa)
                //cboPrinters.Source("select Codigo from ETIQUETAS..datosEmpresa where descripcion like '%|DPP|%' order by cmp_integer", Values.gDatos);
                cboPrinters.Source($"select Code from MiscData where cod3='{Values.COD3}' and dbo.checkFlag(flags,'LABELPRINTER')=1 order by code", Values.gDatos);
                cboPrinters.Value = cSettings.readSetting("labelPrinter");
                Values.LabelPrinterAddress = cboPrinters.Value.ToString();
                cboPrinters.SelectedIndexChanged += CboPrinters_SelectedIndexChanged;
            } catch
            {
                cboPrinters.Enabled = false;
            }
            cboWarehouse.Enabled = true;
            cboWarehouse.Source("select cod3,Descripcion from general..sedes_servicios S inner join general..Sedes se on se.Codigo = S.CodigoSede where codigoServicio = 'DEALERPICKPACK' order by Descripcion",Values.gDatos);
            cboWarehouse.Value = cSettings.readSetting("COD3");
            Values.COD3 = cboWarehouse.Value.ToString();

            cboWarehouse.SelectedIndexChanged += CboWarehouse_SelectedIndexChanged;
        }

        private void CboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cSettings.writeSetting("COD3", cboWarehouse.Value.ToString());
            Values.COD3 = cboWarehouse.Value.ToString();
            fMain.Text = string.Format("{0} - {1} Warehouse", VersionNumber, Values.COD3);

            CloseFormsByName(eCloseFormsMethod.ALLEXCEPT,"fMainDPP|fSettings");
        }

        private void CboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            cSettings.writeSetting("labelPrinter", cboPrinters.Value.ToString());
            Values.LabelPrinterAddress = cboPrinters.Value.ToString();
        }
    }
}

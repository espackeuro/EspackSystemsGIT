using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplistica
{
    public partial class fSimpleReferences : Form
    {
        public fSimpleReferences()
        {
            InitializeComponent();
            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pAdd_Referencias";
            CTLM.sSPUpp = "pUpp_Referencias";
            CTLM.sSPDel = "pDel_Referencias";
            CTLM.DBTable = "(Select r.* from Referencias r inner join Servicios s on s.codigo=r.servicio where s.cod3='" + Values.COD3 + "' and dbo.CheckFlag(s.flags,'SIMPLE')=1) a";

            //Header
            CTLM.AddItem(txtReference, "base", true, true, true, 1, true, true);
            CTLM.AddItem(cboServicio, "Servicio", true, true, true, 0, true, true);
            CTLM.AddItem(txtDescription, "descripcion", true, true, false, 0, false, true);
            CTLM.AddItem(txtFase4, "fase4", true, true, false, 0, false, false, 1);
            CTLM.AddItem(txtPrice, "precio", true, true, false, 0, false, false, 0);
            CTLM.AddItem(txtPeso, "peso", true, true, false, 0, false, false, 0);
            CTLM.AddItem(txtMin, "PU_Min", true, true, false, 0, false, false, 0);
            CTLM.AddItem(txtMax, "PU_Max", true, true, false, 0, false, false, 0);
            CTLM.AddItem(txtNotes, "Notas", true, true, false, 0, false, false, "");
            CTLM.AddItem(lstFlags, "Flags", true, true, false, 0, false, true);
            CTLM.AddItem(txtSupplier, "proveedor", true, true, false, 0, false, true,pDefValue:"0");

            //empty header values
            CTLM.AddItem("", "prefix", true, true, true, 0, true, pDefValue:"");
            CTLM.AddItem("", "suffix", true, true, true, 0, true, pDefValue: "");
            CTLM.AddItem("N", "aduana", true, true, false, pDefValue: "N");
            CTLM.AddItem("CARD", "tipo", true, true, false, pDefValue: "CARD");
            CTLM.AddItem("0", "MP_Min", true, true, false, pDefValue: "0");
            CTLM.AddItem("0", "MP_Max", true, true, false, pDefValue: "0");
            CTLM.AddItem("1", "qty_pzas_card", true, true, false, pDefValue: "1");
            CTLM.AddItem("1", "qty_pzas_call", true, true, false, pDefValue: "1");
            CTLM.AddItem("", "loc2", true, true, false, pDefValue: "");
            CTLM.AddItem("", "muelle", true, true, false, pDefValue: "");
            //CTLM.AddItem("0", "proveedor", true, true, false, pDefValue: "0");
            CTLM.AddItem("0", "precio_trasvase", true, true, false, pDefValue: "0");
            CTLM.AddItem("", "prefix_serv", true, true, false, pDefValue: "");
            CTLM.AddItem("", "base_serv", true, true, false, pDefValue: "");
            CTLM.AddItem("", "suffix_serv", true, true, false, pDefValue: "");

            //fields
            cboServicio.Source("Select Codigo,Nombre from Servicios where dbo.CheckFlag(flags,'SIMPLE')=1 and cod3='" + Values.COD3 + "' order by codigo", txtDesServicio);
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='Referencias' and dbo.CheckFlag(flags,'SIMPLE')=1");


            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.Start();
        }
    }
}

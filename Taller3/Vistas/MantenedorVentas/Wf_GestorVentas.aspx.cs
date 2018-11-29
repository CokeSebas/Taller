using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Mitaller
{
    public partial class Wf_GestorVentas : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarClientes();
            llenarEstadoRep();

            if (cbbClientes.SelectedItem.ToString() == "Seleccione")
            {
                cbbEstadoRep.Items.Clear();
                llenarEstadoRep();
            }

            if (cbbEstadoRep.SelectedItem.ToString() == "Seleccione")
            {
                cbbEstadoRep.Items.Clear();
                llenarEstadoRep();
            }
        }

        public void Msgbox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='Javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Rep);", true);
        }

        public void llenarClientes()
        {
            cbbClientes.Items.Add("Seleccione");
            registros = objConec.llenarCombo("cliente", "idcliente");
            while (registros.Read())
            {
                cbbClientes.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarVehiculos()
        {
            string rutCli = cbbClientes.SelectedItem.ToString();
            cbbPatente.Items.Add("Seleccione");
            registros = objConec.llenarComboVehiculo(rutCli);
            while (registros.Read())
            {
                cbbPatente.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarEstadoRep()
        {
            cbbEstadoRep.Items.Add("Seleccione");
            registros = objConec.llenarCombo("estadoreparacion", "idestadrep");
            while (registros.Read())
            {
                cbbEstadoRep.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void mostrarCalendarioFecIni()
        {
            txtFecIni.Text = dtpFecInic.SelectedDate.ToString("dd/M/yyyy");
            dtpFecInic.Visible = false;
        }

        public void mostrarCalendarioFecFinal()
        {
            txtFecFin.Text = dtpFecFin.SelectedDate.ToString("dd/M/yyyy");
            dtpFecFin.Visible = false;
        }

        public void guardarReparacion()
        {
            string rutCli = cbbClientes.SelectedItem.ToString();
            string patente = cbbPatente.SelectedItem.ToString();
            string estado = cbbEstadoRep.SelectedItem.ToString();
            valida = objConec.guardarReparacion(txtDescip.Text, txtDiag.Text, txtFecIni.Text, txtFecFin.Text, patente, rutCli, txtPresup.Text, estado, txtHoraInic.Text, txtHoraFin.Text);
            if (valida == "ok")
            {
                //Msgbox("Sucursal Registrada con Exito", this.Page, this);
                cbbClientes.SelectedIndex = -1;
                cbbPatente.Items.Clear();
                txtDescip.Text = string.Empty;
                txtDiag.Text = string.Empty;
                txtFecFin.Text = string.Empty;
                txtFecFin.Text = string.Empty;
                txtPresup.Text = string.Empty;
                txtHoraInic.Text = string.Empty;
                txtHoraFin.Text = string.Empty;
                InsertCorrecto();
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }


        protected void cbbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarVehiculos();
        }

        protected void cbbPatente_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFecInic.Visible = true;
        }

        protected void dtpFecInic_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecIni();
            dtpFecFin.Visible = true;
        }

        protected void dtpFecFin_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecFinal();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarReparacion();
        }
    }
}
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.MantenedorVentas
{
    public partial class finalizarReparacion : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            llenarReparacion();
            if (cbbReparacion.SelectedItem.ToString() == "Seleccione")
            {
                cbbReparacion.Items.Clear();
                llenarReparacion();
            }

            llenarTipoDcto();
            if (cbbTipoDoc.SelectedItem.ToString() == "Seleccione")
            {
                cbbTipoDoc.Items.Clear();
                llenarTipoDcto();
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
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Venta);", true);
        }

        public void llenarReparacion()
        {
            cbbReparacion.Items.Add("Seleccione");
            registros = objConec.llenarCombo("reparacion", "idreparacion");
            while (registros.Read())
            {
                cbbReparacion.Items.Add(registros.GetValue(13).ToString());
            }
        }

        public void llenarTipoDcto()
        {
            cbbTipoDoc.Items.Add("Seleccione");
            cbbTipoDoc.Items.Add("Boleta");
            cbbTipoDoc.Items.Add("Factura");
        }

        public void datosReparacion()
        {
            string repar = cbbReparacion.SelectedItem.ToString();
            registros = objConec.datosReparacionLista(repar);
            if (registros.HasRows)
            {
                while (registros.Read())
                {
                    txtNombCli.Text = registros["nombre"].ToString();
                    txtNombCli.ReadOnly = true;
                    txtNeto.Text = registros["neto"].ToString();
                    txtTotal.Text = registros["total"].ToString();
                }

            }
        }

        public void mostrarCalendarioFecingreso()
        {
            txtFecIng.Text = dtpFecIng.SelectedDate.ToString("dd/M/yyyy");
            dtpFecIng.Visible = false;
        }

        public void guardarVenta()
        {
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            string tipoDct = "0";
            if (cbbTipoDoc.SelectedItem.ToString() == "Boleta")
            {
                tipoDct = "1";
            }
            else
            {
                tipoDct = "2";
            }
            objConec.guardarVenta(nroDcto, txtNombCli.Text, txtFecIng.Text, txtTotal.Text, tipoDct);
            InsertCorrecto();
        }

        protected void cbbReparacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            datosReparacion();
            dtpFecIng.Visible = true;
        }

        protected void dtpFecIng_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecingreso();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarVenta();
            txtTotal.Text = string.Empty;
            txtFecIng.Text = string.Empty;
            txtNeto.Text = string.Empty;
            txtNombCli.Text = string.Empty;
            cbbReparacion.SelectedIndex = -1;
        }
    }
}
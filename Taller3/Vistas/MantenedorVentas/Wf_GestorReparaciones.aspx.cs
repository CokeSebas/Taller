using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Mitaller
{
    public partial class Wf_GestorReparaciones : System.Web.UI.Page
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
            llenarTipoServicio();
            if (cbbTipoServicio.SelectedItem.ToString() == "Seleccione")
            {
                cbbTipoServicio.Items.Clear();
                llenarTipoServicio();
            }
            llenarServicios();
            if (cbbServicio.SelectedItem.ToString() == "Seleccione")
            {
                cbbServicio.Items.Clear();
                llenarServicios();
            }
            llenarRepuestos();
            if (cbbRepuesto.SelectedItem.ToString() == "Seleccione")
            {
                cbbRepuesto.Items.Clear();
                llenarRepuestos();
            }
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(DetRep);", true);
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

        public void llenarTipoServicio()
        {
            cbbTipoServicio.Items.Add("Seleccione");
            registros = objConec.llenarCombo("tiposervicios", "idtiposerv");
            while (registros.Read())
            {
                cbbTipoServicio.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarServicios()
        {
            cbbServicio.Items.Add("Seleccione");
            registros = objConec.llenarCombo("servicios", "idservicios");
            while (registros.Read())
            {
                cbbServicio.Items.Add(registros.GetValue(2).ToString());
            }
        }

        public void llenarRepuestos()
        {
            cbbRepuesto.Items.Add("Seleccione");
            registros = objConec.llenarCombo("repuestos", "idrepuesto");
            while (registros.Read())
            {
                cbbRepuesto.Items.Add(registros.GetValue(2).ToString());
            }
        }

        public void datosReparacion()
        {
            string repar = cbbReparacion.SelectedItem.ToString();
            registros = objConec.datosReparacion(repar);
            if (registros.HasRows)
            {
                while (registros.Read())
                {
                    txtDiag.Text = registros["diagnostico"].ToString();
                    txtDiag.ReadOnly = true;
                }
                
            }
        }

        public void Msgbox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='Javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());

        }

        public void addServicio()
        {
            string servicio = cbbServicio.SelectedItem.ToString();
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            objConec.addServicio(nroDcto, "0", servicio);
            mostrarServicios();
        }

        public void quitarServicio()
        {
            string servicio = cbbServicio.SelectedItem.ToString();
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            objConec.quitarServicio(nroDcto, servicio);
            mostrarServicios();
        }

        public void addRepuesto()
        {
            string repuesto = cbbRepuesto.SelectedItem.ToString();
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            objConec.addServicio(nroDcto, repuesto, "0");
            mostrarRepuestos();
        }

        public void quitarRepuesto()
        {
            string repuesto = cbbRepuesto.SelectedItem.ToString();
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            objConec.quitarRepuesto(nroDcto, repuesto);
            mostrarRepuestos();
        }

        private void mostrarServicios()
        {
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            DataSet tabla = new DataSet();
            objConec.datosServicios(nroDcto).Fill(tabla);
            dgvServicios.DataSource = tabla.Tables[0].DefaultView;
            dgvServicios.DataBind();
        }

        private void mostrarRepuestos()
        {
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            DataSet tabla = new DataSet();
            objConec.datosGrillaRepuesto(nroDcto).Fill(tabla);
            dgvRepuestos.DataSource = tabla.Tables[0].DefaultView;
            dgvRepuestos.DataBind();
        }

        public void guardarReparacion()
        {
            string nroDcto = cbbReparacion.SelectedItem.ToString();
            valida = objConec.Actualizar("reparacion", "estado = 4", "nrodcto = '" + nroDcto + "'");
        }


        protected void cbbReparacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            datosReparacion();
        }

        protected void btnAddServ_Click(object sender, EventArgs e)
        {
            addServicio();            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarReparacion();
            InsertCorrecto();
        }

        protected void btnElimServ_Click(object sender, EventArgs e)
        {
            quitarServicio();
        }

        protected void btnAddRepues_Click(object sender, EventArgs e)
        {
            addRepuesto();
        }

        protected void btnElimRepue_Click(object sender, EventArgs e)
        {
            quitarRepuesto();
        }
    }
}
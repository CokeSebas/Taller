using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.MantenedorUsuarios
{
    public partial class Proveedores : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";
        string condic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarRegion();
            MostrarDatos();
            if (cbbRegion.SelectedItem.ToString() == "Seleccione")
            {
                cbbRegion.Items.Clear();
                llenarRegion();
            }
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Prov);", true);
        }

        public void DeleteCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(ProvElim);", true);
        }

        public void llenarRegion()
        {
            cbbRegion.Items.Add("Seleccione");
            cbbProvincia.Items.Add("Seleccione");
            cbbComuna.Items.Add("Seleccione");
            registros = objConec.llenarCombo("regiones", "region_id");
            while (registros.Read())
            {
                cbbRegion.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarProvincia()
        {
            cbbProvincia.Items.Clear();
            cbbProvincia.Items.Add("Seleccione");
            string reg = cbbRegion.SelectedItem.ToString();
            registros = objConec.llenarComboProvincias(reg);
            while (registros.Read())
            {
                cbbProvincia.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarComunas()
        {
            cbbComuna.Items.Clear();
            cbbComuna.Items.Add("Seleccione");
            string prov = cbbProvincia.SelectedItem.ToString();
            registros = objConec.llenarComboCiud(prov);

            if (registros.Read())
            {
                while (registros.Read())
                {
                    cbbComuna.Items.Add(registros.GetValue(1).ToString());
                }
            }
            else
            {
                Msgbox("vacio", this.Page, this);
            }

        }

        public void Msgbox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='Javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());

        }

        private void MostrarDatos()
        {
            DataSet tabla = new DataSet();
            objConec.datosProveedor().Fill(tabla);
            dgvProveedores.DataSource = tabla.Tables[0].DefaultView;
            dgvProveedores.DataBind();
        }

        public void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            System.Web.UI.Page pageToRender = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

        public void guardarProveedor()
        {
            string region = cbbRegion.SelectedItem.ToString();
            string prov = cbbProvincia.SelectedItem.ToString();
            string ciud = cbbComuna.SelectedItem.ToString();
            valida = objConec.guardarProveedor(txtFecIngr.Text, txtRutProv.Text, txtNombProv.Text, txtDirect.Text, txtGiro.Text, txtFono.Text, txtCeluProv.Text, txtEmailProv.Text, region, prov, ciud);

            if (valida == "ok")
            {
                //Msgbox("Sucursal Registrada con Exito", this.Page, this);
                cbbRegion.SelectedIndex = -1;
                cbbProvincia.Items.Clear();
                cbbRegion.Items.Clear();
                txtFecIngr.Text = string.Empty;
                txtRutProv.Text = string.Empty;
                txtNombProv.Text = string.Empty;
                txtDirect.Text = string.Empty;
                txtGiro.Text = string.Empty;
                txtFono.Text = string.Empty;
                txtCeluProv.Text = string.Empty;
                txtEmailProv.Text = string.Empty;
                InsertCorrecto();
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarProveedor(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("proveedor", "rutprov", condic);

            if (valida == "ok")
            {
                DeleteCorrecto();
                cbbRegion.SelectedIndex = -1;
                cbbProvincia.Items.Clear();
                cbbRegion.Items.Clear();
                txtFecIngr.Text = string.Empty;
                txtRutProv.Text = string.Empty;
                txtNombProv.Text = string.Empty;
                txtDirect.Text = string.Empty;
                txtGiro.Text = string.Empty;
                txtFono.Text = string.Empty;
                txtCeluProv.Text = string.Empty;
                txtEmailProv.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("Proveedores", dgvProveedores);
        }

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarProvincia();
        }

        protected void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComunas();
        }

        protected void txtDirect_TextChanged(object sender, EventArgs e)
        {
            dtpFecIng.Visible = true;
        }

        protected void dtpFecIng_SelectionChanged(object sender, EventArgs e)
        {
            txtFecIngr.Text = dtpFecIng.SelectedDate.ToString("dd/M/yyyy");
            dtpFecIng.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarProveedor();
            dgvProveedores.DataSource = null;
            MostrarDatos();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            eliminarProveedor(txtRutProv.Text);
            dgvProveedores.DataSource = null;
            MostrarDatos();
        }
    }
}
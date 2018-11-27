using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;
using Taller3.Clases;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Mitaller
{
    public partial class Wf_MantSucursal : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";
        string campos = "";
        string condic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarRegion();
            MostrarDatos();
        }

        public void llenarRegion()
        {
            cbbRegion.Items.Add("Seleccione");
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
            objConec.datosSucursal().Fill(tabla);
            dgvSucursales.DataSource = tabla.Tables[0].DefaultView;
            dgvSucursales.DataBind();
        }

        public void guardarSucursal()
        {
            string region = cbbRegion.SelectedItem.ToString();
            string prov = cbbProvincia.SelectedItem.ToString();
            string ciud = cbbComuna.SelectedItem.ToString();
            valida = objConec.guardarSucursal(txtNombSuc.Text, txtDirecSuc.Text, txtTelefonoSuc.Text, region, prov, ciud);

            if (valida == "ok")
            {
                Msgbox("Sucursal Registrada con Exito", this.Page, this);
                cbbRegion.SelectedIndex = -1;
                cbbProvincia.Items.Clear();
                cbbRegion.Items.Clear();
                txtDirecSuc.Text = string.Empty;
                txtNombSuc.Text = string.Empty;
                txtTelefonoSuc.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarSucursal(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("sucursal", "nombsucursal", condic);

            if (valida == "ok")
            {
                Msgbox("Sucursal Eliminada", this.Page, this);
                txtDirecSuc.Text = string.Empty;
                txtNombSuc.Text = string.Empty;
                txtTelefonoSuc.Text = string.Empty;
                cbbRegion.SelectedIndex = -1;
                cbbProvincia.Items.Clear();
                cbbRegion.Items.Clear();
            }
            else
            {
                Msgbox(valida, this.Page, this);
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

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarSucursal();
            dgvSucursales.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarSucursal(txtNombSuc.Text);
            dgvSucursales.DataSource = null;
            MostrarDatos();
        }

        protected void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

            llenarProvincia();
        }

        protected void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComunas();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("Sucursales", dgvSucursales);
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
    } 

}


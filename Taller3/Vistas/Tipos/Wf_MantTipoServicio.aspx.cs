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

namespace Mitaller
{
    public partial class Wf_MantTipoServicio : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";
        string campos = "";
        string condic = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            llenarTiposServicio();
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
            objConec.LlenarGrilla("servicios").Fill(tabla);
            dgvServicios.DataSource = tabla.Tables[0].DefaultView;
            dgvServicios.DataBind();
        }

        public void llenarTiposServicio()
        {
            cbbTipoServ.Items.Add("Seleccione");
            registros = objConec.llenarCombo("tiposervicios", "descriptiposerv");
            while (registros.Read())
            {
                cbbTipoServ.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void guardarServ()
        {
            campos = "SEQ_SERVICIOS.NEXTVAL, '" + txtCodServ.Text + "', '"+txtServicio.Text
                + "', (SELECT idtiposerv FROM tiposervicios WHERE descriptiposerv = '"+cbbTipoServ.SelectedItem.ToString()+"'), '"+
                txtCostoServ.Text+"'";

            valida = objConec.Insert("servicios", campos);

            if (valida == "ok")
            {
                Msgbox("Servicio Registrado con Exito", this.Page, this);
                txtCodServ.Text = string.Empty;
                txtCostoServ.Text = string.Empty;
                txtServicio.Text = string.Empty;
                cbbTipoServ.SelectedIndex = -1;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarServ(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("servicios", "codserv", condic);

            if (valida == "ok")
            {
                Msgbox("Servicio Eliminado", this.Page, this);
                txtCodServ.Text = string.Empty;
                txtCostoServ.Text = string.Empty;
                txtServicio.Text = string.Empty;
                cbbTipoServ.SelectedIndex = -1;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarServ();
            dgvServicios.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarServ(txtCodServ.Text);
            dgvServicios.DataSource = null;
            MostrarDatos();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("Tipo Servicios", dgvServicios);
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
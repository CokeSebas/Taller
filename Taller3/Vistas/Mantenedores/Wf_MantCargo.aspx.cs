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
    public partial class Wf_MantCargo : System.Web.UI.Page
    {
        Conexion objConec = new Conexion();
        string valida = "";
        string campos = "";
        string condic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDatos();
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
            objConec.LlenarGrilla("cargo").Fill(tabla);
            dgvCargos.DataSource = tabla.Tables[0].DefaultView;
            dgvCargos.DataBind();
        }

        public void guardarCargo()
        {
            string cargo = txtCargo.Text;
            campos = "seq_cargo.NEXTVAL, '" + cargo + "'";
            
            valida = objConec.Insert("cargo", campos);

            if (valida == "ok")
            {
                Msgbox("Cargo Registrado", this.Page, this);
                txtCargo.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarCargo(string nuevo, string cond)
        {
            campos = "descripcargo = '" + nuevo + "'";
            condic = "descripcargo = '" + cond + "'";
            valida = objConec.Actualizar("cargo", campos, condic);

            if (valida == "ok"){
                Msgbox("Cargo Modificado", this.Page, this);
                txtCargo.Text = string.Empty;
            }else{
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarCargo(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("cargo", "descripcargo", condic);

            if (valida == "ok")
            {
                Msgbox("Cargo Eliminado", this.Page, this);
                txtCargo.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarCargo();
            dgvCargos.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarCargo(txtCargo.Text);
            dgvCargos.DataSource = null;
            MostrarDatos();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("Tipo Cargos", dgvCargos);
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
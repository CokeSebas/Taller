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
    public partial class Wf_MantColor : System.Web.UI.Page
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
            objConec.LlenarGrilla("color").Fill(tabla);
            dgvColores.DataSource = tabla.Tables[0].DefaultView;
            dgvColores.DataBind();
        }

        public void guardarColor()
        {
            string cargo = txtColor.Text;
            campos = "seq_color.NEXTVAL, '" + cargo + "'";

            valida = objConec.Insert("color", campos);

            if (valida == "ok")
            {
                Msgbox("Color Registrada con Exito", this.Page, this);
                txtColor.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarClor(string nuevo, string cond)
        {
            /*campos = "descripbod = '" + nuevo + "'";
            condic = "descripbod= '" + cond + "'";
            valida = objConec.Actualizar("bodega", campos, condic);

            if (valida == "ok")
            {
                Msgbox("Bodega Modificada", this.Page, this);
                txtColor.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }*/
        }

        public void eliminarColor(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("color", "descripcolor", condic);

            if (valida == "ok")
            {
                Msgbox("Color Eliminada", this.Page, this);
                txtColor.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarColor();
            dgvColores.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarColor(txtColor.Text);
            dgvColores.DataSource = null;
            MostrarDatos();
        }

    }
}
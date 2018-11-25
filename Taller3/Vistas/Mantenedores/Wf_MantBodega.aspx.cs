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
    public partial class Wf_MantBodega : System.Web.UI.Page
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
            objConec.LlenarGrilla("bodega").Fill(tabla);
            dgvBodegas.DataSource = tabla.Tables[0].DefaultView;
            dgvBodegas.DataBind();
        }

        public void guardarBodega()
        {
            string cargo = txtBodega.Text;
            campos = "seq_bodega.NEXTVAL, '" + cargo + "'";

            valida = objConec.Insert("bodega", campos);

            if (valida == "ok")
            {
                Msgbox("Bodega Registrada con Exito", this.Page, this);
                txtBodega.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarBodega(string nuevo, string cond)
        {
            /*campos = "descripbod = '" + nuevo + "'";
            condic = "descripbod= '" + cond + "'";
            valida = objConec.Actualizar("bodega", campos, condic);

            if (valida == "ok")
            {
                Msgbox("Bodega Modificada", this.Page, this);
                txtBodega.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }*/
        }

        public void eliminarBodega(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("bodega", "descripbod", condic);

            if (valida == "ok")
            {
                Msgbox("Bodega Eliminada", this.Page, this);
                txtBodega.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarBodega();
            dgvBodegas.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarBodega(txtBodega.Text);
            dgvBodegas.DataSource = null;
            MostrarDatos();
        }

    }
}

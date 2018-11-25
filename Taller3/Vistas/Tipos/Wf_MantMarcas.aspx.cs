using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Tipos
{
    public partial class Wf_MantMarcas : System.Web.UI.Page
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
            objConec.LlenarGrilla("marca").Fill(tabla);
            dgvMarcas.DataSource = tabla.Tables[0].DefaultView;
            dgvMarcas.DataBind();
        }

        public void guardarMarca()
        {
            string marca = txtMarca.Text;
            campos = "SEQ_MARCA.NEXTVAL, '" + marca + "'";

            valida = objConec.Insert("marca", campos);

            if (valida == "ok")
            {
                Msgbox("Marca Registrada con Exito", this.Page, this);
                txtMarca.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarMarca(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("marca", "descripmarca", condic);

            if (valida == "ok")
            {
                Msgbox("Marca Eliminada", this.Page, this);
                txtMarca.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarMarca();
            dgvMarcas.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarMarca(txtMarca.Text);
            dgvMarcas.DataSource = null;
            MostrarDatos();
        }
    }
}
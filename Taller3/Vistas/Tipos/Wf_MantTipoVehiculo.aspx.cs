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
    public partial class Wf_MantTipoVehiculo : System.Web.UI.Page
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
            objConec.LlenarGrilla("tipoVehiculo").Fill(tabla);
            dgvVehiculos.DataSource = tabla.Tables[0].DefaultView;
            dgvVehiculos.DataBind();
        }

        public void guardarTipoVeh()
        {
            campos = "SEQ_MARCA.NEXTVAL, '" + txtCodVeh.Text + "', '"+txtTipoVeh.Text+"'";

            valida = objConec.Insert("tipoVehiculo", campos);

            if (valida == "ok")
            {
                Msgbox("Tipo Vehiculo Registrado con Exito", this.Page, this);
                txtTipoVeh.Text = string.Empty;
                txtCodVeh.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void eliminarTipoVeh(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("tipoVehiculo", "tipovehiculo", condic);

            if (valida == "ok")
            {
                Msgbox("Tipo Vehiculo Eliminado", this.Page, this);
                txtTipoVeh.Text = string.Empty;
                txtCodVeh.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarTipoVeh();
            dgvVehiculos.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarTipoVeh(txtTipoVeh.Text);
            dgvVehiculos.DataSource = null;
            MostrarDatos();
        }
    }
}
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Mantenedores
{
    public partial class Wf_MantProvincias : System.Web.UI.Page
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
            objConec.LlenarGrilla("provincia").Fill(tabla);
            dgvProvincias.DataSource = tabla.Tables[0].DefaultView;
            dgvProvincias.DataBind();
        }

        public void guardarProvincia()
        {
            //string cargo = txtRegion.Text + ;

            campos = "seq_provincia.NEXTVAL, '" + txtProvincia.Text + "', (SELECT region_id FROM regiones WHERE region_nombre = '" + cbbRegion.SelectedItem.ToString() + "')";

            valida = objConec.Insert("provincia", campos);

            if (valida == "ok")
            {
                Msgbox("Provincia Registrada con Exito", this.Page, this);
                cbbRegion.SelectedIndex = -1;
                txtProvincia.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarProvincia(string nuevo, string cond)
        {
            /*campos = "descripbod = '" + nuevo + "'";
            condic = "descripbod= '" + cond + "'";
            valida = objConec.Actualizar("bodega", campos, condic);

            if (valida == "ok")
            {
                Msgbox("Region Modificada", this.Page, this);
                txtOrdinal.Text = string.Empty;
                txtRegion.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }*/
        }

        public void eliminarProvincia(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("provincia", "provincia_nombre", condic);

            if (valida == "ok")
            {
                Msgbox("Provincia Eliminada", this.Page, this);
                txtProvincia.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarProvincia();
            dgvProvincias.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarProvincia(txtProvincia.Text);
            dgvProvincias.DataSource = null;
            MostrarDatos();
        }
    }
}
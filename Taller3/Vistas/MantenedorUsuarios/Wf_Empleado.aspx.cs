using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using Taller3.Clases;

namespace Mitaller
{
    public partial class Wf_Empleados : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";
        string campos = "";
        string condic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDatos();
            llenarCargo();
        }

        public void llenarCargo()
        {
            ddListCargo.Items.Add("Seleccione");
            registros = objConec.llenarCombo("cargo", "idCargo");
            while (registros.Read())
            {
                ddListCargo.Items.Add(registros.GetValue(1).ToString());
            }
        }

        private void MostrarDatos()
        {

            /*DataSet tabla = new DataSet();
            objConec.ListaPrueba().Fill(tabla);
            GridView1.DataSource = tabla.Tables[0].DefaultView;
            GridView1.DataBind();*/

        }

        protected void ddListCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //boton mostrar
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //boton eliminar
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //boton actualizar
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // ingresar
        }
    }
}
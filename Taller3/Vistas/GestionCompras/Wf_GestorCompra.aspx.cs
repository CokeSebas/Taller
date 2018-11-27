using Oracle.DataAccess.Client;
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
    public partial class Wf_GestorCompra : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";
        string campos = "";
        string condic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarProv();
            llenarEmp();
           

        }

        public void llenarProv()
        {
            cboProveedor.Items.Add("Seleccione");
            registros = objConec.llenarCombo("Proveedor", "idProveedor");
            while (registros.Read())
            {
                cboProveedor.Items.Add(registros.GetValue(3).ToString());
            }
        }

        public void llenarEmp()
        {
            cboEmpleado.Items.Add("Seleccione");
            registros = objConec.llenarCombo("Empleado", "idEmp");
            while (registros.Read())
            {
                cboEmpleado.Items.Add(registros.GetValue(3).ToString() + " " + registros.GetValue(4).ToString());
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
            objConec.LlenarGrilla("ordped").Fill(tabla);
            grilla.DataSource = tabla.Tables[0].DefaultView;
            grilla.DataBind();
        }

        public void guardarPedido()
        {
            //string cargo = txtRegion.Text + ;

            campos = "seq_ordped.NEXTVAL, '" + txtCiudad.Text + "', (SELECT provincia_id FROM provincia WHERE provincia_nombre = '" + cbbProvincia.SelectedItem.ToString() + "')";

            valida = objConec.Insert("comuna", campos);

            if (valida == "ok")
            {
                Msgbox("Ciudad Registrada con Exito", this.Page, this);
                cbbRegion.SelectedIndex = -1;
                cbbProvincia.Items.Clear();
                txtCiudad.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }


        protected void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cboProd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        
    }
}
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Mitaller
{
    public partial class Wf_MantEmpresa : System.Web.UI.Page
    {
        Conexion objConec = new Conexion();
        Empresa objEmpre = new Empresa();
        public OracleDataReader registros;
        string valida = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            llenarRegion();
            datosEmpresa();
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Empr);", true);
        }

        public void DeleteCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(EmprElim);", true);
        }

        public void llenarRegion()
        {
            cbbRegion.Items.Add("Seleccione");
            cbbProvincia.Items.Add("Seleccione");
            cbbComuna.Items.Add("Seleccione");
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

        public void datosEmpresa()
        {
            registros = objConec.datosEmpresa();
            if (registros.HasRows)
            {
                while (registros.Read())
                {
                    txtRutEmpr.Text = registros["rut_empresa"].ToString();
                    /*txtNombEmpr.Text = registros["nombre_empresa"].ToString();
                    txtGiroEmpr.Text = registros["giro_empresa"].ToString();
                    txtDirecEmpre.Text = registros["Direccion"].ToString();
                    txtTelefonoEmpr.Text = registros["telefono"].ToString();
                    txtEmailEmpre.Text = registros["correo"].ToString();
                    cbbRegion.SelectedItem.Text = registros["region_nombre"].ToString();
                    cbbProvincia.SelectedItem.Text = registros["provincia_nombre"].ToString();
                    cbbComuna.SelectedItem.Text = registros["comuna"].ToString();*/
                }
                btnActualizar.Visible = true;
                txtRutEmpr.ReadOnly = true;
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

        public void actualizarDatos()
        {
            objEmpre.RutEmpr = txtRutEmpr.Text;
            objEmpre.NombEmpr = txtNombEmpr.Text;
            objEmpre.GiroEmpr = txtGiroEmpr.Text;
            objEmpre.TelefonoEmpr = txtTelefonoEmpr.Text;
            objEmpre.CorreoEmpr = txtEmailEmpre.Text;
            objEmpre.DirecEmpr = txtDirecEmpre.Text;
            objEmpre.Region = cbbRegion.SelectedItem.ToString();
            objEmpre.Provincia = cbbProvincia.SelectedItem.ToString();
            objEmpre.Comuna = cbbComuna.SelectedItem.ToString();

            valida = objEmpre.modificaEmpr();


            if (valida == "ok"){
                Msgbox("Datos Empresa Modificado", this.Page, this);
                //success.Visible = true;
                //limpiar();
            }else{
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }
        }

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarProvincia();
        }

        protected void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComunas();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarDatos();
        }
    }
}
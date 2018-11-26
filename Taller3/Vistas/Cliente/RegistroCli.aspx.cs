using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Cliente
{
    public partial class RegistroCli : System.Web.UI.Page
    {
        Conexion objConec = new Conexion();
        Usuarios objUss = new Usuarios();
        public OracleDataReader registros;
        string valida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int x = new Random().Next(1, 3);

            success.Visible = false;
            llenarRegion();
        }

        public void Msgbox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='Javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());

        }

        public void llenarRegion()
        {
            /*if (cbbRegion.SelectedItem.ToString() != "Seleccione")
            {
                cbbRegion.Items.Clear();
            }*/

            //cbbRegion.Items.Clear();
            success.Visible = true;
            cbbRegion.Items.Add("Seleccione");
            cbbProvincia.Items.Add("Seleccione");
            cbbComuna.Items.Add("Seleccione");
            registros = objConec.llenarCombo("regiones", "region_id");
            while (registros.Read())
            {
                cbbRegion.Items.Add(registros.GetValue(1).ToString());
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
                Msgbox("vacio",this.Page, this);
            }
            
        }

        public void guardarCliente()
        {
            objUss.RutClie = txtRutCli.Text;
            objUss.NombClie = txtNombCli.Text;
            string [] apellidos= txtApCli.Text.Trim().Split(' ');
            string appat = apellidos[0];
            string apmat = apellidos[1];
            objUss.ApPatClie = appat;
            objUss.ApMatClie = apmat;
            objUss.Direccion = txtDirect.Text;
            objUss.Region = cbbRegion.SelectedItem.ToString();
            objUss.Provincia = cbbProvincia.SelectedItem.ToString();
            objUss.Ciudad = cbbComuna.SelectedItem.ToString();
            objUss.Fono = txtFono.Text;
            objUss.Celular = txtFono.Text;
            objUss.Email = txtEmailCli.Text;
            objUss.Usser = txtUssrCli.Text;
            objUss.Pass = txtPassCli.Text;

            valida = objUss.guardarCliente();

            if (valida == "ok")
            {
                Msgbox("Usuario Registrado", this.Page, this);
                success.Visible = true;

                limpiar();
            }
            else
            {
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }
            
        }

        public void limpiar()
        {
            txtRutCli.Text = string.Empty;
            txtNombCli.Text = string.Empty;
            txtApCli.Text = string.Empty;
            txtDirect.Text = string.Empty;
            txtEmailCli.Text = string.Empty;
            txtFono.Text = string.Empty;
            txtCeluCli.Text = string.Empty;
            txtPassCli.Text = string.Empty;
            txtUssrCli.Text = string.Empty;
            cbbRegion.Items.Clear();
            llenarRegion();
            cbbProvincia.Items.Clear();
            cbbComuna.Items.Clear();

        }

        protected void Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarComunas();
        }

        protected void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarProvincia();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarCliente();
            Server.Transfer("../../Default.aspx", true);
            Response.Write("Bienvenido : " + objUss.NombClie +" "+objUss.ApPatClie+" "+objUss.ApPatClie );
        }
    }
}
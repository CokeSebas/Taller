using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Cliente
{
    public partial class RegistrarCliente : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        Usuarios objUss = new Usuarios();
        Vehiculo objVeh = new Vehiculo();
        public OracleDataReader registros;
        string valida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarRegion();
            llenarColor();
            llenarMarca();
            llenarTipoVeh();

            if (cbbRegion.SelectedItem.ToString() == "Seleccione")
            {
                cbbRegion.Items.Clear();
                llenarRegion();
            }
            if (cbbColor.SelectedItem.ToString() == "Seleccione")
            {
                cbbColor.Items.Clear();
                llenarColor();
            }
            if (cbbMarca.SelectedItem.ToString() == "Seleccione")
            {
                cbbMarca.Items.Clear();
                llenarMarca();
            }
            if (cbbTipoVeh.SelectedItem.ToString() == "Seleccione")
            {
                cbbTipoVeh.Items.Clear();
                llenarTipoVeh();
            }
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Cli);", true);
        }

        public void ModCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(CliMod);", true);
        }

        public void DeleteCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(CliElim);", true);
        }

        public void EditCliente()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(CliEdit);", true);
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
            cbbRegion.Items.Add("Seleccione");
            cbbProvincia.Items.Add("Seleccione");
            cbbComuna.Items.Add("Seleccione");
            registros = objConec.llenarCombo("regiones", "region_id");
            while (registros.Read())
            {
                cbbRegion.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarMarca()
        {
            cbbMarca.Items.Add("Seleccione");
            registros = objConec.llenarCombo("marca", "codmarca");
            while (registros.Read())
            {
                cbbMarca.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarTipoVeh()
        {
            cbbTipoVeh.Items.Add("Seleccione");
            registros = objConec.llenarCombo("tipovehiculo", "id_tipovehiculo");
            while (registros.Read())
            {
                cbbTipoVeh.Items.Add(registros.GetValue(2).ToString());
            }
        }

        public void llenarColor()
        {
            cbbColor.Items.Add("Seleccione");
            registros = objConec.llenarCombo("color", "codcolor");
            while (registros.Read())
            {
                cbbColor.Items.Add(registros.GetValue(1).ToString());
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

        public void guardarCliente()
        {
            objUss.RutClie = txtRutUsser.Text;
            objUss.NombClie = txtNombUsser.Text;
            string[] apellidos = txtApUsser.Text.Trim().Split(' ');
            string appat = apellidos[0];
            string apmat = apellidos[1];
            objUss.ApPatClie = appat;
            objUss.ApMatClie = apmat;
            objUss.Direccion = txtDirect.Text;
            objUss.Region = cbbRegion.SelectedItem.ToString();
            objUss.Provincia = cbbProvincia.SelectedItem.ToString();
            objUss.Ciudad = cbbComuna.SelectedItem.ToString();
            objUss.Fono = txtFono.Text;
            objUss.Celular = txtCeluCli.Text;
            objUss.Email = txtEmailCli.Text;
            /*objUss.Usser = txtUssrCli.Text;
            objUss.Pass = txtPassCli.Text;*/

            valida = objUss.guardarCliente();
            guardarVehiculo();

            if (valida == "ok")
            {
                InsertCorrecto();
                limpiar();
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }

        }
        public void guardarVehiculo()
        {
            objVeh.Patente = txtPatente.Text;
            objVeh.Modelo = txtModelo.Text;
            objVeh.TipoVehi = cbbTipoVeh.SelectedItem.ToString();
            objVeh.CodMarca = cbbMarca.SelectedItem.ToString();
            objVeh.Color = cbbColor.SelectedItem.ToString();
            objVeh.Anio = txtAnio.Text;
            objVeh.RutCli = txtRutUsser.Text;
            valida = objVeh.guardarVeh();


        }

        public void editarUsuario()
        {
            objUss.RutClie = txtRutUsser.Text;
            objUss.NombClie = txtNombUsser.Text;
            string[] apellidos = txtApUsser.Text.Trim().Split(' ');
            string appat = apellidos[0];
            string apmat = apellidos[1];
            string letra1 = txtNombUsser.Text.Substring(0, 1);
            string letra2 = apmat.Substring(0, 1);
            string codEmp = letra1 + '.' + appat + '.' + letra2;
            objUss.CodEmp = codEmp;
            objUss.ApPatClie = appat;
            objUss.ApMatClie = apmat;
            objUss.Direccion = txtDirect.Text;
            objUss.Region = cbbRegion.SelectedItem.ToString();
            objUss.Provincia = cbbProvincia.SelectedItem.ToString();
            objUss.Ciudad = cbbComuna.SelectedItem.ToString();
            objUss.Fono = txtFono.Text;
            objUss.Celular = txtCeluCli.Text;
            /*objUss.Usser = txtUssrCli.Text;
            objUss.Pass = txtPassCli.Text;*/
            objUss.FecNac = txtFecNac.Text;
            objUss.FecIng = txtFecIngr.Text;
            objUss.FecTer = txtFecTer.Text;

            objUss.Email = txtEmailCli.Text;
            valida = objUss.modificaCliente();

            if (valida == "ok")
            {
                //Msgbox("Usuario Modificado", this.Page, this);
                ModCorrecto();
                limpiar();
            }
            else
            {
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }
        }

        public void datosUsuario()
        {
            string rut = txtRutUsser.Text;
            registros = objConec.datosCliente(rut);
            if (registros.HasRows)
            {
                EditCliente();
                while (registros.Read())
                {
                    string[] nombre = registros["Nombre"].ToString().Trim().Split(' ');
                    string appat = nombre[1];
                    string apmat = nombre[2];
                    txtNombUsser.Text = nombre[0];
                    txtApUsser.Text = appat + " " + apmat;
                    txtDirect.Text = registros["direccion"].ToString();
                    txtFono.Text = registros["fono"].ToString();
                    txtCeluCli.Text = registros["movil"].ToString();
                    txtEmailCli.Text = registros["email"].ToString();
                    cbbRegion.SelectedItem.Text = registros["region_nombre"].ToString();
                    cbbProvincia.SelectedItem.Text = registros["provincia_nombre"].ToString();
                    cbbComuna.SelectedItem.Text = registros["comuna"].ToString();
                }
                btnActualizar.Visible = true;
                btnGuardar.Visible = false;
                txtRutUsser.ReadOnly = true;
                txtFecNac.ReadOnly = true;
                dateFecIngr.Visible = true;
                btnBorrar.Visible = true;
                txtPatente.ReadOnly = false;
                txtModelo.ReadOnly = false;
                txtAnio.ReadOnly = false;
            }
            else
            {
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
                btnBorrar.Visible = false;
            }
        }

        public void limpiar()
        {
            txtRutUsser.Text = string.Empty;
            txtNombUsser.Text = string.Empty;
            txtApUsser.Text = string.Empty;
            txtDirect.Text = string.Empty;
            txtFono.Text = string.Empty;
            txtCeluCli.Text = string.Empty;
            txtEmailCli.Text = string.Empty;
            cbbRegion.SelectedIndex = -1;
            cbbProvincia.SelectedIndex = -1;
            cbbComuna.SelectedIndex = -1;
        }

        public void EliminarCliente()
        {
            string rut = txtRutUsser.Text;
            //Msgbox(objUss.eliminarUsuario(rut), this.Page, Page);
            DeleteCorrecto();
            limpiar();
        }

        public void mostrarCalendarioFecNac()
        {
            //dateFecNac.Visible = true;
            txtFecNac.Text = dateFecNac.SelectedDate.ToString("dd/M/yyyy");
            dateFecNac.Visible = false;
        }

        public void mostrarCalendarioFecIngreso()
        {
            txtFecIngr.Text = dateFecIngr.SelectedDate.ToString("dd/M/yyyy");
            dateFecIngr.Visible = false;
        }

        public void mostrarCalendarioFecTermino()
        {
            txtFecTer.Text = dateFecTer.SelectedDate.ToString("dd/M/yyyy");
            dateFecTer.Visible = false;
        }

        protected void dateFecNac_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecNac();
            dateFecIngr.Visible = true;
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
        }

        protected void txtApUsser_TextChanged(object sender, EventArgs e)
        {
            string cadena = txtApUsser.Text.Trim();
            if (cadena.Contains(" "))
            {
                dateFecNac.Visible = true;
            }
            else
            {
                Msgbox("Debe Ingresar ambos Apellidos", this.Page, Page);
            }

        }

        protected void dateFecIngr_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecIngreso();
            dateFecTer.Visible = true;
        }

        protected void dateFecTer_SelectionChanged(object sender, EventArgs e)
        {
            mostrarCalendarioFecTermino();
        }

        protected void txtRutUsser_TextChanged(object sender, EventArgs e)
        {
            datosUsuario();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            editarUsuario();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }

        protected void txtEmailCli_TextChanged(object sender, EventArgs e)
        {
            txtPatente.ReadOnly = false;
            txtModelo.ReadOnly = false;
            txtAnio.ReadOnly = false;
        }
    }
}
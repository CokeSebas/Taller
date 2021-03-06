﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Mantenedores
{
    public partial class Wf_MantUsuarios : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        Usuarios objUss = new Usuarios();
        public OracleDataReader registros;
        string valida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //cbbTipo.Items.Clear();
            //cbbRegion.Items.Clear();
            llenarRegion();
            llenarTipos();
            if (cbbRegion.SelectedItem.ToString() == "Seleccione")
            {
                cbbRegion.Items.Clear();
                llenarRegion();
            }
            if (cbbTipo.SelectedItem.ToString() == "Seleccione")
            {
                cbbTipo.Items.Clear();
                llenarTipos();
            }
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Emp);", true);
        }

        public void ModCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(EmpMod);", true);
        }

        public void DeleteCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(EmpElim);", true);
        }

        public void EditCliente()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(EmpEdit);", true);
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

        public void llenarTipos()
        {
            cbbTipo.Items.Add("Seleccione");
            registros = objConec.llenarCombo("cargo", "idcargo");
            //registros = objConec.llenarCombo("regiones", "region_id");
            while (registros.Read())
            {
                cbbTipo.Items.Add(registros.GetValue(1).ToString());
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

        public void guardarUsuario()
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
            objUss.Usser = txtUssrCli.Text;
            objUss.Pass = txtPassCli.Text;
            objUss.Nivel = cbbTipo.SelectedItem.ToString();
            objUss.FecNac = txtFecNac.Text;
            objUss.FecIng = txtFecIngr.Text;
            objUss.FecTer = txtFecTer.Text;


            string tipo = cbbTipo.SelectedItem.ToString();
            if (tipo == "Cliente")
            {
                //objUss.Email = txtEmailCli.Text;
                valida = objUss.guardarCliente();
            }
            else
            {
                objUss.Sueldo = txtSueldo.Text;
                valida = objUss.guardarUsuario();
            }

            

            if (valida == "ok")
            {
                Msgbox("Usuario Registrado", this.Page, this);
                limpiar();
                InsertCorrecto();
            }
            else
            {
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }

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
            objUss.Usser = txtUssrCli.Text;
            objUss.Pass = txtPassCli.Text;
            objUss.Nivel = cbbTipo.SelectedItem.ToString();
            objUss.FecNac = txtFecNac.Text;
            objUss.FecIng = txtFecIngr.Text;
            objUss.FecTer = txtFecTer.Text;


            string tipo = cbbTipo.SelectedItem.ToString();
            if (tipo == "Cliente")
            {
                //objUss.Email = txtEmailCli.Text;
                //valida = objUss.ModificarCliente();
            }
            else
            {
                objUss.Sueldo = txtSueldo.Text;
                valida = objUss.modificaUsuario();
            }

            if (valida == "ok"){
                Msgbox("Usuario Modificado", this.Page, this);
                limpiar();
                ModCorrecto();
            }
            else{
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }
        }

        public void datosUsuario()
        {
            string rut = txtRutUsser.Text;
            registros = objConec.datosEmpleado(rut);
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
                    txtFecNac.Text = registros["fenac"].ToString();
                    txtFecIngr.Text = registros["feingreso"].ToString();
                    txtFecTer.Text = registros["fetermino"].ToString();
                    txtDirect.Text = registros["direccion"].ToString();
                    txtFono.Text = registros["fono"].ToString();
                    txtCeluCli.Text = registros["movil"].ToString();
                    txtSueldo.Text = registros["sueldo"].ToString();
                    txtUssrCli.Text = registros["usuario"].ToString();
                    //cbbRegion.SelectedItem = reg
                    //txtUssrCli.Text = registros["usuario"].ToString();
                }
                btnActualizar.Visible = true;
                btnGuardar.Visible = false;
                txtRutUsser.ReadOnly = true;
                txtFecNac.ReadOnly = true;
                dateFecIngr.Visible = true;
                btnBorrar.Visible = true;
            }
            else
            {
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
                btnBorrar.Visible = false;
                Msgbox("Insertar", this.Page, Page);
            }
        }

        public void eliminarEmpleado()
        {
            string rut = txtRutUsser.Text;
            limpiar();
            DeleteCorrecto();
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

        public void tipoUsuario()
        {
            string tipo = cbbTipo.SelectedItem.ToString();
            if (tipo == "Cliente")
            {
                lblSueldo.Visible = false;
                txtSueldo.Visible = false;
                //lblCorreo.Visible = true;
                //txtEmailCli.Visible = true;
            }
            else
            {
                lblSueldo.Visible = true;
                txtSueldo.Visible = true;
                //lblCorreo.Visible = false;
                //txtEmailCli.Visible = false;
            }
        }

        public void limpiar()
        {
            txtRutUsser.Text = string.Empty;
            txtNombUsser.Text = string.Empty;
            txtApUsser.Text = string.Empty;
            //txtEmailCli.Text = string.Empty;
            txtUssrCli.Text = string.Empty;
            txtPassCli.Text = string.Empty;
            txtFono.Text = string.Empty;
            txtFecTer.Text = string.Empty;
            txtCeluCli.Text = string.Empty;
            txtFecIngr.Text = string.Empty;
            txtFecTer.Text = string.Empty;
            txtDirect.Text = string.Empty;
            cbbRegion.SelectedIndex = -1;
            cbbProvincia.SelectedIndex = -1;
            cbbRegion.SelectedIndex = -1;
            cbbTipo.SelectedIndex = -1;
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
            guardarUsuario();
        }

        protected void txtApUsser_TextChanged(object sender, EventArgs e)
        {
            string cadena = txtApUsser.Text.Trim();
            if (cadena.Contains(" ")){
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

        protected void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoUsuario();
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
            eliminarEmpleado();
        }
    }
}
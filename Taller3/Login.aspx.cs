using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3
{
    public partial class Loginaspx : System.Web.UI.Page
    {
        Conexion objConec = new Conexion();
        public string usuario;
        public string pass;
        public bool valida = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Msgbox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='Javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());

        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("Vistas/Cliente/RegistroCli.aspx", true);
            //Response.Redirect("Vistas/Cliente/RegistroCli.aspx");
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            pass = txtPassword.Text;
            valida = objConec.inicioSesion(usuario, pass);

            if (valida == true)
            {
                Server.Transfer("Default.aspx", true);
                //Response.Write("Si Existe");
            }
            else
            {
                Msgbox("Usuario o Password Incorrecto", this.Page, Page);
                txtPassword.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                //Response.Write("No existe");
            }
        }
    }
}
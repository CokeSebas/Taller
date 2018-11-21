using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Taller3.Clases;

namespace Taller3
{
    public partial class About : Page
    {
        Conexion objConec = new Conexion();
        string valida = "";

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Msgbox(objConec.Insert("prueba", "'qwer', 'wq'"), this.Page, this);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            valida = objConec.Actualizar("prueba", "apellido = 'bruna', nombre = 'sebastian' ", "nombre = 'Jorge'");
            if (valida == "ok")
            {
                Msgbox("Modifica",this.Page, this);
            }
            else
            {
                Msgbox(valida,this.Page, this);
                //Response.Write(valida);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            valida = objConec.Eliminar("prueba", "nombre", "123456789");
            if (valida == "ok")
            {
                Msgbox("Elimina", this.Page, this);
            }
            else
            {
                Msgbox(valida, this.Page, this);
                //Response.Write(valida);
            }
        }

        private void MostrarDatos()
        {
            
            DataSet tabla = new DataSet();
            objConec.ListaPrueba().Fill(tabla);            
            GridView1.DataSource = tabla.Tables[0].DefaultView;
            GridView1.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Mitaller
{
    public partial class Wf_MantServicios : System.Web.UI.Page
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
            objConec.LlenarGrilla("tiposervicios").Fill(tabla);
            dgvServicios.DataSource = tabla.Tables[0].DefaultView;
            dgvServicios.DataBind();
        }

        public void guardarServicio()
        {
            string cargo = txtServicio.Text;
            campos = "seq_tiposervicios.NEXTVAL, '" + cargo + "'";

            valida = objConec.Insert("tiposervicios", campos);

            if (valida == "ok")
            {
                Msgbox("Tipo Servicio Registrado con Exito", this.Page, this);
                txtServicio.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarClor(string nuevo, string cond)
        {
            /*campos = "descripbod = '" + nuevo + "'";
            condic = "descripbod= '" + cond + "'";
            valida = objConec.Actualizar("bodega", campos, condic);

            if (valida == "ok")
            {
                Msgbox("Bodega Modificada", this.Page, this);
                txtServicio.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }*/
        }

        public void eliminarServicio(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("tiposervicios", "descriptiposerv", condic);

            if (valida == "ok")
            {
                Msgbox("Tipo servicio Eliminada", this.Page, this);
                txtServicio.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarServicio();
            dgvServicios.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarServicio(txtServicio.Text);
            dgvServicios.DataSource = null;
            MostrarDatos();
        }
    }
}
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
    public partial class Wf_MantTipoMoneda : System.Web.UI.Page
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
            objConec.LlenarGrilla("moneda").Fill(tabla);
            dgvMonedas.DataSource = tabla.Tables[0].DefaultView;
            dgvMonedas.DataBind();
        }

        public void guardarMoneda()
        {
            campos = "seq_moneda.NEXTVAL, '" + txtTipoMoneda.Text + "', '"+txtSimbolo.Text+"', '"+txtFechaValor.Text+"', "+txtValor.Text;

            valida = objConec.Insert("moneda", campos);

            if (valida == "ok")
            {
                Msgbox("Moneda Registrada con Exito", this.Page, this);
                txtTipoMoneda.Text = string.Empty;
                txtSimbolo.Text = string.Empty;
                txtFechaValor.Text = string.Empty;
                txtValor.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        public void actualizarMoneda(string nuevo, string cond)
        {
            /*campos = "descripbod = '" + nuevo + "'";
            condic = "descripbod= '" + cond + "'";
            valida = objConec.Actualizar("moneda", campos, condic);

            if (valida == "ok")
            {
                Msgbox("Bodega Modificada", this.Page, this);
                txtBodega.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }*/
        }

        public void eliminarMoneda(string cond)
        {
            condic = cond;
            valida = objConec.Eliminar("moneda", "tipomoneda", condic);

            if (valida == "ok")
            {
                Msgbox("Moneda Eliminada", this.Page, this);
                txtTipoMoneda.Text = string.Empty;
                txtSimbolo.Text = string.Empty;
                txtFechaValor.Text = string.Empty;
                txtValor.Text = string.Empty;
            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarMoneda();
            dgvMonedas.DataSource = null;
            MostrarDatos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarMoneda(txtTipoMoneda.Text);
            dgvMonedas.DataSource = null;
            MostrarDatos();
        }

        protected void txtSimbolo_TextChanged(object sender, EventArgs e)
        {
            dtpFechaValor.Visible = true;
        }

        protected void dtpFechaValor_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaValor.Text = dtpFechaValor.SelectedDate.ToString("dd/M/yyyy");
            dtpFechaValor.Visible = false;
        }

    }
}
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Taller3.Clases;

namespace Taller3.Vistas.Mantenedores
{
    public partial class Wf_MantRepuestos : System.Web.UI.Page
    {

        Conexion objConec = new Conexion();
        public OracleDataReader registros;
        string valida = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarMarca();
            llenarProveedor();
            llenarTipoRepu();
            llenarTipoVeh();
            llenarBodega();
            MostrarDatos();
        }

        public void InsertCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(Repuesto);", true);
        }

        public void DeleteCorrecto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(RepuestoElim);", true);
        }

        public void EditRepuesto()
        {
            Page.ClientScript.RegisterStartupScript(
            Page.ClientScript.GetType(), "onLoad", "mostrarDiv(RepuestoMod);", true);
        }

        public void llenarTipoRepu()
        {
            cbbTipoRepuesto.Items.Add("Seleccione");
            registros = objConec.llenarCombo("tiporepuesto", "idtiporepuesto");
            while (registros.Read())
            {
                cbbTipoRepuesto.Items.Add(registros.GetValue(1).ToString());
            }
        }

        public void llenarProveedor()
        {
            cbbProveedor.Items.Add("Seleccione");
            registros = objConec.llenarCombo("proveedor", "idproveedor");
            while (registros.Read())
            {
                cbbProveedor.Items.Add(registros.GetValue(3).ToString());
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
            registros = objConec.llenarCombo("tipoVehiculo", "id_tipoVehiculo");
            while (registros.Read())
            {
                cbbTipoVeh.Items.Add(registros.GetValue(2).ToString());
            }
        }

        public void llenarBodega()
        {
            cbbBodega.Items.Add("Seleccione");
            registros = objConec.llenarCombo("bodega", "codbod");
            while (registros.Read())
            {
                cbbBodega.Items.Add(registros.GetValue(1).ToString());
            }
        }

        private void MostrarDatos()
        {
            DataSet tabla = new DataSet();
            objConec.LlenarGrillaRepuestos().Fill(tabla);
            dgvRepuestos.DataSource = tabla.Tables[0].DefaultView;
            dgvRepuestos.DataBind();
        }

        public void datosRepuesto()
        {
            string codRepues = txtCodRep.Text;
            registros = objConec.datosRepuesto(codRepues);
            if (registros.HasRows)
            {
                EditRepuesto();
                while (registros.Read())
                {
                    txtDescrip.Text = registros["descriprepuesto"].ToString();
                    txtSerie.Text = registros["serie"].ToString();
                    txtNroParte.Text = registros["nroparte"].ToString();
                    txtCantStock.Text = registros["stock"].ToString();
                    txtValorNeto.Text = registros["valorneto"].ToString();
                    cbbTipoRepuesto.SelectedItem.Text = registros["destiporepuesto"].ToString();
                    cbbProveedor.SelectedItem.Text = registros["nombre"].ToString();
                    cbbMarca.SelectedItem.Text = registros["descripmarca"].ToString();
                    cbbBodega.SelectedItem.Text = registros["descripbodega"].ToString();
                    cbbTipoVeh.SelectedItem.Text = registros["tipovehiculo"].ToString();
                   
                }
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodRep.ReadOnly = true;
            }
            else
            {
                btnInsertar.Visible = true;
                btnActualizar.Visible = false;
                //btnBorrar.Visible = false;
            }
        }

        public void guardarRepuesto()
        {
            string proveedor = cbbProveedor.SelectedItem.ToString();
            string bodega = cbbBodega.SelectedItem.ToString();
            string tipoRep = cbbTipoRepuesto.SelectedItem.ToString();
            string marca = cbbMarca.SelectedItem.ToString();
            string tipoVeh = cbbTipoVeh.SelectedItem.ToString();
           
            valida = objConec.guardarRepuesto(txtCodRep.Text, txtDescrip.Text, txtSerie.Text, txtNroParte.Text,
                                    proveedor, txtValorNeto.Text, bodega, txtCantStock.Text, tipoRep, marca, tipoVeh);

            if (valida == "ok")
            {
                txtCantStock.Text = string.Empty;
                txtCodRep.Text = string.Empty;
                txtDescrip.Text = string.Empty;
                txtNroParte.Text = string.Empty;
                txtSerie.Text = string.Empty;
                txtValorNeto.Text = string.Empty;
                cbbBodega.SelectedIndex = -1;
                cbbMarca.SelectedIndex = -1;
                cbbMarca.SelectedIndex = -1;
                cbbProveedor.SelectedIndex = -1;
                cbbTipoRepuesto.SelectedIndex = -1;
                cbbTipoVeh.SelectedIndex = -1;
                InsertCorrecto();
            }
            else
            {
                //Msgbox(valida, this.Page, this);
            }
        }

        public void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            System.Web.UI.Page pageToRender = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            guardarRepuesto();
            dgvRepuestos.DataSource = null;
            MostrarDatos();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("Repuestos", dgvRepuestos);
        }

        protected void txtCodRep_TextChanged(object sender, EventArgs e)
        {
            datosRepuesto();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
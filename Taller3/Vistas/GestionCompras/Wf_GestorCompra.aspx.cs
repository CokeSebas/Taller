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
      
        string valor;
        string resultadoId;
        string valor2;
        string resultadoId2;
        string valor3;
        string resultadoId3;
        string valornetorep;





        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cboEmpleado.Items.Clear();
                //cboProveedor.Items.Clear();
                llenarProv();

                llenarEmp();

                llenarRepuesto();
            }





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
                cboEmpleado.Items.Add(registros.GetValue(3).ToString());
            }
        }

        public void llenarRepuesto()
        {
            cboRepuesto.Items.Add("Seleccione");
            registros = objConec.llenarCombo("repuestos", "idRepuesto");
            while (registros.Read())
            {
                cboRepuesto.Items.Add(registros.GetValue(2).ToString());
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
            objConec.LlenarGrilla("detalle_orden_pedido").Fill(tabla);
            grilla.DataSource = tabla.Tables[0].DefaultView;
            grilla.DataBind();
        }



        protected void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Write((sender as DropDownList).SelectedItem.Text);
            valor = cboProveedor.SelectedItem.Text;


            registros = objConec.buscaID("proveedor", "nombre", valor);
            while (registros.Read())
            {
                resultadoId = registros.GetValue(0).ToString();

            }


        }

        protected void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

            Response.Write((sender as DropDownList).SelectedItem.Text);
            valor2 = cboEmpleado.SelectedItem.Text;



            registros = objConec.buscaID("empleado", "nombre", valor2);
            while (registros.Read())
            {
                resultadoId2 = registros.GetValue(0).ToString();

            }

        }

        public void guardarPedido()
        {
            //string cargo = txtRegion.Text + ;

            campos = "seq_ordped.NEXTVAL, '" + txtOrdPed.Text + "','" + resultadoId.ToString() + "', '" + resultadoId2.ToString() + "', '" + TxtCostoTotal.Text + "', '" + TxtFePedido.Text + "', '" + TxtNetoTotal.Text + "', '" + TxtTotPedido.Text + "')";

            valida = objConec.Insert("ORDEN_PEDIDO", campos);

            if (valida == "ok")
            {
                Msgbox("Pedido Registrado con Exito", this.Page, this);

            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }


        public void guardarDetPedido()
        {

            foreach (GridView row in grilla.Rows)
            {
                //Msgbox.Show(row.Cells["idrepuesto"].Value.ToString());
                //Msgbox.Show(row.Cells["Cantidad"].Value.ToString());
                //Msgbox.Show(row.Cells["costound"].Value.ToString());
                //Msgbox.Show(row.Cells["netound"].Value.ToString());
            }

            campos = "SEQ_DETORDPED.NEXTVAL, '" + txtOrdPed.Text + "','" + resultadoId.ToString() + "', '" + resultadoId2.ToString() + "', '" + TxtCostoTotal.Text + "', '" + TxtFePedido.Text + "', '" + TxtNetoTotal.Text + "', '" + TxtTotPedido.Text + "')";

            valida = objConec.Insert("ORDEN_PEDIDO", campos);

            if (valida == "ok")
            {
                Msgbox("Pedido Registrado con Exito", this.Page, this);
                cboEmpleado.SelectedIndex = -1;
                cboProveedor.SelectedIndex = -1;
                cboRepuesto.SelectedIndex = -1;


                TxtCant.Text = string.Empty;
                TxtCostoTotal.Text = string.Empty;
                TxtCostoUnd.Text = string.Empty;
                TxtFePedido.Text = string.Empty;
                TxtNetoTotal.Text = string.Empty;
                TxtNetoUnd.Text = string.Empty;
                txtOrdPed.Text = string.Empty;
                TxtTotPedido.Text = string.Empty;

            }
            else
            {
                Msgbox(valida, this.Page, this);
            }
        }


        protected void cboProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write((sender as DropDownList).SelectedItem.Text);
            valor3 = cboRepuesto.SelectedItem.Text;



            registros = objConec.buscaID("repuestos", "descriprepuesto", valor3);
            while (registros.Read())
            {
                resultadoId3 = registros.GetValue(0).ToString();
                valornetorep = registros.GetValue(6).ToString();
                TxtCostoUnd.Text = valornetorep.ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            guardarPedido();




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

            DataTable dt = new DataTable();
            DataRow Row1;
            //DataRow Row2;
            dt.Columns.Add(new DataColumn("Repuesto", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Costo Und", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Total Neto Linea", System.Type.GetType("System.String")));

            Row1 = dt.NewRow();
            Row1["Repuesto"] = this.cboRepuesto.Text;
            Row1["Cantidad"] = this.TxtCant.Text;
            Row1["Costo Und"] = this.TxtCant.Text;
            Row1["Total Neto Linea"] = this.TxtCant.Text;
            dt.Rows.Add(Row1);

            //Row2 = dt.NewRow();
            //Row2["Nombre"] = this.txtnombre.Text;
            //Row2["Apellido"] = this.txtapellido.Text;
            //dt.Rows.Add(Row2);

            grilla.DataSource = dt;
            grilla.DataBind();

           
           
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        protected void grilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtCant_TextChanged(object sender, EventArgs e)
        {
            if (TxtCant.Text == "")
            {
                agregar.Enabled = false;
                Msgbox(valida, this.Page, this);
                
            }
            else
            {
                if (Convert.ToInt32(TxtCant.Text) > 0)
                {
                    TxtNetoUnd.Text = (Convert.ToInt32(TxtCant.Text) * Convert.ToDecimal(TxtCostoUnd.Text)).ToString();
                    agregar.Enabled = true;
                }
                else
                {
                    Msgbox(valida, this.Page, this);


                }


            }
        }

        protected void grilla_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
    
}
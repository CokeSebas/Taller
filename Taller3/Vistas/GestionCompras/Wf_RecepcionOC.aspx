<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_RecepcionOC.aspx.cs" Inherits="Mitaller.Wf_RecepcionOC" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>RECEPCION DE PRODUCTOS / RESPUESTOS POR ORDEN DE COMPRA</h3>
    <p>Recepcione los pedidos ingresando el número de Órden de Compra.</p>

     <table class="table" style="height: 10px">
       <tr>
        <td class="modal-sm" style="width: 120px; height: 51px;">
             Nro Orden de Compra / Pedido: 
        </td>
        <td style="width: 38px; height: 51px;"><input type="text" name="noc" values="Ingrese Nro OC" style="width: 84px" /></td>
         <td style="width: 85px; height: 51px;">Fecha Recepcion:</td>
        <td style="width: 78px; height: 51px;"><input type="text" name="fechaRecep" values="Ingrese Fecha del repuesto" style="width: 71px" /></td>
        <td style="width: 69px; height: 51px;">Codigo del Empleado:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="codEmp" values="Ingrese Codigo Empleado" style="width: 77px; margin-top: 3;" /></td>
       </tr> 
       <tr>
        <td style="width: 72px; height: 51px;">Fecha Ord.Compra:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="fenoc" values="Fecha Noc" style="width: 79px; margin-top: 3;" /></td>
        <td style="width: 72px; height: 51px;">Total Ord.Compra:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="Totnoc" values="Total Noc" style="width: 85px; margin-top: 3;" /></td>    
       </tr>
      </table>  
      
       <tr>
             <td>
                  <td style="width: 489px; height: 21px;">DETALLE DE RECEPCION DE PRODUCTOS / REPUESTOS CON O.C. :</td>
             </td>
        </tr>
           </br>
           </br>
    <table>
        <tr>
              <td style="width: 133px">Seleccione Producto :</td><td style="width: 305px" class="modal-sm">
              <asp:DropDownList ID="cboProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProd_SelectedIndexChanged" Height="26px" Width="241px"></asp:DropDownList></td>  
             <td style="width: 80px; height: 22px;">Cantidad:</td><td style="width: 109px; height: 22px;"><asp:TextBox ID="TxtCant" placeholder="0" runat="server" Width="58px"></asp:TextBox></td>
             <td style="width: 85px; height: 22px;">Costo Unidad:</td><td style="width: 123px; height: 22px"><asp:TextBox ID="TxtCostoUnd" placeholder="0" runat="server" Width="60px"></asp:TextBox></td>
             <td style="width: 168px; height: 22px;">Total Neto Linea :</td><td style="width: 101px; height: 22px"><asp:TextBox ID="TxtNetoUnd" placeholder="0" runat="server" Width="77px"></asp:TextBox></td>
             <td style="width: 60px"> <asp:Button ID="agregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" Font-Size="Smaller" /></td> 
             <td style="width: 30px"> <asp:Button ID="quitar" runat="server" Text="Quitar" OnClick="btnQuitar_Click" Font-Size="Smaller" /></td> 
         </tr>
    </table>
     </br>
        </br>
    <table>
        <tr>
    <td style="width: 368px; height: 22px;"> <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 152px; top:721px; position:inherit; right: 597px" Width="371px" Height="114px">
                  </asp:GridView></td>
          </tr>
        </table>
    <br />
    <br />
    <br />
    <br />
    <br />

     <tr>
            <td class="modal-sm" style="width: 171px" colspan="3"></td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 171px">
                <asp:Button ID="btnActualiza" runat="server" Text="Actualiza" OnClick=" btnActualiza_Click" /></td>
            <td>
                <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" /></td>
        </tr>
        <tr><td class="modal-sm" style="width: 171px">
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" /></td></tr> 
           
          

</asp:Content>
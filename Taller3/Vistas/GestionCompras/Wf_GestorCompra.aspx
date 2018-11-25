<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_GestorCompra.aspx.cs" Inherits="Mitaller.Wf_GestorCompra" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Generación de Orden de Pedido</h3>
     <p>Ingrese una nueva Orden de Pedido o utilice las opciones para buscar o eliminar.</p>
     <table class="table">
      <tr>
        <td style="width: 236px">Nro Orden de Pedido:</td><td><asp:TextBox ID="txtOrdPed" placeholder="Ingrese Nro Ord. Ped" runat="server"></asp:TextBox></td>
        <td style="width: 196px">Seleccione al Proveedor :</td><td>
                <asp:DropDownList ID="cboProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProv_SelectedIndexChanged" Height="16px" Width="153px"></asp:DropDownList></td>  
      </tr>
          <tr>
       
       <td style="width: 236px">Seleccione Empleado que Solicita : </td><td>
                <asp:DropDownList ID="cboEmpleado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboEmpleado_SelectedIndexChanged" Height="16px" Width="241px"></asp:DropDownList></td>      
      </tr>
         <tr>
             <td style="width: 236px">Costo Total:</td><td><asp:TextBox ID="TxtCostoTotal" placeholder="0" runat="server" Width="80px"></asp:TextBox></td>
             <td style="width: 196px">Fecha Pedido:</td><td><asp:TextBox ID="TxtFePedido" placeholder="" runat="server" Width="67px"></asp:TextBox></td>
             
         </tr>
         <tr>
             <td style="width: 279px">Neto Total:</td><td><asp:TextBox ID="TxtNetoTotal" placeholder="0" runat="server" Width="77px"></asp:TextBox>

             <td style="width: 196px">Total Pedido:</td><td><asp:TextBox ID="TxtTotPedido" placeholder="0" runat="server" Width="65px"></asp:TextBox></td>
         </tr>
     </table>
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
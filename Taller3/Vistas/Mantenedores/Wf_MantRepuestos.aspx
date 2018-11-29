<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantRepuestos.aspx.cs" Inherits="Taller3.Vistas.Mantenedores.Wf_MantRepuestos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENCION DE REPUESTOS</h3>
     <p>Ingrese nuevos repuestos o utilice las opciones para buscar o eliminar.</p>
    
    <table class="table">
      <tr>
       <td style="width: 145px">Código Repuesto:</td><td><asp:TextBox ID="txtCodRep" placeholder="Ingrese Cod. Repuesto" runat="server"></asp:TextBox></td>
        <td style="width: 178px">Descripción Repuesto:</td><td><asp:TextBox ID="txtDescrip" placeholder="Ingrese Descripción" runat="server"></asp:TextBox></td>
        <td style="width: 146px">Nro. Serie:</td><td><asp:TextBox ID="txtSerie" placeholder="Ingrese Serie" runat="server" Width="156px"></asp:TextBox></td>
        <td style="width: 196px">Seleccione Tipo Repuesto :</td><td>
         <asp:DropDownList ID="cbotipoRep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProv_SelectedIndexChanged" Height="16px" Width="241px"></asp:DropDownList></td>  
      </tr>
          </table>
     <table class="table">
        <tr> 
          <td style="width: 141px">Nro. Parte:</td><td><asp:TextBox ID="txtNroParte" placeholder="Ingrese nro de Parte" runat="server"></asp:TextBox></td>
          <td style="width: 196px">Seleccione al Proveedor :</td><td>
          <asp:DropDownList ID="cboProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProv_SelectedIndexChanged" Height="16px" Width="241px"></asp:DropDownList></td>  
          <td style="width: 196px">Seleccione Marca :</td><td>
          <asp:DropDownList ID="cboMarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProv_SelectedIndexChanged" Height="16px" Width="241px"></asp:DropDownList></td>    
        </tr>
     </table>

    <table class="table">
        <tr>
            <td style="width: 141px">Nro. Valor Neto:</td><td><asp:TextBox ID="TxtValorNeto" placeholder="Ingrese Valor Neto" runat="server"></asp:TextBox></td>
            <td style="width: 196px">Seleccione la Bodega :</td><td style="width: 303px">
          <asp:DropDownList ID="cboBod" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboProv_SelectedIndexChanged" Height="16px" Width="241px"></asp:DropDownList></td>  
            <td style="width: 167px">Ingrese Cantidad (stock):</td><td><asp:TextBox ID="txtCantStock" placeholder="Ingrese stock" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    
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
   

         </br>
        </br>
    <table>
        <tr>
    <td style="width: 368px; height: 22px;"> <asp:GridView ID="grilla" runat="server" style="z-index: 1; left: 152px; top:721px; position:inherit; right: 597px" Width="371px" Height="114px" OnSelectedIndexChanged="grilla_SelectedIndexChanged">
                  </asp:GridView></td>
          </tr>
        </table>

  </asp:Content>
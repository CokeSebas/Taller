<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="finalizarReparacion.aspx.cs" Inherits="Taller3.Vistas.MantenedorVentas.finalizarReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Finalizar Venta</h3>
    <div class="alert alert-success" id="Venta" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Venta Finalizada Con Exito
     </div>
       <h4>Ingrese Numero Reparación para completar los Detalles</h4>
    <table class="table">
        <tr>
            <td>Seleccione Reparación</td>
            <td>
                <asp:DropDownList ID="cbbReparacion" runat="server" OnSelectedIndexChanged="cbbReparacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
            <td>Tipo Documento:</td>
            <td>
                <asp:DropDownList ID="cbbTipoDoc" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Nombre Cliente</td>
            <td>
                <asp:TextBox ID="txtNombCli" runat="server" ReadOnly="true"></asp:TextBox></td>
            <td>Fecha Venta:</td>
            <td><asp:TextBox ID="txtFecIng" runat="server"></asp:TextBox>
                <asp:Calendar ID="dtpFecIng" runat="server" OnSelectionChanged="dtpFecIng_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>Neto Venta</td>
            <td>
                <asp:TextBox ID="txtNeto" runat="server" ReadOnly="true"></asp:TextBox></td>
            <td>Total Venta</td>
            <td>
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan ="3">
                <asp:button runat="server" text="Guardar Venta" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <!--<td colspan ="3">
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger"/>
            </td>-->
        </tr>
    </table>
</asp:Content>

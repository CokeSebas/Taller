<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Wf_GestorReparaciones.aspx.cs" Inherits="Mitaller.Wf_GestorReparaciones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <table class="table">
        <tr>
            <td>Buscar Cliente:</td><td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>Fecha Inicio:</td><td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        <td>Fecha Final:</td><td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Patente Vehiculo</td><td></td>
            <td>Presupuesto</td><td></td>
            <td>Costo Total</td><td></td>
        </tr>
        <tr>
            <td>Hora Inicio:</td><td></td>
            <td>Hora Final:</td><td></td>
        </tr>
        <tr>
            <td colspan="2">Descripcion Reparación</td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">Diagnostico</td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" /></td>
            <td>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" /></td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" /></td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" /></td>
        </tr>
    </table>


</asp:Content>




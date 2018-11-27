<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantSucursal.aspx.cs" Inherits="Mitaller.Wf_MantSucursal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE SUCURSALES</h3>
    <p>Ingrese la Sucursal o utilice las opciones para buscar o eliminar.</p>
    <table class="table">
        <tr>
            <td >Nombre Sucursal:</td>
            <td >
                <asp:textbox runat="server" id="txtNombSuc"></asp:textbox>
            </td>  
            <td>Telefono:</td>
            <td>
                <asp:textbox runat="server" id="txtTelefonoSuc"></asp:textbox>
            </td>
            <td >Direccion:</td>
            <td >
                <asp:textbox runat="server" ID="txtDirecSuc"></asp:textbox>
            </td>    
        </tr>
        <tr>
            <td>Region:</td><td>
                <asp:DropDownList ID="cbbRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbbRegion_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Provincia:</td><td>
                <asp:DropDownList ID="cbbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Provincia_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Comuna:</td><td>
                <asp:DropDownList ID="cbbComuna" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan ="3">
                <asp:button runat="server" text="Insertar" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <td colspan ="3">
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
            </td>
        </tr>
    </table>
    <table style="table">
        <tr>
            <td colspan="3">
                <asp:gridview runat="server" id="dgvSucursales"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>

</asp:Content>

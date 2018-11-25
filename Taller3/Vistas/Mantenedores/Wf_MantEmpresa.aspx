<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantEmpresa.aspx.cs" Inherits="Mitaller.Wf_MantEmpresa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE EMPRESA</h3>
    <p>Modifique la Información de la Empresa que usa el Sistema</p>
    
    <table class="table">
        <tr>
            <td >Rut de la Empresa:</td>
            <td >
                <asp:textbox runat="server" id="txtRutEmpr" disabled="true"></asp:textbox>
            </td>
            <td >Nombre Empresa:</td>
            <td >
                <asp:textbox runat="server" id="txtNombEmpr"></asp:textbox>
            </td>  
            <td>Giro Empresa:</td>
            <td>
                <asp:textbox runat="server" ID="txtGiroEmpr"></asp:textbox>
            </td>
        <tr>
            <td>Email:</td>
             <td >
                 <asp:textbox runat="server" id="txtEmailEmpre"></asp:textbox>
             </td>  
            <td>Telefono:</td>
            <td>
                <asp:textbox runat="server" id="txtTelefonoEmpr"></asp:textbox>
            </td>
            <td >Direccion:</td>
            <td >
                <asp:textbox runat="server" ID="txtDirecEmpre"></asp:textbox>
            </td>    
        </tr>
        <tr>
            <td>Region:</td><td>
                <asp:DropDownList ID="cbbRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Region_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Provincia:</td><td>
                <asp:DropDownList ID="cbbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Provincia_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Comuna:</td><td>
                <asp:DropDownList ID="cbbComuna" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-success" OnClick="btnActualizar_Click" /></td>
         </tr>
    </table>
</asp:Content>

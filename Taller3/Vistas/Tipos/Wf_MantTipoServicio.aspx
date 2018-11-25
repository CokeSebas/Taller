<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoServicio.aspx.cs" Inherits="Mitaller.Wf_MantTipoServicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE SERVICIOS</h3>
    <p>Ingrese el Servicio o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
        <tr>
            <td>Código de Servicio:</td>
            <td>
                <asp:textbox runat="server" ID="txtCodServ"></asp:textbox>
            </td>
            <td>Tipo de Servicio</td>
            <td>
                <asp:dropdownlist runat="server" id="cbbTipoServ"></asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td >Descripcion del Servicio:</td>
            <td >
                <asp:textbox runat="server" id="txtServicio" Width="286px"></asp:textbox>
            </td>
            <td>Costo del Servicio</td>
            <td>
                <asp:textbox runat="server" ID="txtCostoServ"></asp:textbox>
            </td>
        </tr>    
        <tr>
            <td colspan="2">
                <asp:button runat="server" text="Insertar" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <td colspan="2">
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
            </td>
        </tr>
    </table>
    <table style="table">
        <tr>
            <td colspan="3">
                <asp:gridview runat="server" id="dgvServicios"></asp:gridview>
            </td>
        </tr>
    </table>
</asp:Content>

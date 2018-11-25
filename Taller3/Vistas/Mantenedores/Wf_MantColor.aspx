<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantColor.aspx.cs" Inherits="Mitaller.Wf_MantColor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE COLOR</h3>
    <p>Ingrese el Color o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
        <tr>
            <td >Nombre de Color:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtColor" Width="286px"></asp:textbox>
            </td>
        </tr>    
        <tr>
            <td style="width: 78px">
                <asp:button runat="server" text="Insertar" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <td>
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
            </td>
        </tr>
    </table>
    <table style="table">
        <tr>
            <td colspan="3">
                <asp:gridview runat="server" id="dgvColores"></asp:gridview>
            </td>
        </tr>
    </table>
</asp:Content>

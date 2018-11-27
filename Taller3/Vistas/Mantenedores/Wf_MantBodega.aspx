<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantBodega.aspx.cs" Inherits="Mitaller.Wf_MantBodega" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h3>MANTENEDOR DE BODEGAS</h3>
    <p>Ingrese la Bodega o utilice las opciones para buscar o eliminar.</p>

    <table class="table" style="height: 10px">
        <tr>
            <td >Nombre de Bodega:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtBodega" Width="286px"></asp:textbox>
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
                <asp:gridview runat="server" id="dgvBodegas"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
       
</asp:Content>

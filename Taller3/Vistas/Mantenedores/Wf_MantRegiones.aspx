<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantRegiones.aspx.cs" Inherits="Taller3.Vistas.Mantenedores.Wf_MantRegiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>MANTENEDOR DE REGIONES</h3>
    <p>Ingrese una Nueva Region.</p>

    <table class="table" style="height: 10px">
        <tr>
            <td >Nombre de Region:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtRegion" Width="286px"></asp:textbox>
            </td>
        <tr>
            <td>Ordinal Region (ej:I-II-III-IV,ETC)</td>
            <td>
                <asp:TextBox ID="txtOrdinal" runat="server"></asp:TextBox>
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
                <asp:gridview runat="server" id="dgvRegiones"></asp:gridview>
            </td>
        </tr>
    </table>
</asp:Content>

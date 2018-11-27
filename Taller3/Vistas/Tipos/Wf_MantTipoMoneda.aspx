<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoMoneda.aspx.cs" Inherits="Mitaller.Wf_MantTipoMoneda" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE MONEDA</h3>
    <p>Ingrese la Moneda o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
        <tr>
            <td >Tipo de Moneda:</td>
            <td>
                <asp:textbox runat="server" ID="txtTipoMoneda"></asp:textbox>
            </td>
            <td >Símbolo de Moneda:</td>
            <td>
                <asp:textbox runat="server" ID="txtSimbolo" OnTextChanged="txtSimbolo_TextChanged" AutoPostBack="true"></asp:textbox>
            </td>
        </tr>            
        <tr>
            <td style="width: 163px; height: 28px;">Fecha del Valor Actual:</td>
            <td>
                <asp:textbox runat="server" ID="txtFechaValor"></asp:textbox>
                <asp:calendar runat="server" ID="dtpFechaValor" Visible="false" OnSelectionChanged="dtpFechaValor_SelectionChanged"></asp:calendar>
            </td>
            <td>Valor Actual:</td>
            <td>
                <asp:textbox runat="server" ID="txtValor"></asp:textbox>
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
                <asp:gridview runat="server" id="dgvMonedas" Width="331px"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
</asp:Content>
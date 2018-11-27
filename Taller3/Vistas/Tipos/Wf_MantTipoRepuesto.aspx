<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoRepuesto.aspx.cs" Inherits="Mitaller.Wf_MantTipoRepuesto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR TIPO DE REPUESTO </h3>
     <table class="table" style="height: 10px">
        <tr>
            <td>Descripcion del Repuesto:</td>
            <td>
                <asp:textbox runat="server" ID="txtRepuesto"></asp:textbox>
            </td>
        </tr>   
        <tr>
            <td>
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
                <asp:gridview runat="server" id="dgvRepuestos"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
</asp:Content>
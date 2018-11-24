<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantCiudad.aspx.cs" Inherits="Mitaller.Wf_MantCiudad" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE CIUDADES</h3>
    <p>Ingrese la Ciudad o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
        <tr>
            <td>Region a la Cual Pertenece</td>
            <td>
                <asp:DropDownList ID="cbbRegion" AutoPostBack="True" runat="server" OnSelectedIndexChanged="cbbRegion_SelectedIndexChanged" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Provincia a la Cual Pertenece</td>
            <td>
                <asp:DropDownList ID="cbbProvincia" runat="server" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >Nombre de Ciudad:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtCiudad" Width="286px"></asp:textbox>
            </td>   
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
                <asp:gridview runat="server" id="dgvCiudades"></asp:gridview>
            </td>
        </tr>
    </table>
</asp:Content>

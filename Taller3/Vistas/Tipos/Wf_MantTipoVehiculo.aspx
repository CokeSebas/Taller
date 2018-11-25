<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoVehiculo.aspx.cs" Inherits="Mitaller.Wf_MantTipoVehiculo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR TIPO DE VEHÍCULO</h3>
    <p>Ingrese el Tipo de Vehículo o utilice las opciones para buscar o eliminar.</p> 
    <table class="table" style="height: 10px">
        <tr>
            <td> Cod.Tipo Vehículo:</td>
            <td>
                <asp:textbox runat="server" ID="txtCodVeh"></asp:textbox>
            </td>
            <td>Descripcion del Tipo de Vehiculo:</td>
            <td>
                <asp:textbox runat="server" ID="txtTipoVeh"></asp:textbox>
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
                <asp:gridview runat="server" id="dgvVehiculos"></asp:gridview>
            </td>
        </tr>
    </table>

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Wf_GestorVentas.aspx.cs" Inherits="Mitaller.Wf_GestorVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <table class="table">
        <tr>
            <td>Seleccionar Cliente:</td><td>
                <asp:DropDownList ID="cbbClientes" runat="server" OnSelectedIndexChanged="cbbClientes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
            <td>Seleccionar Vehiculo:</td>
            <td>
                <asp:DropDownList ID="cbbPatente" runat="server" OnSelectedIndexChanged="cbbPatente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
        <td>Fecha Inicio:</td><td>
            <asp:TextBox ID="txtFecIni" runat="server"></asp:TextBox>
            <asp:Calendar ID="dtpFecInic" runat="server" Visible="false" OnSelectionChanged="dtpFecInic_SelectionChanged"></asp:Calendar>
            </td>
        <td>Fecha Final:</td><td>
            <asp:TextBox ID="txtFecFin" runat="server"></asp:TextBox>
            <asp:Calendar ID="dtpFecFin" runat="server" Visible="false" OnSelectionChanged="dtpFecFin_SelectionChanged"></asp:Calendar>
        </td>
        </tr>
        <tr>
            <td>Presupuesto</td><td>
                <asp:TextBox ID="txtPresup" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtPresup" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
                </asp:RegularExpressionValidator>
            </td>
            <td>Estado Reparacion:</td>
            <td>
                <asp:DropDownList ID="cbbEstadoRep" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Hora Inicio:</td><td>
                <asp:TextBox ID="txtHoraInic" runat="server"></asp:TextBox></td>
            <td>Hora Final:</td><td>
                <asp:TextBox ID="txtHoraFin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Diagnostico</td>
            <td>
                <asp:TextBox ID="txtDiag" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" /></td>
        </tr>
    </table>


</asp:Content>
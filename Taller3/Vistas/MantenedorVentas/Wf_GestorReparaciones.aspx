<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Wf_GestorReparaciones.aspx.cs" Inherits="Mitaller.Wf_GestorReparaciones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-success" id="DetRep" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Detalles Reparacion Registrados Con Exito
     </div>
       <h4>Ingrese Numero Reparación para completar los Detalles</h4>

    <table class="table">
        <tr>
            <td>Seleccione Reparación</td>
            <td>
                <asp:DropDownList ID="cbbReparacion" runat="server" OnSelectedIndexChanged="cbbReparacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
            <td>Diagnostico:</td>
            <td>
                <asp:TextBox ID="txtDiag" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Seleccione Tipo de Servicio:</td>
            <td>
                <asp:DropDownList ID="cbbTipoServicio" runat="server"></asp:DropDownList></td>
            <td>Servicio:</td><td>
                <asp:DropDownList ID="cbbServicio" runat="server"></asp:DropDownList>
                &nbsp
                <asp:Button ID="btnAddServ" runat="server" Text="+" class="btn btn-primary" OnClick="btnAddServ_Click" />
                &nbsp
                <asp:Button ID="btnElimServ" runat="server" Text="-" class="btn btn-warning" OnClick="btnElimServ_Click" />
            </td>

        </tr>
        </table>
     <table class="table">
        <tr>
            <td>
                <asp:GridView ID="dgvServicios" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>
    <table class="table">
        <tr>
            <td>Seleccione Repuesto:</td><td>
            <asp:DropDownList ID="cbbRepuesto" runat="server"></asp:DropDownList>
            &nbsp
            <asp:Button ID="btnAddRepues" runat="server" Text="+" class="btn btn-primary" OnClick="btnAddRepues_Click" />
            &nbsp
            <asp:Button ID="btnElimRepue" runat="server" Text="-" class="btn btn-warning" OnClick="btnElimRepue_Click"  />
            </td>
        </tr>
    </table>
    <table class="table">
        <tr>
            <td>
                <asp:GridView ID="dgvRepuestos" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>
    <table class="table">
        <tr>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" /></td>
        </tr>
    </table>


</asp:Content>




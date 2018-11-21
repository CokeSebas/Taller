<%@ Page Title="Registro Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCli.aspx.cs" Inherits="Taller3.Vistas.Cliente.RegistroCli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Registrese para poder reservar una Hora en el Taller</h3>
    <p></p>
    <div class="alert alert-success" id="success"  runat="server" style="display:none">
        <strong>Correcto!</strong> Se ha registrado con Exito.
     </div>
    <table class="table">
        <tr>
            <td>RUT:</td><td><asp:TextBox ID="txtRutCli" placeholder="Ingrese Rut" runat="server"></asp:TextBox></td>
            <td>Nombre:</td><td><asp:TextBox ID="txtNombCli" placeholder="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="txtNombCli" ErrorMessage="*Ingrese solo letras"
                            ForeColor="Red"
                            ValidationExpression="^[A-Za-z]*$">
                </asp:RegularExpressionValidator></td>
            <td>Apellidos:</td><td><asp:TextBox ID="txtApCli" placeholder="Ingrese Apellido" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                            ControlToValidate="txtApCli" ErrorMessage="*Ingrese solo letras"
                            ForeColor="Red"
                            ValidationExpression="^[A-Za-z ]*$">
                </asp:RegularExpressionValidator></td>
        </tr>
       
        <tr>

            <td>Region:</td><td>
                <asp:DropDownList ID="cbbRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Region_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Provincia:</td><td>
                <asp:DropDownList ID="cbbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Provincia_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Comuna:</td><td>
                <asp:DropDownList ID="cbbComuna" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Direccion:</td><td colspan="2"><asp:TextBox ID="txtDirect" placeholder="Ingrese Direccion" runat="server" Width="318px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Telefono:</td><td>
                <asp:TextBox ID="txtFono" runat="server" placeholder="Ingrese Telefono" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtFono" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
                </asp:RegularExpressionValidator>
                </td>
            <td>Celular: </td>
            <td>
                <asp:TextBox ID="txtCeluCli" runat="server" placeholde="Ingrese Celular"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtCeluCli" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Correo:</td><td>
                <asp:textbox runat="server" id="txtEmailCli" placeholder="Ingrese su Correo"></asp:textbox>
            </td>
            <td>Nombre Usuario:</td><td><asp:TextBox ID="txtUssrCli" placeholder="Ingrese Nombre Usuario" runat="server"></asp:TextBox></td>
            <td>Contraseña:</td><td><asp:TextBox ID="txtPassCli" placeholder="Ingrese Contraseña" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn" OnClick="btnGuardar_Click" /></td>
        </tr>
    </table>


    </asp:Content>

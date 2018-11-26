<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Taller3.Loginaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesion ServiExpres</title>
</head>
<body>
    
    <form id="login" runat="server">
        <div>
            <h4>Ingrese Sesion para acceder al sistema, de lo contrario Registrese</h4>
            <table class="table">
                <tr>
                    <td>Nombre Usuario</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesion" class="btn btn-primary" OnClick="btnIniciar_Click" /></td>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" class="btn btn-primary" OnClick="btnRegistrar_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

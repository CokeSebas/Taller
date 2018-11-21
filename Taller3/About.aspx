<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Taller3.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 171px">
                ingrese Nombre:
            </td>

          <td><input type="text" name="nombre" values="ingrese nombre" /></td>
            <td>INgrse apelldio</td><td><input type="text" name="nombre" values="ingrese nombre" /></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 171px" colspan="3">otro tr</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Inserta" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 171px">
                <asp:Button ID="Button2" runat="server" Text="Actualiza" OnClick="Button2_Click" /></td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Elimina" OnClick="Button3_Click" /></td>
        </tr>
        <tr><td class="modal-sm" style="width: 171px">
            <asp:Button ID="Button4" runat="server" Text="Mostrar" OnClick="Button4_Click" /></td></tr>
    </table>

    <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantUsuarios.aspx.cs" Inherits="Taller3.Vistas.Mantenedores.Wf_MantUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Ingrese Usuario</h3>
    <p></p>
    <table class="table">
        <tr>
            <td>Tipo Usuario:</td><td>
                <asp:DropDownList ID="cbbTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cbbTipo_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>RUT:</td><td><asp:TextBox ID="txtRutUsser" placeholder="Ingrese Rut" runat="server" AutoPostBack="true" onfocus="myFunction(this)" OnTextChanged="txtRutUsser_TextChanged"></asp:TextBox></td>
            <td>Nombre:</td><td><asp:TextBox ID="txtNombUsser" placeholder="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="txtNombUsser" ErrorMessage="*Ingrese solo letras"
                            ForeColor="Red"
                            ValidationExpression="^[A-Za-z]*$">
                </asp:RegularExpressionValidator></td>
            <td>Apellidos:</td><td><asp:TextBox ID="txtApUsser" placeholder="Ingrese Apellido" runat="server" AutoPostBack="true" OnTextChanged="txtApUsser_TextChanged"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                            ControlToValidate="txtApUsser" ErrorMessage="*Ingrese solo letras"
                            ForeColor="Red"
                            ValidationExpression="^[A-Za-z ]*$">
                </asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Fecha Nacimiento:</td><td>
                <asp:TextBox ID="txtFecNac" runat="server" onfocus="calendar()" ></asp:TextBox>
                <asp:Calendar ID="dateFecNac" runat="server" OnSelectionChanged="dateFecNac_SelectionChanged" Visible="False"></asp:Calendar>
            </td>
            <td>Fecha Ingreso:</td><td>
                <asp:TextBox ID="txtFecIngr" runat="server" AutoPostBack="true" ></asp:TextBox>
                <asp:Calendar ID="dateFecIngr" runat="server" Visible="False" OnSelectionChanged="dateFecIngr_SelectionChanged"></asp:Calendar>
            </td>
            <td>Fecha Termino:</td><td>
                <asp:TextBox ID="txtFecTer" runat="server" AutoPostBack="true" ></asp:TextBox>
                <asp:Calendar ID="dateFecTer" runat="server" Visible="False" OnSelectionChanged="dateFecTer_SelectionChanged"></asp:Calendar>
            </td> 
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
            <td>Direccion:</td><td ><asp:TextBox ID="txtDirect" placeholder="Ingrese Direccion" TextMode="multiline" Columns="50" Rows="5" runat="server" Width="318px"></asp:TextBox></td>
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
            <td>
                <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                <asp:Label ID="lblSueldo" runat="server" Text="Sueldo:" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:textbox runat="server" id="txtEmailCli"></asp:textbox>
                <asp:TextBox ID="txtSueldo" runat="server" Visible="False" ></asp:TextBox>
            </td>
            <td>Nombre Usuario:</td><td><asp:TextBox ID="txtUssrCli" placeholder="Ingrese Nombre Usuario" runat="server"></asp:TextBox></td>
            <td>Contraseña:</td><td><asp:TextBox ID="txtPassCli" placeholder="Ingrese Contraseña" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn" OnClick="btnGuardar_Click" Visible="True"  /></td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn" Visible="False" OnClick="btnActualizar_Click" /></td>
            <td>
                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False" class="btn" OnClick="btnBorrar_Click"/></td>
        </tr>
    </table>

</asp:Content>

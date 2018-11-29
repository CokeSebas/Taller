<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="Taller3.Vistas.MantenedorUsuarios.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-success" id="Prov" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Proveedor Ingresado Con Exito
     </div>
     <div class="alert alert-danger" id="ProvElim" style="visibility:hidden;float:right;" >
          <strong>Correcto!</strong> Proveeodor Eliminado Con Exito
     </div>
    <h3>REGISTRO DE PROVEEDORES</h3>
    <p>Ingrese los datos del nuevo Proveedor o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 150px">
        <tr>
            <td>Rut Proveedor:</td>
            <td>
            <asp:TextBox ID="txtRutProv" runat="server" ></asp:TextBox></td>
            <td>Nombre Proveedor :</td>
            <td>
                <asp:TextBox ID="txtNombProv" runat="server"></asp:TextBox></td>
            <td>Giro :</td>
            <td>
                <asp:TextBox ID="txtGiro" runat="server"></asp:TextBox></td>
        </tr>
            <td>Direccion:</td>
            <td><asp:TextBox ID="txtDirect" TextMode="multiline" Columns="50" Rows="5" runat="server" Width="318px" OnTextChanged="txtDirect_TextChanged" AutoPostBack></asp:TextBox></td>
            <td>Fecha ingreso:</td>
            <td>
            <asp:TextBox ID="txtFecIngr" runat="server"></asp:TextBox>
            <asp:Calendar ID="dtpFecIng" runat="server" Visible="false" OnSelectionChanged="dtpFecIng_SelectionChanged"></asp:Calendar>
            </td>
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
                <asp:TextBox ID="txtCeluProv" runat="server" placeholde="Ingrese Celular"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtCeluProv" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
                </asp:RegularExpressionValidator>
            </td>
            <td>Email :</td>
            <td>
                <asp:TextBox ID="txtEmailProv" runat="server"></asp:TextBox></td> 
        </tr>
        <tr>
            <td>Region:</td><td>
            <asp:DropDownList ID="cbbRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Region_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Provincia:</td><td>
            <asp:DropDownList ID="cbbProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Provincia_SelectedIndexChanged"></asp:DropDownList></td>
            <td>Comuna:</td><td>
            <asp:DropDownList ID="cbbComuna" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" Visible="True"  /></td>
            <!--<td colspan="2">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-success" Visible="False" /></td>-->
            <td colspan="2">
                <asp:Button ID="btnBorrar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnBorrar_Click"/></td>
        </tr>
    </table>
    <table style="table">
        <tr>
            <td colspan="3">
                <asp:gridview runat="server" id="dgvProveedores"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
</asp:Content>

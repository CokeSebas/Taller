<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantRepuestos.aspx.cs" Inherits="Taller3.Vistas.Mantenedores.Wf_MantRepuestos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENCION DE REPUESTOS</h3>
    <div class="alert alert-success" id="Repuesto" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Repuesto Ingresado Con Exito
     </div>
     <div class="alert alert-danger" id="RepuestoElim" style="visibility:hidden; float:right;">
          <strong>Correcto!</strong> Repuesto Elminado Con Exito
     </div> 
    <div class="alert alert-success" id="RepuestoMod" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Repuesto Modificado Con Exito
     </div>
     <p>Ingrese nuevos repuestos o utilice las opciones para buscar o eliminar.</p>
    
    <table class="table">
      <tr>
       <td style="width: 145px">Código Repuesto:</td><td><asp:TextBox ID="txtCodRep" placeholder="Ingrese Cod. Repuesto" runat="server" OnTextChanged="txtCodRep_TextChanged"></asp:TextBox></td>
        <td style="width: 178px">Descripción Repuesto:</td><td><asp:TextBox ID="txtDescrip" placeholder="Ingrese Descripción" runat="server"></asp:TextBox></td>
        <td style="width: 146px">Nro. Serie:</td><td><asp:TextBox ID="txtSerie" placeholder="Ingrese Serie" runat="server" Width="156px"></asp:TextBox></td>
        <td style="width: 196px">Seleccione Tipo Repuesto :</td><td>
         <asp:DropDownList ID="cbbTipoRepuesto" runat="server"  Height="16px" Width="241px"></asp:DropDownList></td>  
      </tr>
     </table>
     <table class="table">
        <tr> 
          <td style="width: 141px">Nro. Parte:</td><td><asp:TextBox ID="txtNroParte" placeholder="Ingrese nro de Parte" runat="server"></asp:TextBox></td>
          <td style="width: 196px">Seleccione al Proveedor :</td><td style="width: 200px">
          <asp:DropDownList ID="cbbProveedor" runat="server"  Height="16px" Width="241px"></asp:DropDownList></td>  
          <td style="width: 196px">Seleccione Marca :</td><td style="width: 50px">
          <asp:DropDownList ID="cbbMarca" runat="server" Height="16px" Width="241px"></asp:DropDownList></td>    
          <td style="width: 182px">Seleccione Tipo Vehiculo</td><td>
              <asp:dropdownlist id="cbbTipoVeh" runat="server"></asp:dropdownlist>
          </td>
        </tr>
     </table>

    <table class="table">
        <tr>
            <td style="width: 141px">Nro. Valor Neto:</td>
            <td><asp:TextBox ID="txtValorNeto" placeholder="Ingrese Valor Neto" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtValorNeto" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>
            </td>
            <td style="width: 196px">Seleccione la Bodega :</td><td style="width: 303px">
          <asp:DropDownList ID="cbbBodega" runat="server"  Height="16px" Width="241px"></asp:DropDownList></td>  
            <td style="width: 167px">Ingrese Cantidad (stock):</td>
            <td><asp:TextBox ID="txtCantStock" placeholder="Ingrese stock" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtCantStock" ErrorMessage="*Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*"> </asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <table class="table">
        <tr>
            <td style="width: 656px">
                <asp:button runat="server" text="Insertar" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <!--<td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-success" Visible="False" OnClick="btnActualizar_Click" /></td>
            <td>-->
            <!--<td>
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger"/>
            </td>-->
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
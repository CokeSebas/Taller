<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantEmpresa.aspx.cs" Inherits="Mitaller.Wf_MantEmpresa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE EMPRESA</h3>
    <p>Ingrese la Empresa o utilice las opciones para buscar o eliminar.</p>
    
    <table class="table" style="height: 10px; width: 173%;">
    <tr>
        <td class="modal-sm" style="width: 237px; height: 51px;">
             Cod. de la Empresa: 
        </td>
        <td style="height: 51px;"><input type="text" name="codemp" values="Ingrese Codigo" style="width: 41px" /></td>
        <td style="width: 146px; height: 51px;">Rut de la Empresa:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="rutEmpreesa" values="Ingrese Rut de la empresa" style="width: 116px" /></td>
        <td style="width: 68px; height: 51px;">Nombre Empresa:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="descripEmpr" values="Ingrese Nombre de la empresa" style="width: 238px" /></td>    
       </table>  
    <table>
        <tr>
        <td style="width: 98px; height: 51px;">Direccion:</td>
        <td style="height: 51px;"><input type="text" name="direccion" values="Ingrese direccion" style="width: 332px" /></td>    
            <td style="width: 98px; height: 51px;">Ciudad:</td>
            <td style="height: 51px;"><input type="text" name="ciudad" values="Ingrese ciudad" style="width: 131px" /></td>    
             <td style="width: 98px; height: 51px;">Fono:</td>
             <td style="height: 51px;"><input type="text" name="Fono" values="Ingrese direccion" style="width: 101px" /></td>    
            <td style="width: 98px; height: 51px;">Giro:</td>
             <td style="height: 51px;"><input type="text" name="giro" values="ingrese giro" style="width: 221px" /></td>    
           
            </tr>
    </table>  
    <table>
        <tr>
             <td style="width: 98px; height: 51px;">Email:</td>
             <td style="height: 51px;"><input type="text" name="email" values="ingrese email" style="width: 221px" /></td>    
            <td style="width: 98px; height: 51px;">Nro Empleados:</td>
             <td style="height: 51px;"><input type="text" name="email" values="ingrese mro de empleados" style="width: 221px" /></td>    
        </tr>
    </table>

    <table>
         <tr>
             <td style="width: 98px; height: 51px;">Ingrese Sucursal:</td>
             <td style="height: 51px;"><input type="text" name="datosucu" values="ingrese sucursal" style="width: 221px" /></td>    
             <td style="width: 98px; height: 51px;">Seleccione Moneda:</td>
             <td style="height: 51px;"><input type="text" name="datomoneda" values="ingrese Moneda" style="width: 221px" /></td>    

         </tr>
    </table>
     <tr>
            <td class="modal-sm" style="width: 171px" colspan="3"></td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Inserta" OnClick="btnGuardar_Click" /></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 171px">
                <asp:Button ID="btnActualiza" runat="server" Text="Actualiza" OnClick=" btnActualiza_Click" /></td>
            <td>
                <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" /></td>
        </tr>
        <tr><td class="modal-sm" style="width: 171px">
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="btnMostrar_Click" /></td></tr> 
           
           
        
        <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 352px; top:665px; position: absolute; height: 133px; width: 268px; right: 651px">
           </asp:GridView>
        

</asp:Content>

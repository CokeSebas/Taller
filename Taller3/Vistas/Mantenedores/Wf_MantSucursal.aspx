<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantSucursal.aspx.cs" Inherits="Mitaller.Wf_MantSucursal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE SUCURSALES</h3>
    <p>Ingrese la Sucursal o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
    <tr>
        <td class="modal-sm" style="width: 102px; height: 51px;">
             Cod.Sucursal: 
        </td>
         <td style="width: 38px; height: 51px;"><input type="text" name="codSucu" values="Ingrese Codigo" style="width: 41px" /></td>
         <td style="width: 68px; height: 51px;">Direccion de la Sucursal:</td>
         <td style="width: 50px; height: 51px;"><input type="text" name="descripServ" values="Ingrese Servicio" style="width: 332px" /></td>
         <td style="width: 68px; height: 51px;">Seleccione Ciudad:</td>
         <td style="width: 50px; height: 51px;"><input type="text" name="cboCiudad" values="Ingrese ciudad" style="width: 332px" /></td>    
         <td style="width: 68px; height: 51px;">Seleccione Empresa:</td>
         <td style="width: 50px; height: 51px;"><input type="text" name="cboEmp" values="Ingrese " style="width: 332px" /></td> 
        
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

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoMoneda.aspx.cs" Inherits="Mitaller.Wf_MantTipoMoneda" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE MONEDA</h3>
    <p>Ingrese la Moneda o utilice las opciones para buscar o eliminar.</p>

     <table class="table" style="height: 10px">
    <tr>
        <td class="modal-sm" style="width: 54px; height: 26px;">
             Cod. de Moneda: 
        </td>
        <td style="width: 33px; height: 26px;"><input type="text" name="idMoneda" values="Codigo de Moneda" style="width: 52px" /></td>
         <td style="width: 45px; height: 26px;">Tipo de Moneda:</td>
        <td style="width: 50px; height: 26px;"><input type="text" name="tipoMoneda" values="Ingrese tipo de moneda" style="width: 119px" /></td>
         <td style="width: 70px; height: 26px;">Símbolo de Moneda:</td>
         <td style="width: 50px; height: 26px;"><input type="text" name="simbolo" values="Ingrese simbolo de moneda" style="width: 94px" /></td>    
         
         
    </tr>            
    </table>
    <table>
        <tr>
            <td style="width: 163px; height: 28px;">Fecha del Valor Actual:</td>
         <td style="width: 50px; height: 28px;"><input type="text" name="fechaValor" values="Ingrese fecha para el valor de la moneda" style="width: 94px; margin-right: 60;" />     
          <td style="width: 138px; height: 28px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Valor Actual:</td>
         <td style="width: 50px; height: 28px;"><input type="text" name="fechaValor" values="Ingrese valor Actual" style="width: 94px" /></td>     
        </tr>
    </table>
    <br />
    <br />
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
           
           
        
        <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 352px; top:424px; position: absolute; height: 133px; width: 268px; right: 232px">
           </asp:GridView>







</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantTipoRepuesto.aspx.cs" Inherits="Mitaller.Wf_MantTipoRepuesto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR TIPO DE REPUESTO </h3>
    <p>Ingrese el Servicio o utilice las opciones para buscar o eliminar.</p>

     <table class="table" style="height: 10px">
       <tr>
        <td class="modal-sm" style="width: 102px; height: 51px;">
             Nro Docto. Numérico: 
        </td>
        <td style="width: 38px; height: 51px;"><input type="text" name="nrodoctocompra" values="Ingrese Nro Dcto." style="width: 41px" /></td>
         <td style="width: 170px; height: 51px;">Fecha Recepcion:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="fechaRecep" values="Ingrese Fecha del repuesto" style="width: 239px" /></td>
        <td style="width: 170px; height: 51px;">Codigo del Emleado:</td>
        <td style="width: 50px; height: 51px;"><input type="text" name="codEmp" values="Ingrese descripcion del repuesto" style="width: 239px" /></td>
        
    </tr>            
    </table>  


        


</asp:Content>
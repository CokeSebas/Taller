<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_Clientes.aspx.cs" Inherits="Mitaller.Wf_Clientes" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%--<asp:DropDownList ID="ddListciudad" runat="server" OnSelectedIndexChanged="ddListciudad_SelectedIndexChanged" style="top: 300px; left: 900px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%>.</h2>
    <h3>REGISTRO DE PROVEEDORES</h3>
    <p>Ingrese los datos del nuevo Proveedor o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 150px">
            <tr>
               <td class="modal-sm" style="width: 126px">
                Cod. Proveedor: 
               </td>
                <td style="width: 187px"><input type="text" name="codprov" values="Ingrese Codigo" /></td>
                 <td style="width: 109px">Rut Proveedor:</td>
                <td style="width: 89px"><input type="text" name="rutprov" values="ingrese rut" style="width: 95px" /></td>
                <td style="width: 153px">Fecha ingreso :</td>
                <td style="width: 147px"><input type="text" name="feIng" values="ingrese Fe. Ingreso." style="width: 96px" /></td>
            </tr>
           <tr>
               <td style="width: 126px">Nombre Proveedor :</td>
               <td style="width: 187px"><input type="text" name="nombreprov" values="ingrese nombre" style="width: 211px" /></td>
               <td style="width: 109px">Direccion :</td>
               <td style="width: 89px"><input type="text" name="direprov" values="ingrese direccion." style="width: 190px" /></td>
               <td style="width: 153px">Giro :</td>
               <td style="width: 89px"><input type="text" name="giro" values="ingrese giro." style="width: 161px" /></td>
           </tr>
           </Table>
           <table>
            <tr>
                 <td style="width: 118px; height: 68px;">Fono :</td>     
                 <td style="width: 177px; height: 68px;" class="modal-sm"><input type="text" name="fono" values="ingrese fono" style="width: 118px" /></td>
                 <td style="width: 59px; height: 68px;">Movil :</td>
                 <td style="width: 161px; height: 68px;" class="modal-sm"><input type="text" name="movil" values="ingrese movil" style="width: 116px" /></td>
                 <td style="width: 54px; height: 68px;">Email :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="email" values="ingrese email" style="width: 239px" /></td>
            
                 
            </tr>
        </table>
           <Table> 
             <tr>
                 <td style="width: 79px; height: 68px;">Comuna :</td>
                 <td style="width: 227px; height: 68px;" class="modal-sm"><input type="text" name="comuna" values="ingrese comuna" style="width: 168px" /></td>
                  <%--<asp:DropDownList ID="ddListcomuna" runat="server" OnSelectedIndexChanged="ddListcomuna_SelectedIndexChanged" style="top: 300px; left: 600px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%>
                 <td style="width: 63px; height: 68px;">Ciudad :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="ciudad" values="ingrese ciudad" style="width: 182px" /></td>
                 <%--<asp:DropDownList ID="ddListciudad" runat="server" OnSelectedIndexChanged="ddListciudad_SelectedIndexChanged" style="top: 300px; left: 900px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%> 
                 
            
                 </tr>
               </Table>
       
              
                  
          <tr>
            <td class="modal-sm" style="width: 171px" colspan="3"></td>
            <td>
                <asp:Button ID="btnInserta" runat="server" Text="Inserta" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 171px">
                <asp:Button ID="btnActualiza" runat="server" Text="Actualiza" OnClick="Button2_Click" /></td>
            <td>
                <asp:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="Button3_Click" /></td>
        </tr>
        <tr><td class="modal-sm" style="width: 171px">
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" OnClick="Button4_Click" /></td></tr>
    </table>   
           
           
          
      
            <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 352px; top:665px; position: absolute; height: 133px; width: 268px; right: 651px">
            </asp:GridView>
           
        
    
         
</asp:Content>
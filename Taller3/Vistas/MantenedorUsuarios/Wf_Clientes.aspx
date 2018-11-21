<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_Clientes.aspx.cs" Inherits="Mitaller.Wf_Clientes" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%--<asp:DropDownList ID="ddListciudad" runat="server" OnSelectedIndexChanged="ddListciudad_SelectedIndexChanged" style="top: 300px; left: 900px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%>.</h2>
    <h3>REGISTRO DE CLIENTES FIDELIZADOS</h3>
    <p>Ingrese los datos del nuevo Cliente o utilice las opciones para buscar o eliminar.</p>
    <table class="table">
            <tr>
               <td class="modal-sm" style="width: 118px">
                Cod. Cliente: 
               </td>
                <td style="width: 187px"><input type="text" name="codclie" values="Ingrese Codigo" /></td>
                 <td style="width: 108px">Rut Cliente:</td>
                <td style="width: 89px"><input type="text" name="rut" values="ingrese rut" style="width: 95px" /></td>
                <td style="width: 108px">Fecha ingreso :</td>
                <td style="width: 147px"><input type="text" name="feIng" values="ingrese Fe. Ingreso." style="width: 96px" /></td>
            </tr>
           <tr>
               <td style="width: 118px">Nombre Cliente :</td>
               <td style="width: 187px"><input type="text" name="nombreclie" values="ingrese nombre" style="width: 211px" /></td>
               <td style="width: 111px">Apellido Pat. :</td>
               <td style="width: 89px"><input type="text" name="apepat" values="ingrese apellido pat." style="width: 190px" /></td>
               <td style="width: 111px">Apellido Mat. :</td>
               <td style="width: 89px"><input type="text" name="apemat" values="ingrese apellido mat." style="width: 161px" /></td>
           </tr>
           </Table>
           <Table> 
             <tr>
                <td style="width: 118px; height: 68px;">Dirección :</td>
                <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="Direccion" values="ingrese direccion" style="width: 309px" /></td>
                <td style="width: 197px; height: 68px;">Comuna :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="comuna" values="ingrese comuna" style="width: 251px" /></td>
                  <%--<asp:DropDownList ID="ddListcomuna" runat="server" OnSelectedIndexChanged="ddListcomuna_SelectedIndexChanged" style="top: 300px; left: 600px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%>
                 <td style="width: 118px; height: 68px;">Ciudad :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="ciudad" values="ingrese ciudad" style="width: 182px" /></td>
                 <%--<asp:DropDownList ID="ddListciudad" runat="server" OnSelectedIndexChanged="ddListciudad_SelectedIndexChanged" style="top: 300px; left: 900px; right: 100px; position: absolute; height: 22px; width: 150px"></asp:DropDownList>--%> 
                 
            
                 </tr>
               </Table>
        <table>
            <tr>
                 <td style="width: 118px; height: 68px;">Fono :</td>     
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="fono" values="ingrese fono" style="width: 118px" /></td>
                 <td style="width: 118px; height: 68px;">Movil :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="movil" values="ingrese movil" style="width: 116px" /></td>
                 <td style="width: 118px; height: 68px;">Email :</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="email" values="ingrese email" style="width: 239px" /></td>
            
                 
            </tr>
        </table>
        <table>
            <h3>&nbsp;DEFINA EL USUARIO Y PASSWORD</h3>
                 <td style="width: 118px; height: 68px;"> USUARIO:</td>
                 <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="usuario" values="ingrese usuario" style="width: 166px" /></td>
                 <td style="width: 118px; height: 68px;"> PASSWORD:</td>
                <td style="width: 319px; height: 68px;" class="modal-sm"><input type="text" name="password" values="ingrese password" style="width: 156px" /></td>
        </table>
                         
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
            <asp:GridView ID="GridView1" runat="server" style="z-index: 1; left: 352px; top:665px; position: absolute; height: 133px; width: 268px; right: 651px">
           </asp:GridView>
          
</asp:Content>


    

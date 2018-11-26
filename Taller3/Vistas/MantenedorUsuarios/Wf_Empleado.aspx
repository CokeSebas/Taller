<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_Empleado.aspx.cs" Inherits="Mitaller.Wf_Empleados" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        
    <h2><%: Title %>.</h2>
    <h3>REGISTRO DE EMPLEADOS</h3>
    <p>Ingrese los datos del nuevo Empleado o utilice las opciones para buscar o eliminar.</p>
    <table class="table">
            <tr>
               <td class="modal-sm" style="width: 83px">
                Cod. Empleado: 
               </td>
                <td style="width: 59px"><input type="text" name="codemp" values="Ingrese Codigo" /></td>
                 <td style="width: 155px">Rut Empleado:</td>
                <td style="width: 89px"><input type="text" name="rut" values="ingrese rut" style="width: 95px" /></td>
                <td style="width: 111px">Fecha Nacimiento :</td>
                <td style="width: 147px"><input type="text" name="feNac" values="ingrese Fe. Nac." style="width: 96px" /></td>
                <td style="width: 108px">Fecha ingreso :</td>
                <td style="width: 147px"><input type="text" name="feIng" values="ingrese Fe. Ingreso." style="width: 96px" /></td>
            </tr>
           <tr>
               <td style="width: 108px">Fecha Término :</td>
               <td style="width: 147px"><input type="text" name="feIng" values="ingrese Fe. Ingreso." style="width: 96px" /></td>
               <td style="width: 155px">Nombre Empleado :</td>
               <td style="width: 89px"><input type="text" name="nombreclie" values="ingrese nombre" style="width: 211px" /></td>
               <td style="width: 111px">Apellido Pat. :</td>
               <td style="width: 89px"><input type="text" name="apepat" values="ingrese apellido pat." style="width: 190px" /></td>
               <td style="width: 111px">Apellido Mat. :</td>
               <td style="width: 89px"><input type="text" name="apemat" values="ingrese apellido mat." style="width: 161px" /></td>
           </tr>
            <tr>
               <td style="width: 108px">Cargo :</td>
               <td><asp:DropDownList ID="ddListCargo" runat="server" OnSelectedIndexChanged="ddListCargo_SelectedIndexChanged" style="width: 161px"></asp:DropDownList></td>
                             
            </tr>
           </table>
         
           <table>
            <tr>
                <td style="width: 129px"> Direccion :</td>
                <td style="width: 90px"><input type="text" name="direccion" values="ingrese direccion" style="width: 502px; margin-left: 0;" /></td>
                <td style="left:200px; width: 138px;";"width:400px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sueldo (Bruto) :</td>      
                <td style="width: 90px"><input type="text" name="sueldo" values="ingrese sueldo bruto" style="width: 100px" /></td>
            </tr>
            
            </table>
            <br />
          
            <table>
                <tr>
                <td style="width: 111px">&nbsp;Fono :</td>
                <td style="width: 89px"><input type="text" name="fono" values="ingreso Fono:" style="width: 153px" /></td>
                <td style="width: 67px">&nbsp;&nbsp; Movil :</td>
                <td style="width: 89px"><input type="text" name="movil" values="ingrese Movil:" style="width: 122px" /></td>      
                <td style="width: 87px">&nbsp;&nbsp; Comuna :</td>
                <td style="width: 89px"><input type="text" name="comuna" values="ingrese comuna" style="width: 127px" /></td>
                <td style="width: 85px">&nbsp;&nbsp;&nbsp; Ciudad :</td>
                <td style="width: 89px"><input type="text" name="ciudad" values="ingrese ciudad" style="width: 161px" /></td>
                
                
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
    </table>   
         
          
                     
        
    
         
</asp:Content>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    <%--<div style="width: 1037px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="REGISTRO DE EMPLEADOS"></asp:Label>
             <br />
            <br />
        <br />
        <br />
        <br />
        <br />
          <br />
        <br />

            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Cod. Empleado: "></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCodEmp" runat="server" Width="49px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Rut :"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRut" runat="server" Width="76px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="Fecha Nacimiento : "></asp:Label>
            <asp:TextBox ID="txtFeNac" runat="server" Width="78px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="Fecha Ingreso : "></asp:Label>
            <asp:TextBox ID="txtFeIngreso" runat="server" Width="85px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Fecha Término : "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Nombre Empleado:" style="top: 86px; left: 30px; position: absolute; height: 19px; width: 137px"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNombre" runat="server" style="top: 109px; left: 19px; position: absolute; height: 22px; width: 180px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="Apellido Paterno :  " style="top: 90px; left: 254px; position: absolute; height: 19px; width: 113px; right: 674px"></asp:Label>
            <asp:TextBox ID="txtApePat" runat="server" Font-Size="Small" style="top: 107px; left: 220px; position: absolute; height: 22px; width: 245px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="Apellido Materno: " style="top: 83px; left: 542px; position: absolute; height: 19px; width: 114px"></asp:Label>
            <asp:TextBox ID="txtApeMat" runat="server" style="top: 104px; position: absolute; height: 22px; width: 245px; left: 520px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="Cargo: " style="top: 156px; left: 23px; position: absolute; height: 19px; width: 45px"></asp:Label>
            <asp:DropDownList ID="ddListCargo" runat="server" OnSelectedIndexChanged="ddListCargo_SelectedIndexChanged" style="top: 178px; left: 14px; position: absolute; height: 18px; width: 111px; right: 916px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="Fono Contacto : " style="top: 155px; left: 192px; position: absolute; height: 19px; width: 103px"></asp:Label>
            <asp:TextBox ID="txtFono" runat="server" Width="93px" Font-Size="Small" style="top: 174px; left: 189px; position: absolute; height: 22px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" Text="Nro. Móvil : " style="top: 151px; left: 362px; position: absolute; height: 19px; width: 79px; bottom: 188px;"></asp:Label>
            <asp:TextBox ID="txtCelular" runat="server" Width="95px" style="top: 170px; left: 351px; position: absolute; height: 22px"></asp:TextBox>
             &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label16" runat="server" Text="Remuneracion (Bruto) : " style="top: 147px; left: 560px; position: absolute; height: 19px; width: 170px"></asp:Label>
            <asp:TextBox ID="txtRemuneracion" runat="server" style="margin-bottom: 0px; top: 170px; left: 588px; position: absolute; height: 22px;" Width="101px"></asp:TextBox>
            <br />
            <br />
           
            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" Text="Dirección Particular : " style="top: 220px; left: 29px; position: absolute; height: 19px; width: 130px"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" Font-Size="X-Large" style="top: 248px; left: 14px; position: absolute; height: 22px; width: 680px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
                 &nbsp;&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Text="Asignar Usuario y Password" style="top: 197px; left: 814px; position: absolute; height: 19px; width: 172px"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label13" runat="server" Text="Seleccione Comuna : " style="top: 288px; left: 16px; position: absolute; height: 19px; width: 131px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label14" runat="server" Text="Seleccione Ciudad : " style="top: 289px; left: 174px; position: absolute; height: 19px; width: 124px"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddListCiudad" runat="server" OnSelectedIndexChanged="ddListCargo_SelectedIndexChanged" style="top: 311px; left: 171px; position: absolute; height: 22px; width: 91px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label18" runat="server" style="z-index: 1; left: 768px; top: 238px; position: absolute" Text="Usuario : "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 841px; top: 236px; position: absolute; height: 21px"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; left: 843px; top: 282px; position: absolute"></asp:TextBox>
            <asp:DropDownList ID="ddListComuna" runat="server" OnSelectedIndexChanged="ddListCargo_SelectedIndexChanged" style="top: 311px; left: 26px; position: absolute; height: 22px; width: 91px">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label19" runat="server" style="z-index: 1; left: 770px; top: 280px; position: absolute" Text="Password : "></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>--%>

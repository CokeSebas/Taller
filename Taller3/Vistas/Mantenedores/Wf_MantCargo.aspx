<%@ Page Title="Módulo Mantenedor de Cargos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantCargo.aspx.cs" Inherits="Mitaller.Wf_MantCargo" %>

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h3>MANTENEDOR DE CARGOS PARA EMPLEADOS</h3>
     <div class="alert alert-success" id="Cargo" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Cargo Ingresada Con Exito
     </div>
     <div class="alert alert-danger" id="CargoElim" style="visibility:hidden; float:right;">
          <strong>Correcto!</strong> Cargo Elminada Con Exito
     </div> 
    <p>Ingrese el Cargo o utilice las opciones para buscar o eliminar.</p>
    <table class="table" style="height: 10px">
        <tr>
            <td >Descripcion del Cargo:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtCargo" Width="286px"></asp:textbox>
            </td>
        </tr>    
        <tr>
            <td style="width: 78px">
                <asp:button runat="server" text="Insertar" ID="btnInsertar" class="btn btn-success" OnClick="btnInsertar_Click" />
            </td>
            <td>
                <asp:button runat="server" text="Eliminar"  id="btnEliminar" class="btn btn-danger" OnClick="btnEliminar_Click"/>
            </td>
        </tr>
    </table>
    <table style="table">
        <tr>
            <td colspan="3">
                <asp:gridview runat="server" id="dgvCargos"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
        
       
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantProvincias.aspx.cs" Inherits="Taller3.Vistas.Mantenedores.Wf_MantProvincias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE PROVINCIAS</h3>
    <div class="alert alert-success" id="Provincia" style="visibility:hidden; float:left;">
          <strong>Correcto!</strong> Provincia Ingresada Con Exito
     </div>
     <div class="alert alert-danger" id="ProvinciaElim" style="visibility:hidden; float:right;">
          <strong>Correcto!</strong> Provincia Elminada Con Exito
     </div> 
    <p>Ingrese una Nueva Provincia.</p>

    <table class="table" style="height: 10px">
        <tr>
            <td>Region a la Cual Pertenece</td>
            <td>
                <asp:DropDownList ID="cbbRegion" runat="server" ></asp:DropDownList>
            </td>
        </tr> 
        <tr>
            <td >Nombre de Provincia:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtProvincia" Width="286px"></asp:textbox>
            </td>   
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
                <asp:gridview runat="server" id="dgvProvincias"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
</asp:Content>

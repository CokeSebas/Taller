﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Wf_MantServicios.aspx.cs" Inherits="Mitaller.Wf_MantServicios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>MANTENEDOR DE TIPOS DE SERVICIOS</h3>
    <p>Ingrese el Tipo de Servicio o utilice las opciones para buscar o eliminar.</p>

    <table class="table" style="height: 10px">
        <tr>
            <td >Descripcion del Servicio:</td>
            <td style="width: 50px; height: 51px;">
                <asp:textbox runat="server" id="txtServicio" Width="286px"></asp:textbox>
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
                <asp:gridview runat="server" id="dgvServicios"></asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button runat="server" text="Excel" id="btnExcel" OnClick="btnExcel_Click" class="btn btn-info" />
            </td>
        </tr>
    </table>
</asp:Content>
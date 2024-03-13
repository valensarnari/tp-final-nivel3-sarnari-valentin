<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Views.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="my-3">
        <h1>Error!</h1>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div class="mb-3">
        <a href="Default.aspx" class="btn btn-danger">Volver al catálogo</a>
    </div>
</asp:Content>

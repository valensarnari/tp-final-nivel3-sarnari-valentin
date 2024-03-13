<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Views.Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" DataKeyNames="Id" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table my-3" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion"/>
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion"/>
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
            <asp:CommandField ShowSelectButton="true" SelectText="✏️" />
            <%--<asp:BoundField HeaderText="Url de imagen" DataField="ImagenUrl"/>--%>
        </Columns>
    </asp:GridView>
    <a href="Alta.aspx" class="mb-3 btn btn-primary">Agregar artículo</a>
</asp:Content>

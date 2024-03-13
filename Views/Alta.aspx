<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="Views.Alta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <style>
        .imagen {
            max-height: 40%;
            max-width: 40%;
            border: 1px solid #000;
        }
    </style>

    <div class="row">
        <%--COLUMNA IZQUIERDA--%>
        <div class="col-5 mx-auto">
            <div class="my-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <%--COLUMNA DERECHA--%>
        <div class="col-5 mx-auto">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="my-3">
                        <label for="txtImagenUrl" class="form-label">Url de imagen</label>
                        <asp:TextBox AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" ID="txtImagenUrl" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Image CssClass="imagen" ID="imgArticulo" runat="server" ImageUrl="https://t3.ftcdn.net/jpg/03/45/05/92/360_F_345059232_CPieT8RIWOUk4JqBkkWkIETYAkmz2b75.jpg" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mt-3">
                <asp:Button OnClick="btnAgregar_Click" ID="btnAgregar" runat="server" Text="Agregar artículo" CssClass="btn btn-primary" />
                <asp:Button OnClick="btnModificar_Click" ID="btnModificar" runat="server" Text="Modificar artículo" CssClass="btn btn-primary" Visible="false" />
                <a href="Administracion.aspx" class="btn btn-outline-primary">Volver atrás</a>
            </div>
            <div class="mt-1">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar artículo" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>

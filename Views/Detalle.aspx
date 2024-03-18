<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Views.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .imagen {
            border: 1px solid #000;
            max-width: 350px;
        }
    </style>

    <div class="row my-5">
        <div class="col-4">
            <asp:Image ID="imgArticulo" CssClass="img-fluid imagen" runat="server" />
        </div>
        <div class="col">
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox ID="txtId" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Código</label>
                        <asp:TextBox ID="txtCodigo" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtMarca" class="form-label">Marca</label>
                        <asp:TextBox ID="txtMarca" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtCategoria" class="form-label">Categoría</label>
                        <asp:TextBox ID="txtCategoria" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="mb-3">
                        <label for="txtUrl" class="form-label">Url imagen</label>
                        <asp:TextBox ID="txtUrl" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row mb-5">
        <div class="col d-flex justify-content-center">
            <asp:Button ID="btnAgregarFavorito" CssClass="btn btn-primary mx-1" OnClick="btnAgregarFavorito_Click" runat="server" Text="Agregar a favorito" />
            <asp:Button ID="btnQuitarFavorito" CssClass="btn btn-primary mx-1" OnClick="btnQuitarFavorito_Click" runat="server" Text="Quitar de favorito" />
            <a href="Default.aspx" class="btn btn-outline-primary mx-1">Volver atrás</a>
        </div>
    </div>
</asp:Content>

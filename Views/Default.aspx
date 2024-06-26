﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .imagen {
            object-fit: contain;
            height: 250px;
            width: 250px;
        }
    </style>

    <div class="row my-5 gap-2">
        <div class="row mx-auto">
            <div class="col bg-light">
                <div class="row d-flex align-items-end py-2">
                    <div class="col"></div>
                    <div class="col-xl-4">
                        <div class="my-2">
                            <label for="txtFiltroBasico" class="form-label">Búsqueda por nombre:</label>
                            <asp:TextBox ID="txtFiltroBasico" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xl-2 my-2">
                        <asp:Button ID="btnBuscarBasico" OnClick="btnBuscarBasico_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                        <asp:Button ID="btnResetBasico" OnClick="btnResetBasico_Click" CssClass="btn btn-outline-primary" runat="server" Text="Reset" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row gap-2 mx-auto">
            <div class="col-lg-3 bg-light">
                <div class="mt-5 mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlPrecio" class="form-label">Precio (Formato: 1000.10 / 100)</label>
                    <asp:DropDownList ID="ddlPrecio" CssClass="form-control mb-1" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ControlToValidate="txtPrecio" runat="server" ErrorMessage="Revise que el formato sea el correcto *" Style="color: red;" ValidationExpression="^\d+(?:\.\d{0,2})?$"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3 d-flex justify-content-center">
                    <asp:Button ID="btnFiltroAvanzado" CssClass="btn btn-primary mx-1" OnClick="btnFiltroAvanzado_Click" runat="server" Text="Filtrar" />
                    <asp:Button ID="btnResetAvanzado" CssClass="btn btn-outline-primary mx-1" OnClick="btnResetAvanzado_Click" runat="server" Text="Reset" />
                </div>
            </div>
            <div class="col bg-light">
                <div class="row row-cols-1 row-cols-lg-2 g-4 py-3">
                    <%Controllers.FavoritoController controller = new Controllers.FavoritoController();
                        foreach (Models.Articulo articulo in ListaArticulos)
                        { %>
                    <div class="col">
                        <div class="card m-3" style="min-width: 255px">
                            <div style="align-self: center">
                                <img src="<%: articulo.ImagenUrl %>" class="card-img-top imagen" alt="Imagen del artículo">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title"><%: articulo.Nombre %></h5>
                                <p class="card-text"><%: articulo.Descripcion %></p>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">$<%: articulo.Precio %></li>
                                <li class="list-group-item">
                                    <a href="#" class="btn btn-outline-dark"><%: articulo.Marca.Descripcion %></a>
                                    <a href="#" class="btn btn-outline-dark"><%: articulo.Categoria.Descripcion %></a>
                                </li>
                            </ul>
                            <div class="card-body">
                                <a href="Detalle.aspx?id=<%: articulo.Id %>" class="m1-2 btn btn-primary">Ver detalle</a>
                            </div>
                        </div>
                    </div>
                    <%}%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

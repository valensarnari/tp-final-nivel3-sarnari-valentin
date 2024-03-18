<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Views.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .imagen {
            height: 400px;
            border: 1px solid #000;
        }
    </style>

    <div class="row my-5">
        <div class="col bg-light">
            <div class="row row-cols-1 row-cols-md-3 g-4 py-3">
                <%Controllers.FavoritoController controller = new Controllers.FavoritoController();
                    foreach (Models.Articulo articulo in ListaArticulos)
                    {
                        if (controller.EsFavorito(articulo, (Models.User)Session["user"]))
                        {%>
                <div class="col">
                    <div class="card m-3" style="max-width: 400px">
                        <div>
                            <img src="<%: articulo.ImagenUrl %>" class="card-img-top imagen" alt="Imagen del artículo">
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.Nombre %></h5>
                            <p class="card-text"><%: articulo.Descripcion %></p>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item"><%: articulo.Precio %></li>
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
                        <%}
                    }%>
            </div>
        </div>
    </div>
</asp:Content>

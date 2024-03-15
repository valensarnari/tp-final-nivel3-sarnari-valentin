<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .imagen {
            height: 400px;
            border: 1px solid #000;
        }
        /*@supports(object-fit: cover) {
            .imagen {
                height: 100%;
                object-fit: cover;
                object-position: center center;
            }
        }*/
    </style>

    <div class="row my-5 gap-3">
        <div class="row">
            <div class="col bg-danger" style="height: 100px"></div>
        </div>
        <div class="row gap-3">
            <div class="col-3 bg-primary" style="height: 500px"></div>
            <div class="col bg-light">
                <div class="row row-cols-1 row-cols-md-2 g-4 py-3">
                    <asp:Repeater runat="server" ID="repRepeater">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card m-3" style="width:400px">
                                    <div>
                                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top imagen" alt="Imagen del artículo">
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Descripcion") %></p>
                                    </div>
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item"><%#Eval("Precio") %></li>
                                        <li class="list-group-item">
                                            <a href="#" class="btn btn-primary"><%#Eval("Marca.Descripcion") %></a>
                                            <a href="#" class="btn btn-danger"><%#Eval("Categoria.Descripcion") %></a>
                                        </li>
                                    </ul>
                                    <div class="card-body">
                                        <asp:Button ID="btnFavorito" runat="server" Text="Agregar a favorito" CssClass="btn btn-outline-primary" />
                                        <a href="#" class="mx-2 card-link">Ver detalle</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

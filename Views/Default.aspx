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
            <div class="col bg-light">
                <div class="row d-flex align-items-end py-2">
                    <div class="col"></div>
                    <div class="col-4">
                        <div class="my-2">
                            <label for="txtFiltroBasico" class="form-label">Búsqueda por nombre:</label>
                            <asp:TextBox ID="txtFiltroBasico" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-2 my-2">
                        <asp:Button ID="btnBuscarBasico" OnClick="btnBuscarBasico_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                        <asp:Button ID="btnResetBasico" OnClick="btnResetBasico_Click" CssClass="btn btn-outline-primary" runat="server" Text="Reset" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row gap-3">
            <div class="col-3 bg-light">
                <div class="mt-5 mb-3">
                    <label for="ddlMarca" class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlPrecio" class="form-label">Precio</label>
                    <asp:DropDownList ID="ddlPrecio" CssClass="form-control mb-1" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3 d-flex justify-content-center">
                    <asp:Button ID="btnFiltroAvanzado" CssClass="btn btn-primary mx-1" OnClick="btnFiltroAvanzado_Click" runat="server" Text="Filtrar" />
                    <asp:Button ID="btnResetAvanzado" CssClass="btn btn-outline-primary mx-1" OnClick="btnResetAvanzado_Click" runat="server" Text="Reset" />
                </div>
            </div>
            <div class="col bg-light">
                <div class="row row-cols-1 row-cols-md-2 g-4 py-3">
                    <asp:Repeater runat="server" ID="repRepeater">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card m-3" style="width: 400px">
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
                                            <a href="#" class="btn btn-outline-dark"><%#Eval("Marca.Descripcion") %></a>
                                            <a href="#" class="btn btn-outline-dark"><%#Eval("Categoria.Descripcion") %></a>
                                        </li>
                                    </ul>
                                    <div class="card-body">
                                        <%--<a href="#" class="btn btn-primary">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-star-fill" viewBox="0 0 16 16">
                                                <path d="M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z" />
                                            </svg>
                                        </a>--%>
                                        <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="m1-2 btn btn-primary">Ver detalle</a>
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

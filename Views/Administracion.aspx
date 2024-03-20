<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Views.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md my-1">
            <div class="my-md-3">
                <label for="ddlCampo" class="form-label">Campo</label>
                <asp:DropDownList AutoPostBack="true" ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md my-1">
            <div class="my-md-3">
                <label for="ddlCriterio" class="form-label">Criterio</label>
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md my-1">
            <div class="my-md-3">
                <label for="txtFiltro" class="form-label">Filtro</label>
                <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md my-1 d-flex align-items-end">
            <div class="my-md-3">
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                <asp:Button ID="btnReset" CssClass="btn btn-outline-primary" OnClick="btnReset_Click" runat="server" Text="Reset" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="table-responsive">
            <asp:GridView runat="server" DataKeyNames="Id" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table my-3" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✏️" />
                    <%--<asp:BoundField HeaderText="Url de imagen" DataField="ImagenUrl"/>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <a href="Alta.aspx" class="mb-3 btn btn-primary">Agregar artículo</a>
        </div>
    </div>
</asp:Content>

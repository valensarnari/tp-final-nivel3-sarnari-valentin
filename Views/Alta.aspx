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
        <div class="col-md-5 mx-auto">
            <div class="my-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtCodigo" Style="color: red;" runat="server" ErrorMessage="El campo Código es obligatorio *"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtNombre" Style="color: red;" runat="server" ErrorMessage="El campo Nombre es obligatorio *"></asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtDescripcion" Style="color: red;" runat="server" ErrorMessage="El campo Descripción es obligatorio *"></asp:RequiredFieldValidator>
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
                <label for="txtPrecio" class="form-label">Precio (Formato: 1000.10 / 100)</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ControlToValidate="txtPrecio" runat="server" ErrorMessage="Revise que el formato sea el correcto *" Style="color: red;" ValidationExpression="^\d+(?:\.\d{0,2})?$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <%--COLUMNA DERECHA--%>
        <div class="col-md-5 mx-auto">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="my-3">
                        <label for="txtImagenUrl" class="form-label">Url de imagen</label>
                        <asp:TextBox AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" ID="txtImagenUrl" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtImagenUrl" Style="color: red;" runat="server" ErrorMessage="El campo Url de imagen es obligatorio *"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Image CssClass="imagen" ID="imgArticulo" runat="server" ImageUrl="https://t3.ftcdn.net/jpg/03/45/05/92/360_F_345059232_CPieT8RIWOUk4JqBkkWkIETYAkmz2b75.jpg" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mt-3">
                <asp:Button OnClick="btnAgregar_Click" ID="btnAgregar" runat="server" Text="Agregar artículo" CssClass="btn btn-primary" />
                <asp:Button OnClick="btnModificar_Click" ID="btnModificar" runat="server" Text="Modificar artículo" CssClass="btn btn-primary" Visible="false" />
                <a href="Administracion.aspx" class="btn btn-outline-primary">Volver atrás</a>
            </div>
            <div class="mt-2">
                <asp:Button Visible="false" OnClick="btnEliminar_Click" ID="btnEliminar" runat="server" Text="Eliminar artículo" CssClass="btn btn-danger" />
            </div>
            <div class="mt-4">
                <asp:DropDownList Visible="false" Width="30%" ID="ddlConfirmoEliminar" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:Button Visible="false" OnClick="btnConfirmoEliminar_Click" ID="btnConfirmoEliminar" runat="server" Text="Confirmo eliminación" CssClass="btn btn-danger mt-1" />
            </div>
        </div>
    </div>
</asp:Content>

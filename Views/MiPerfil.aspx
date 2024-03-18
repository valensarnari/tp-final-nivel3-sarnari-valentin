<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Views.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <style>
        .imagen {
            max-width: 330px;
        }
    </style>

    <div class="row my-5">
        <%--COLUMNA IZQUIERDA--%>
        <div class="col-5 mx-auto">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-3">
                <label class="form-label">Imagen de perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>

            <div class="mb-1 mt-5">
                <asp:Button ID="btnActualizar" OnClick="btnActualizar_Click" CssClass="btn btn-primary" runat="server" Text="Actualizar" />
                <a class="btn btn-outline-primary" href="Default.aspx">Volver atrás</a>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="btn btn-danger" runat="server" Text="Cerrar sesión" />
            </div>
        </div>
        <%--COLUMNA DERECHA--%>
        <div class="col-5 mx-auto">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Image CssClass="img-fluid mb-3 imagen" ID="imgMiPerfil" runat="server" ImageUrl="https://media.istockphoto.com/id/1337144146/vector/default-avatar-profile-icon-vector.jpg?s=612x612&w=0&k=20&c=BIbFwuv7FxTWvh5S3vB6bkT0Qv8Vn8N5Ffseq84ClGI=" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-5 mx-auto">
            <div class="card my-5">
                <h4 class="card-header text-center">Login</h4>
                <div class="card-body">
                    <div class="my-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-4">
                        <label for="txtPass" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col d-flex align-items-center flex-column">
                            <div class="mb-3">
                                <asp:Button ID="btnLogin" CssClass="btn btn-primary" OnClick="btnLogin_Click" runat="server" Text="Ingresar" />
                                <a href="Default.aspx" class="btn btn-outline-primary">Volver atrás</a>
                            </div>
                            <div class="mb-3">
                                <a href="Signup.aspx">No tenés cuenta? Creala acá</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

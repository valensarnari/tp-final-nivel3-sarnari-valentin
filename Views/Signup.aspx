<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Views.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-5 mx-auto">
            <div class="card my-5">
                <h4 class="card-header text-center">Sign Up</h4>
                <div class="card-body">
                    <div class="my-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-4">
                        <label for="txtPass" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="row mx-auto">
                        <div class="col"></div>
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Registrar" />
                                <a href="Default.aspx" class="btn btn-outline-primary">Volver atrás</a>
                            </div>
                            <div class="mb-3">
                                <a href="Login.aspx">Ya tenés cuenta? Ingresá acá</a>
                            </div>
                        </div>
                        <div class="col"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

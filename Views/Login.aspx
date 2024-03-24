<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-5 mx-auto">
            <div class="card my-5">
                <h4 class="card-header text-center">Login</h4>
                <div class="card-body">
                    <div class="mt-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server" ErrorMessage="Revise que el formato sea el correcto *" Style="color: red;" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mb-3">
                        <label for="txtPass" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtPass" Style="color: red;" runat="server" ErrorMessage="El campo Contraseña es obligatorio *"></asp:RequiredFieldValidator>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Login</h2>
  <fieldset>
    <legend>Credentials</legend>
    <% using(Html.BeginForm(new { action = "Create" })) { %>
    <%= Volrath.HtmlHelper.ContinueInputHidden() %>
    <div>Login: <input type="text" name="Login" /></div>
    <div>Senha: <input type="password" name="Password" /></div>
    <p><input type="submit" value="Entrar" /></p>
    <% } %>
  </fieldset>
</asp:Content>

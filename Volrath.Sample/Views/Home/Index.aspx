<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Index</h2>
  <ul>
    <li><a href="/session/new">Login</a></li>
    <li><a href="/session/destroy">Logout</a></li>
    <li><a href="/secret">Segredo...</a></li>
  </ul>
</asp:Content>

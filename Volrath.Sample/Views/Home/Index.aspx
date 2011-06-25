<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Index</h2>
  <ul>
    <li><a href="/Session/New">Login</a></li>
    <li><a href="/Session/Destroy">Logout</a></li>
    <li><a href="/Secret">Segredo...</a></li>
  </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Volrath.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  New
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>New</h2>
  <% using (Html.BeginForm(new { action = "create" })) {%>
  <%= Html.ValidationSummary(true)%>
  <fieldset>
    <legend>Fields</legend>
    <div class="editor-label">
      <%= Html.LabelFor(model => model.Name)%>
    </div>
    <div class="editor-field">
      <%= Html.TextBoxFor(model => model.Name)%>
      <%= Html.ValidationMessageFor(model => model.Name)%>
    </div>
    <div class="editor-label">
      <%= Html.LabelFor(model => model.Email)%>
    </div>
    <div class="editor-field">
      <%= Html.TextBoxFor(model => model.Email)%>
      <%= Html.ValidationMessageFor(model => model.Email)%>
    </div>
    <div class="editor-label">
      <%= Html.LabelFor(model => model.Password)%>
    </div>
    <div class="editor-field">
      <%= Html.TextBoxFor(model => model.Password)%>
      <%= Html.ValidationMessageFor(model => model.Password)%>
    </div>
    <p>
      <input type="submit" value="Create" />
    </p>
  </fieldset>
  <% } %>
  <div>
    <%= Html.ActionLink("Back to List", "Index") %>
  </div>
</asp:Content>

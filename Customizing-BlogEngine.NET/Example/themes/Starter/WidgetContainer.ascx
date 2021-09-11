<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_Code.Controls.WidgetContainer" %>

<div id="widget<%= Widget.WidgetId %>">

    <%= AdminLinks %>

    <% if (this.Widget.ShowTitle) { %>
        <h4><%= Widget.Title%></h4>
    <% } else { %>
        <br />
    <% } %>
    
    <asp:PlaceHolder ID="phWidgetBody" runat="server"></asp:PlaceHolder>

</div>

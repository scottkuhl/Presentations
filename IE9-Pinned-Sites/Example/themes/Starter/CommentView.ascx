<%@ Control Language="C#" EnableViewState="False" Inherits="BlogEngine.Core.Web.Controls.CommentViewBase" %>

<section id="id_<%=Comment.Id %>" class="vcard">

    <header>
        <%= Gravatar(28)%>
        <%= Comment.Website != null ? "<a href=\"" + Comment.Website + "\" rel=\"nofollow\" class=\"url fn\">" + Comment.Author + "</a>" : "<span class=\"fn\">" +Comment.Author + "</span>" %>
        <%= Flag %>
        <time><%= Comment.DateCreated %></time> <a href="#id_<%=Comment.Id %>">#</a>
    </header>

    <p><%= Text %></p>

    <footer>

        <p><%= AdminLinks.Length > 2 ? AdminLinks.Substring(2) : AdminLinks %> <%=ReplyToLink%></p>

        <p><asp:PlaceHolder ID="phSubComments" runat="server" /></p>

    </footer>
    
</section>
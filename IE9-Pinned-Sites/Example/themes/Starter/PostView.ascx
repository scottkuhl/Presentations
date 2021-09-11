<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="BlogEngine.Core.Web.Controls.PostViewBase" %>

<article class="xfolkentry" id="post<%=Index %>">

    <header>
        <h1><a href="<%=Post.RelativeLink %>"><%=Server.HtmlEncode(Post.Title) %></a></h1>    
        <p>
            by <a href="<%=VirtualPathUtility.ToAbsolute("~/") + "author/" + BlogEngine.Core.Utils.RemoveIllegalCharacters(Post.Author) %>.aspx"><%=Post.AuthorProfile != null ? Post.AuthorProfile.DisplayName : Post.Author %></a>
            on <time><%=Post.DateCreated.ToString("d. MMMM yyyy HH:mm") %></time>
        </p>
    </header>

    <asp:PlaceHolder ID="BodyContent" runat="server" />

    <footer>
        <p><%=Rating %> Tags: <%=TagLinks(", ") %> Categories: <%=CategoryLinks(", ") %></p>
        <p>
        
            <%=AdminLinks %>

            <% if (BlogEngine.Core.BlogSettings.Instance.ModerationType == BlogEngine.Core.BlogSettings.Moderation.Disqus) { %>
                <a rel="nofollow" href="<%=Post.PermaLink %>#disqus_thread"><%=Resources.labels.comments %></a>
            <%} else { %>
                <a rel="bookmark" href="<%=Post.PermaLink %>" title="<%=Server.HtmlEncode(Post.Title) %>">Permalink</a> |
                <a rel="nofollow" href="<%=Post.RelativeLink %>#comment"><%=Resources.labels.comments %> (<%=Post.ApprovedComments.Count %>)</a>   
            <%} %>
        </p>
    </footer>

</article>

<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="BlogEngine.Core.Web.Controls.PostViewBase" %>

  <!-- PIN PREVIEW CONTROLS: Add the social buttons -->
  <% if (Request.Url.AbsoluteUri.Contains("post")) { %>
       <script type="text/javascript">

           try {

               // Do this stuff if the site was launched as a pinned site.
               if (window.external.msIsSiteMode()) {
                   $.pinify.createThumbbarButtons({
                       buttons: [{
                           icon: '/themes/Standard/img/digg.ico',
                           name: 'Digg this article',
                           click: function () {
                               window.location = 'http://digg.com/submit?url=' + $('#url').val();
                           }
                       },
                    {
                            icon: '/themes/Standard/img/kicks.ico',
                            name: 'Kick this article',
                            click: function () {
                                window.location = 'http://www.dotnetkicks.com/submit?url=' + $('#url').val();
                            }
                        }]
                   });
               }
           }
           catch (ex) {
               // fail silently.
           }
       </script>
 <%}%>


<div class="post xfolkentry" id="post<%=Index %>">
  <input type="hidden" id="url" value="<%=Server.UrlEncode(Post.AbsoluteLink.ToString()) %>&amp;title=<%=Server.UrlEncode(Post.Title) %>"/>
  <h1><a href="<%=Post.RelativeLink %>" class="taggedlink"><%=Server.HtmlEncode(Post.Title) %></a></h1>
  <span class="author">by <a href="<%=VirtualPathUtility.ToAbsolute("~/") + "author/" + BlogEngine.Core.Utils.RemoveIllegalCharacters(Post.Author) %>.aspx"><%=Post.AuthorProfile != null ? Post.AuthorProfile.DisplayName : Post.Author %></a></span>
  <span class="pubDate"><%=Post.DateCreated.ToString("d. MMMM yyyy HH:mm") %></span>
  
  <div class="text"><asp:PlaceHolder ID="BodyContent" runat="server" /></div>
  <div class="bottom">
    <%=Rating %>
    <p class="tags">Tags: <%=TagLinks(", ") %></p>
    <p class="categories"><%=CategoryLinks(" | ") %></p>
  </div>

  <div class="footer">    
    <div class="bookmarks">
      <a rel="nofollow" title="Index <%=Index %>" target="_blank" href="http://www.dotnetkicks.com/submit?url=<%=Server.UrlEncode(Post.AbsoluteLink.ToString()) %>&amp;title=<%=Server.UrlEncode(Post.Title) %>">Submit to DotNetKicks...</a>
    </div>
    
    <%=AdminLinks %>
    
    <% if (BlogEngine.Core.BlogSettings.Instance.ModerationType == BlogEngine.Core.BlogSettings.Moderation.Disqus)
       { %>
    <a rel="nofollow" href="<%=Post.PermaLink %>#disqus_thread"><%=Resources.labels.comments %></a>
    <%}
       else
       { %>
    <a rel="bookmark" href="<%=Post.PermaLink %>" title="<%=Server.HtmlEncode(Post.Title) %>">Permalink</a> |
    <a rel="nofollow" href="<%=Post.RelativeLink %>#comment"><%=Resources.labels.comments %> (<%=Post.ApprovedComments.Count %>)</a>   
    <%} %>
    </div>
</div>
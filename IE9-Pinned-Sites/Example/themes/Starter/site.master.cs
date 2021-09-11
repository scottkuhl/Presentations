using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlogEngine.Core;

public partial class themes_Starter_site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Pinify();
    }

    // PIN: Add for pinned sites.
    private void Pinify()
    {
        // Load up the urls in javascript
        var pinifyJs = new StringBuilder();
        pinifyJs.AppendLine("<script type=\"text/javascript\">");

        // Static Links - set JavaScript variables
        pinifyJs.AppendLine("var contactLink = '" + Utils.RelativeWebRoot + "contact.aspx';");
        pinifyJs.AppendLine("var archiveLink = '" + Utils.RelativeWebRoot + "archive.aspx';");
        pinifyJs.AppendLine("var contactIco = '" + Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/Images/contact.ico';");
        pinifyJs.AppendLine("var archiveIco = '" + Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/Images/archive.ico';");        

        // Dynamic Links - Grab the 5 most recent posts
        var posts = Post.Posts.Take(5);
        pinifyJs.AppendLine("var stepsArray = []");
        foreach (var post in posts)
        {
            pinifyJs.AppendLine("var item = {");
            pinifyJs.AppendLine(string.Format("'name': '{0}','url': '{1}','icon':'{2}'", post.Title, post.RelativeLink,  Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/Images/post.ico"));
            pinifyJs.AppendLine("};");
            pinifyJs.AppendLine("stepsArray.push(item);");
        }

        // Close off script and add to literal.
        pinifyJs.AppendLine("</script>");
        jsLiteral.Text = pinifyJs.ToString();                
    }
}

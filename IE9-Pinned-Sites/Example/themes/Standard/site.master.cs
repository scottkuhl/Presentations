using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BlogEngine.Core;

public partial class StandardSite : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Security.IsAuthenticated)
		{
            aUser.InnerText = "Welcome " + Page.User.Identity.Name + "!";
			//aLogin.InnerText = Resources.labels.logoff;
			//aLogin.HRef = Utils.RelativeWebRoot + "Account/login.aspx?logoff";
		}
		else
		{
			//aLogin.HRef = Utils.RelativeWebRoot + "Account/login.aspx";
			//aLogin.InnerText = Resources.labels.login;
		}
        
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
        pinifyJs.AppendLine("var contactIco = '" + Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/img/contact.ico';");
        pinifyJs.AppendLine("var archiveIco = '" + Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/img/archive.ico';");        

        // Dynamic Links - Grab the 5 most recent posts
        var posts = Post.Posts.Take(5);
        pinifyJs.AppendLine("var stepsArray = []");
        foreach (var post in posts)
        {
            pinifyJs.AppendLine("var item = {");
            pinifyJs.AppendLine(string.Format("'name': '{0}','url': '{1}','icon':'{2}'", post.Title, post.RelativeLink,  Utils.RelativeWebRoot + "Themes/" + BlogSettings.Instance.Theme + "/img/post.ico"));
            pinifyJs.AppendLine("};");
            pinifyJs.AppendLine("stepsArray.push(item);");
        }

        // Close off script and add to literal.
        pinifyJs.AppendLine("</script>");
        jsLiteral.Text = pinifyJs.ToString();                
    }
}

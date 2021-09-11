using System.Web.UI;
using BlogEngine.Core;
using System.IO;
using System.Web;

namespace App_Code.Controls
{
    public class Login : Control
    {
        public override void RenderControl(HtmlTextWriter writer)
        {
            if (Security.IsAuthenticated)
            {
                writer.AddAttribute("href", Utils.RelativeWebRoot + "Account/login.aspx?logoff");
                writer.RenderBeginTag(HtmlTextWriterTag.A);

                TextReader tr = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/LoginControl.txt"));
                if (tr.ReadLine() == "Yes")
                {
                    writer.Write(Security.CurrentMembershipUser + ", ");
                }
                tr.Close();

                writer.Write(Resources.labels.logoff);
                writer.RenderEndTag();
            }
            else
            {
                writer.AddAttribute("href", Utils.RelativeWebRoot + "Account/login.aspx");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(Resources.labels.login);
                writer.RenderEndTag();
            }
        }
    }
}


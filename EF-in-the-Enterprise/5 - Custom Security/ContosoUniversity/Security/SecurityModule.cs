using System;
using System.Threading;
using System.Web;

namespace ContosoUniversity.Security
{
    public class SecurityModule : IHttpModule, IDisposable
    {
        public void Init(HttpApplication application)
        {
            application.PostAuthenticateRequest += new EventHandler(this.PostAuthenticateRequest);
        }

        public void Dispose() { }

        public void PostAuthenticateRequest(Object source, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userName = Thread.CurrentPrincipal.Identity.Name;
                CustomClaimsPrincipal cp = new CustomClaimsPrincipal(userName);
                Thread.CurrentPrincipal = cp;
                HttpContext.Current.User = cp;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace ContosoUniversity.UnitTests
{
    public static class Helper
    {
        public static void DataInitialize()
        {
            var context = new ContosoUniversity.DAL.SchoolContext();
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Enrollment; DBCC CHECKIDENT('dbo.Enrollment', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.OfficeAssignment");
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.CourseInstructor");
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Course");
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Department; DBCC CHECKIDENT('dbo.Department', RESEED, 0);");
            context.Database.ExecuteSqlCommand("DELETE FROM dbo.Person; DBCC CHECKIDENT('dbo.Person', RESEED, 0);");
            context.SaveChanges();

            var configuration = new ContosoUniversity.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        #region MVC Mock Helpers

        /*
         *  This section is taken from Scott Hanselman's blog post "ASP.NET MVC Session at Mix08, TDD and MvcMockHelpers.
         *  http://www.hanselman.com/blog/ASPNETMVCSessionAtMix08TDDAndMvcMockHelpers.aspx
         * 
         */

        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;
        }

        public static HttpContextBase FakeHttpContext(string url)
        {
            HttpContextBase context = FakeHttpContext();
            context.Request.SetupRequestUrl(url);
            return context;
        }

        public static void SetFakeControllerContext(this Controller controller)
        {
            var httpContext = FakeHttpContext();
            ControllerContext context = new ControllerContext(new RequestContext(httpContext, new RouteData()), controller);
            controller.ControllerContext = context;
        }

        static string GetUrlFileName(string url)
        {
            if (url.Contains("?"))
                return url.Substring(0, url.IndexOf("?"));
            else
                return url;
        }

        static NameValueCollection GetQueryStringParameters(string url)
        {
            if (url.Contains("?"))
            {
                NameValueCollection parameters = new NameValueCollection();

                string[] parts = url.Split("?".ToCharArray());
                string[] keys = parts[1].Split("&".ToCharArray());

                foreach (string key in keys)
                {
                    string[] part = key.Split("=".ToCharArray());
                    parameters.Add(part[0], part[1]);
                }

                return parameters;
            }
            else
            {
                return null;
            }
        }

        public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod)
        {
            Mock.Get(request)
                .Setup(req => req.HttpMethod)
                .Returns(httpMethod);
        }

        public static void SetupRequestUrl(this HttpRequestBase request, string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (!url.StartsWith("~/"))
                throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");

            var mock = Mock.Get(request);

            mock.Setup(req => req.QueryString)
                .Returns(GetQueryStringParameters(url));
            mock.Setup(req => req.AppRelativeCurrentExecutionFilePath)
                .Returns(GetUrlFileName(url));
            mock.Setup(req => req.PathInfo)
                .Returns(string.Empty);
        }

        #endregion
    }
}

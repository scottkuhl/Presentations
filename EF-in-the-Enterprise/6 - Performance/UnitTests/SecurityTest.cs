using ContosoUniversity.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;
using System.Threading;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class SecurityTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize("Abercrombie");
        }

        [TestMethod]
        public void CustomClaimsPrincipal()
        {
            var claim = new CustomClaimsPrincipal(Thread.CurrentPrincipal.Identity.Name);
            Assert.IsTrue(claim.HasClaim(ClaimTypes.Email, "abercrombie@contoso.edu"));
            Assert.IsTrue(claim.IsInRole("Instructor"));
        }
    }
}

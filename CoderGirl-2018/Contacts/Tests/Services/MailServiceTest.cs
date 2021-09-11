using Contacts.Models;
using Contacts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Services
{
    [TestClass]
    public class MailServiceTests
    {
        [TestMethod]
        public void SendMailTest()
        {
            // Arrange
            var service = new MailService();
            var visitor = new Visitor { FirstName = "Scott", LastName = "Kuhl", Email = "scott@kuhl.ws" };

            try
            {
                // Act
                service.SendMail(visitor);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
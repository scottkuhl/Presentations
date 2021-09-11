using Contacts.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Fakes;

namespace Tests.Controllers
{
    [TestClass]
    public class PersonControllerTests
    {
        [TestMethod]
        public void AddVisitorTest()
        {
            // Arrange
            var mailService = new FakeMailService();
            var personRepository = new FakePersonRepository();
            var personController = new PersonController(mailService, personRepository);
            var firstName = "Scott";
            var lastName = "Kuhl";
            var email = "scott@kuhl.ws";

            // Act
            var visitor = personController.AddVisitor(firstName, lastName, email);

            // Assert
            Assert.AreEqual(email, visitor.Email);
        }
    }
}
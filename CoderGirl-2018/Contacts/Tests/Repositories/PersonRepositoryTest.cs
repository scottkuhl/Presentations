using Contacts.Models;
using Contacts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests.Repositories
{
    [TestClass]
    public class PersonRepositoryTests
    {
        [TestMethod]
        public void AddVisitorTest()
        {
            // Arrange
            var repository = new PersonRepository();
            var visitor = new Visitor { FirstName = "Scott", LastName = "Kuhl", Email = "scott@kuhl.ws" };

            // Act
            repository.AddVisitor(visitor);

            // Assert
            var visitors = repository.GetMailable();
            Assert.IsTrue(visitors.Count(v => v.Email == "scott@kuhl.ws") > 0);
        }
    }
}
using Contacts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void FirstNameOnly()
        {
            // Arrange
            var person = new Person();
            person.FirstName = "Scott";

            // Act
            var name = person.Name;

            // Assert
            Assert.AreEqual("Scott", name);
        }

        [TestMethod]
        public void LastNameOnly()
        {
            // Arrange
            var person = new Person();
            person.LastName = "Kuhl";

            // Act
            var name = person.Name;

            // Assert
            Assert.AreEqual("Kuhl", name);
        }

        [TestMethod]
        public void Name()
        {
            // Arrange
            var person = new Person();
            person.FirstName = "Scott";
            person.LastName = "Kuhl";

            // Act
            var name = person.Name;

            // Assert
            Assert.AreEqual("Scott Kuhl", name);
        }
    }
}
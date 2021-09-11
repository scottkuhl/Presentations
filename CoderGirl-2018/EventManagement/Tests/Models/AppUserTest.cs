using EventManagement.Models;
using Xunit;

namespace Tests.Models
{
    public class AppUserTest
    {
        [Fact]
        public void FullName_ReturnsFirstAndLastName_Always()
        {
            // Arrange
            var appUser = new AppUser { FirstName = "First", LastName = "Last" };

            // Act
            var result = appUser.FullName;

            // Assert
            Assert.Equal("First Last", result);
        }
    }
}

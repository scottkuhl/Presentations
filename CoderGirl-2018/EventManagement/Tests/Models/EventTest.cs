using EventManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Tests.Models
{
    public class EventTest
    {
        [Fact]
        public void Title_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new Event();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The Title field is required.");
        }

        [Fact]
        public void Title_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new Event { Title = Helpers.FillString(201) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The field Title must be a string with a maximum length of 200.");
        }

        [Fact]
        public void Description_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new Event();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The Description field is required.");
        }

        [Fact]
        public void Description_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new Event { Description = Helpers.FillString(2001) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The field Description must be a string with a minimum length of 100 and a maximum length of 2000.");
        }

        [Fact]
        public void Description_ReturnsInvalid_WhenNotLongEnough()
        {
            // Arrange
            var evt = new Event { Description = Helpers.FillString(99) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The field Description must be a string with a minimum length of 100 and a maximum length of 2000.");
        }

        [Fact]
        public void Location_ReturnsInvalid_WhenNotSet()
        {
            // Arrange
            var evt = new Event();

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The Location field is required.");
        }

        [Fact]
        public void Location_ReturnsInvalid_WhenTooLong()
        {
            // Arrange
            var evt = new Event { Location = Helpers.FillString(201) };

            // Act
            var results = Helpers.ValidateModel(evt);

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The field Location must be a string with a maximum length of 200.");
        }

        [Fact]
        public void Validate_ReturnsInvalidMessage_WhenEndDateBeforeStartDate()
        {
            // Arrange
            var evt = new Event { Start = DateTime.Now, End = DateTime.Now.AddDays(-1) };

            // Act
            var results = evt.Validate(new ValidationContext(evt));

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The end date and time must be after the start date and time.");
        }

        [Fact]
        public void Validate_ReturnsInvalidMessage_WhenEndDateSameAsStartDate()
        {
            // Arrange
            var time = DateTime.Now;
            var @event = new Event { Start = time, End = time };

            // Act
            var results = @event.Validate(new ValidationContext(@event));

            // Assert
            Assert.Contains(results, x => x.ErrorMessage == "The end date and time must be after the start date and time.");
        }

        [Fact]
        public void Validate_IsValid_WhenEndDateAfterStartDate()
        {
            // Arrange
            var @event = new Event { Start = DateTime.Now, End = DateTime.Now.AddSeconds(1) };

            // Act
            var results = @event.Validate(new ValidationContext(@event));

            // Assert
            Assert.False(results.Any());
        }
    }
}

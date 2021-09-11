using Initials;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Initials_ReturnValue()
        {
            Assert.Equal("JFK", Program.Initials("John Fitzgerald kennedy"));
        }
    }
}

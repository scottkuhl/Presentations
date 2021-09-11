using ClassEnum;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Program_Donald()
        {
            Assert.Equal("Duck", Program.GetFirstName(StudentType.Donald));
        }

        [Fact]
        public void Program_Mickey()
        {
            Assert.Equal("Mouse", Program.GetFirstName(StudentType.Mickey));
        }
    }
}

using SumMethod;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Sum_ReturnValue()
        {
            Assert.Equal(55, Program.Sum(10));
        }
    }
}
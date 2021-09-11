using AliceInWonderland;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Match_True()
        {
            Assert.True(Program.Match("alice"));
        }

        [Fact]
        public void Match_False()
        {
            Assert.False(Program.Match("jean"));
        }
    }
}

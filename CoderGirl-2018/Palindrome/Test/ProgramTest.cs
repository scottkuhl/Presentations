using Palindrome;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Palindrome_True()
        {
            Assert.True(Program.IsPalindrome("Otto"));
        }

        [Fact]
        public void Palindrome_False()
        {
            Assert.False(Program.IsPalindrome("Joseph"));
        }
    }
}

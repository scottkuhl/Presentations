using StudentAverage;
using Xunit;

namespace Test
{
    public class StudentTest
    {
        [Fact]
        public void GetAverage_ReturnValue()
        {
            var student = new Student { Scores = new int[] { 1, 2, 3, 4, 5 } };
            Assert.Equal(3, student.GetAverage());
        }
    }
}
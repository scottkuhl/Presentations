using StudentAttendance;
using Xunit;

namespace Test
{
    public class StudentTest
    {
        [Fact]
        public void GetHasSixOrMore_False()
        {
            var student = new Student { Scores = new int[] { 1, 2, 3, 4, 5 } };
            Assert.False(student.HasSixOrMore());
        }

        [Fact]
        public void GetHasSixOrMore_True()
        {
            var student = new Student { Scores = new int[] { 1, 2, 3, 4, 5, 6 } };
            Assert.True(student.HasSixOrMore());
        }
    }
}
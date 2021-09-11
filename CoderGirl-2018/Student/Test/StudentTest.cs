using Xunit;

namespace Test
{
    public class StudentTest
    {
        [Fact]
        public void AddGrade_GPA()
        {
            var student = new Student.Student();
            student.AddGrade("A", 3);
            student.AddGrade("B", 3);

            Assert.Equal(3.5, student.GPA);
        }

        [Fact]
        public void GetGradeLevel_Freshman()
        {
            var student = new Student.Student();
            Assert.Equal("Freshman", student.GetGradeLevel());
        }

        [Fact]
        public void GetGradeLevel_Junior()
        {
            var student = new Student.Student();
            for (int i = 1; i <= 20; i++) student.AddGrade("A", 3);
            Assert.Equal("Junior", student.GetGradeLevel());
        }

        [Fact]
        public void GetGradeLevel_Senior()
        {
            var student = new Student.Student();
            for (int i = 1; i <= 30; i++) student.AddGrade("A", 3);
            Assert.Equal("Senior", student.GetGradeLevel());
        }

        [Fact]
        public void GetGradeLevel_Sophmore()
        {
            var student = new Student.Student();
            for (int i = 1; i <= 10; i++) student.AddGrade("A", 3);
            Assert.Equal("Sophmore", student.GetGradeLevel());
        }
    }
}
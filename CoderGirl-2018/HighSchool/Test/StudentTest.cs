using HighSchool;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class StudentTest
    {
        [Fact]
        public void StarStudents_Filter()
        {
            var students = new List<Student>
            {
                new Student { FirstName = "One", GPA = 2.9, Grade = 8 },
                new Student { FirstName = "Two", GPA = 2.9, Grade = 9 },
                new Student { FirstName = "Three", GPA = 3.0, Grade = 8 },
                new Student { FirstName = "Four", GPA = 3.0, Grade = 9 }
            };

            var results = Student.StarStudents(students);

            Assert.Single(results);
            Assert.Equal("Four", results[0].FirstName);
        }

        [Fact]
        public void StarStudents_Sort()
        {
            var students = new List<Student>
            {
                new Student { FirstName = "FirstOne", LastName = "LastOne", GPA = 3.0, Grade = 9 },
                new Student { FirstName = "FirstTwo", LastName = "LastTwo", GPA = 3.1, Grade = 9 },
                new Student { FirstName = "FirstThree", LastName = "LastThree", GPA = 3.2, Grade = 9 },
                new Student { FirstName = "FirstFourB", LastName = "LastFourB", GPA = 3.3, Grade = 9 },
                new Student { FirstName = "FirstFourC", LastName = "LastFourA", GPA = 3.3, Grade = 9 },
                new Student { FirstName = "FirstFourA", LastName = "LastFourA", GPA = 3.3, Grade = 9 },
                new Student { FirstName = "FirstFive", LastName = "LastFive", GPA = 3.0, Grade = 12 },
                new Student { FirstName = "FirstSix", LastName = "LastSix", GPA = 3.1, Grade = 12 },
                new Student { FirstName = "FirstSeven", LastName = "LastSeven", GPA = 3.2, Grade = 12 },
                new Student { FirstName = "FirstEight", LastName = "LastEight", GPA = 3.3, Grade = 12 }
            };

            var results = Student.StarStudents(students);

            Assert.Equal("FirstEight", results[0].FirstName);
            Assert.Equal("FirstSeven", results[1].FirstName);
            Assert.Equal("FirstSix", results[2].FirstName);
            Assert.Equal("FirstFive", results[3].FirstName);
            Assert.Equal("FirstFourA", results[4].FirstName);
            Assert.Equal("FirstFourC", results[5].FirstName);
            Assert.Equal("FirstFourB", results[6].FirstName);
            Assert.Equal("FirstThree", results[7].FirstName);
            Assert.Equal("FirstTwo", results[8].FirstName);
            Assert.Equal("FirstOne", results[9].FirstName);
        }

        [Fact]
        public void Grade_BelowMin()
        {
            Assert.NotEqual(-1, new Student { Grade = -1 }.Grade);
        }

        [Fact]
        public void Grade_AboveMax()
        {
            Assert.NotEqual(13, new Student { Grade = 13 }.Grade);
        }

        [Fact]
        public void Grade_Min()
        {
            Assert.Equal(1, new Student { Grade = 1 }.Grade);
        }

        [Fact]
        public void Grade_Max()
        {
            Assert.Equal(12, new Student { Grade = 12 }.Grade);
        }

        [Fact]
        public void GPA_BelowMin()
        {
            Assert.NotEqual(-0.01, new Student { GPA = -0.01 }.GPA);
        }

        [Fact]
        public void GPA_AboveMax()
        {
            Assert.NotEqual(4.01, new Student { GPA = 4.01 }.GPA);
        }

        [Fact]
        public void GPA_Min()
        {
            Assert.Equal(0, new Student { GPA = 0 }.GPA);
        }

        [Fact]
        public void GPA_Max()
        {
            Assert.Equal(4, new Student { GPA = 4 }.GPA);
        }
    }
}

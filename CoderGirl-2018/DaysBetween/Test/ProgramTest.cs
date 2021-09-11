using DaysBetween;
using System;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void DaysBetween_After()
        {
            Assert.Equal(2, Program.DaysBetween(DateTime.Parse("1/4/2018"), DateTime.Parse("1/6/2018")));
        }

        [Fact]
        public void DaysBetween_Before()
        {
            Assert.Equal(2, Program.DaysBetween(DateTime.Parse("1/6/2018"), DateTime.Parse("1/4/2018")));
        }
    }
}

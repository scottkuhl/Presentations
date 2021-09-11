using Calculator2;
using System;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Add_ReturnValue()
        {
            Assert.Equal(20.5, Program.Add(10.0, 10.5));
        }

        [Fact]
        public void Subtract_ReturnValue()
        {
            Assert.Equal(10.5, Program.Subtract(20.5, 10.0));
        }

        [Fact]
        public void Multiply_ReturnValue()
        {
            Assert.Equal(5.0, Program.Multiply(2.0, 2.5));
        }

        [Fact]
        public void Divide_ReturnValue()
        {
            Assert.Equal(10.25, Program.Divide(20.5, 2.0));
        }
    }
}

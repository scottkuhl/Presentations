using Turtles;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_OutputArea()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(""))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Equal("I like turtles.", result[1]);
                Assert.True(result.Length >= 1000);
            }
        }
    }
}

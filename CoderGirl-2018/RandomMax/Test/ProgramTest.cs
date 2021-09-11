using RandomMax;
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

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.True(int.Parse(result) >= 0 && int.Parse(result) <= 1000);
            }
        }
    }
}
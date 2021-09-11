using BottlesOfBeer;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_OutputResults()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("10" + Environment.NewLine + "2"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Contains("98 bottles of beer on the wall.", result[1]);
                Assert.True(result.Length >= 99);
            }
        }
    }
}

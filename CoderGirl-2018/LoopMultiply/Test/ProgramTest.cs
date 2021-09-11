using LoopMultiply;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_Total()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("2"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString();

                Assert.Contains("418", result);
            }
        }
    }
}

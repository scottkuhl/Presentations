using Mileage;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_OutputMPG()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("100" + Environment.NewLine + "50"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("2", result);
            }
        }
    }
}

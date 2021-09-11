using IntegerLoop;
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

                using (StringReader sr = new StringReader(""))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                for (int i = 0; i <= 25; i++)
                {
                    Assert.Equal(i * 2, int.Parse(result[i]));
                }
            }
        }
    }
}
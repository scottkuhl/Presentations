using SingleLineArray;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_OutputValues()
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

                Assert.Equal(1, int.Parse(result[0]));
                Assert.Equal(1, int.Parse(result[1]));
                Assert.Equal(2, int.Parse(result[2]));
                Assert.Equal(3, int.Parse(result[3]));
                Assert.Equal(5, int.Parse(result[4]));
                Assert.Equal(8, int.Parse(result[5]));
            }
        }
    }
}

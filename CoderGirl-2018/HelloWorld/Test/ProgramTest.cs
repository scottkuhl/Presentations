using HelloWorld;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_OutputHelloWorld()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(Environment.NewLine))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }
                    
                Assert.Equal($"Hello CoderGirl!{Environment.NewLine}", sw.ToString());
            }
        }
    }
}

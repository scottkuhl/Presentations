using Calculator;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_Add()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("2" + Environment.NewLine + "4" + Environment.NewLine + "add"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("6", result);
            }
        }

        [Fact]
        public void Main_Subtract()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("6" + Environment.NewLine + "2" + Environment.NewLine + "subtract"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("4", result);
            }
        }

        [Fact]
        public void Main_Multiply()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("2" + Environment.NewLine + "4" + Environment.NewLine + "multiply"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("8", result);
            }
        }

        [Fact]
        public void Main_Divide()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("10" + Environment.NewLine + "2" + Environment.NewLine + "divide"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("5", result);
            }
        }
    }
}

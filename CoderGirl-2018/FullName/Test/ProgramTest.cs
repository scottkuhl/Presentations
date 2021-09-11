using FullName;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_FirstName()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("Scott" + Environment.NewLine + "Kuhl"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.Contains("first", result);
            }
        }

        [Fact]
        public void Main_LastName()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("Scott" + Environment.NewLine + "Kuhl"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.Contains("last", result);
            }
        }

        [Fact]
        public void Main_FullName()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("Scott" + Environment.NewLine + "Kuhl"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.Contains("Scott Kuhl", result);
            }
        }

        [Fact]
        public void FullName_ReturnValue()
        {
            Assert.Equal("Scott Kuhl", Program.FullName("Scott", "Kuhl"));
        }
    }
}
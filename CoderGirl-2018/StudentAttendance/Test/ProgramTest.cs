using StudentAttendance;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_Count()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(Environment.NewLine))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Equal(3, result.Length);
            }
        }

        [Fact]
        public void Main_EmptyLine()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(Environment.NewLine))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Equal("", result[2]);
            }
        }

        [Fact]
        public void Main_Grace()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(Environment.NewLine))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Equal("grace", result[1]);
            }
        }

        [Fact]
        public void Main_Sue()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(Environment.NewLine))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Split(Environment.NewLine);

                Assert.Equal("sue", result[0]);
            }
        }
    }
}
using StudentAverage;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_Bill()
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

                Assert.Equal("bill Average: 20", result[1]);
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

                Assert.Equal("grace Average: 24", result[3]);
            }
        }

        [Fact]
        public void Main_Joe()
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

                Assert.Equal("joe Average: 23", result[0]);
            }
        }

        [Fact]
        public void Main_John()
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

                Assert.Equal("john Average: 35", result[4]);
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

                Assert.Equal("sue Average: 16", result[2]);
            }
        }
    }
}

using Month;
using System;
using System.IO;
using Xunit;

namespace Test
{
    public class ProgramTest
    {
        [Fact]
        public void Main_January()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("1"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("January", result);
            }
        }

        [Fact]
        public void Main_February()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("2"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("February", result);
            }
        }

        [Fact]
        public void Main_March()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("3"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("March", result);
            }
        }

        [Fact]
        public void Main_April()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("4"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("April", result);
            }
        }

        [Fact]
        public void Main_May()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("5"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("May", result);
            }
        }

        [Fact]
        public void Main_June()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("6"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("June", result);
            }
        }

        [Fact]
        public void Main_July()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("7"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("July", result);
            }
        }

        [Fact]
        public void Main_August()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("8"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("August", result);
            }
        }

        [Fact]
        public void Main_September()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("9"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("September", result);
            }
        }

        [Fact]
        public void Main_October()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("10"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("October", result);
            }
        }

        [Fact]
        public void Main_November()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("11"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("November", result);
            }
        }

        [Fact]
        public void Main_December()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader("12"))
                {
                    Console.SetIn(sr);

                    Program.Main();
                }

                var result = sw.ToString().Replace(Environment.NewLine, "");

                Assert.EndsWith("December", result);
            }
        }
    }
}

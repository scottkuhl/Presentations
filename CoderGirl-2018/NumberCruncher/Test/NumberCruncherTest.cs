using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class NumberCruncherTest
    {
        [Fact]
        public void SumOfEvenNumbers_Result()
        {
            Assert.Equal(30, NumberUtility.NumberCruncher.SumOfEvenNumbers(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
        }
    }
}

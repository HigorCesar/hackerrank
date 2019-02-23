using System;
using Xunit;

namespace Kangaroo.Csharp
{
    public class KangarooTests
    {
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 == v2)
                return "NO";

            var jumps = (decimal)(x2 - x1) / (v1 - v2);
            if (jumps >= 0 && jumps % 1 == 0)
                return "YES";
            else
                return "NO";
        }

        [Theory]
        [InlineData(0,3,4,2,"YES")]
        [InlineData(0,2,5,3,"NO")]
        public void SampleInput(int x1, int v1, int x2, int v2, string expectation)
        {
            Assert.Equal(expectation, kangaroo(x1, v1, x2, v2));
        }
    }
}
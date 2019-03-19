using Xunit;

namespace DivisibleSumPair
{
    public class DivisibleSumPairsTests
    {
        static int DivisibleSumPairs(int n, int k, int[] ar)
        {
            var divisible = 0;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                    if ((ar[i] + ar[j]) % k == 0)
                        divisible++;
            }

            return divisible;
        }

        [InlineData(6,3,new []{1,3,2,6,1,2})]
        [Theory]
        public void HackerRankTest(int n, int k, int[] values)
        {
            Assert.Equal(5,DivisibleSumPairs(n,k,values));
        }
    }
}
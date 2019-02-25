using Xunit;

namespace BetweenSets.Csharp
{
    public class BetweenSetsTests
    {
        private static int Gcd(int[] values)
        {
            int result = values[0];
            for (var i = 1; i < values.Length; i++)
                result = Gcd(values[i], result);

            return result;
        }

        private static int Lcm(int[] values)
        {
            int result = values[0];
            for (var i = 1; i < values.Length; i++)
                result = Lcm(values[i], result);

            return result;
        }

        private static int Lcm(int a, int b)
        {
            return a * b / Gcd(a, b);
        }

        static int Gcd(int a, int b)
        {
            if (a == 0)
                return b;

            return Gcd(b % a, a);
        }

        private static int FindMax(int[] values)
        {
            var max = 0;
            foreach (var value in values)
                if (value > max)
                    max = value;
            return max;
        }

        static int getTotalX(int[] a, int[] b)
        {
            var inBetween = 0;
            var maxA = FindMax(a);
            var lcm = Lcm(a);
            var gcd = Gcd(b);
            for (var n = lcm; n <= gcd; n += lcm)
            {
                if (n >= maxA && gcd % n == 0)
                    inBetween++;
            }

            return inBetween;
        }

        [Theory]
        [InlineData(new[]
        {
            2, 4
        }, new[]
        {
            16, 32, 96
        }, 3)]
        public void GivengetTotalX_WhenSample_ThenReturnsAnswer(int[] a, int[] b, int expected)
        {
            Assert.Equal(expected, getTotalX(a, b));
        }

        [Fact]
        public void GivenGcd_WhenNumbersAre24And36_Then_GCDIs12()
        {
            Assert.Equal(12, Gcd(24, 36));
        }

        [Theory]
        [InlineData(new[]
        {
            16, 32, 96
        }, 16)]
        public void GivenGcd_WhenList_Then_FindGCD(int[] values, int expected)
        {
            Assert.Equal(expected, Gcd(values));
        }

        [Fact]
        public void GivenLcm_WhenNumberAre2And3_ThenLcmIs6()
        {
            Assert.Equal(6, Lcm(2, 3));
        }

        [Theory]
        [InlineData(new[]
        {
            2, 3, 23
        }, 138)]
        public void GivenLcm_WhenList_Then_FindLcm(int[] values, int expected)
        {
            Assert.Equal(expected, Lcm(values));
        }
    }
}
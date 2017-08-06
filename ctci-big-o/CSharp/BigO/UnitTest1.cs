using System;
using Xunit;

namespace BigO
{
    public class Primality
    {
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number < 3) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
    public class UnitTest1
    {
        [Theory()]
        [InlineData(7)]
        [InlineData(13)]
        [InlineData(19)]
        [InlineData(23)]
        public void IsPrime(int number)
        {
            Assert.True(Primality.IsPrime(number));
        }
        [Theory()]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(21)]
        public void NotPrime(int number)
        {
            Assert.False(Primality.IsPrime(number));
        }
    }
}

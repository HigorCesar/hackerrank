using System;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace ExtraBigIntegerFactorials
{
    public class BigIntegerCalculador
    {
        private Dictionary<int, BigInteger> factorials;
        public BigIntegerCalculador()
        {
            factorials = new Dictionary<int, BigInteger>();
            for (int i = 1; i < 10; i++)
                factorials.Add(i, Factorial(i));
        }
        public BigInteger Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }
        public BigInteger FactorialCached(int n)
        {
            if (!factorials.ContainsKey(n))
                factorials[n] = Factorial(n);
            return factorials[n];
        }
    }
    public class ExtraLongFactorialsTest
    {
        [Theory]
        [InlineData(5, "120")]
        [InlineData(25, "15511210043330985984000000")]
        public void FactorialTests(int input, string expected)
        {
            var calculator = new BigIntegerCalculador();
            Assert.Equal(BigInteger.Parse(expected), calculator.FactorialCached(input));
        }
    }
}

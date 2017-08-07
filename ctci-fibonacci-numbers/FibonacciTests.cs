using System;
using Xunit;

namespace CtciFibonacciNumbers
{
    public class FibonacciTests
    {
        public int Fibonacci(int n)
        {
            if (n == 1)
                return 1;
            if (n == 0)
                return 0;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(4, 3)]
        public void FibonacciTest(int n, int sum)
        {
            Assert.Equal(sum, Fibonacci(n));
        }
    }
}

using Xunit;

namespace Ctci.RecursiveStaircase
{
    public class Tests
    {
        [Fact]
        public void CountWays_1_equals_1()
        {
            Assert.Equal(1, RecursiveStaircase.Fib(1));
        }
        [Fact]
        public void CountWays_3_equals_4()
        {
            Assert.Equal(4, RecursiveStaircase.Fib(3));
        }
        [Fact]
        public void CountWays_7_equals_44()
        {
            Assert.Equal(44, RecursiveStaircase.Fib(7));
        }
    }
}

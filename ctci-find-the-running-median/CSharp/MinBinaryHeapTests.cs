using System;
using Xunit;

namespace ctci_find_the_running_median
{
    public class MinBinaryHeapTests
    {
        [Fact]
        public void Insert_20_and_4_peek_must_return_4()
        {
            var sut = new MinBinaryHeap(10);
            sut.Insert(20);
            sut.Insert(4);
            Assert.Equal(4, sut.Peek());
        }

        [Theory]
        [InlineData(new[] { 4, 12, 30, 22, 50 }, new[] { 4, 12, 22, 30, 50 })]
        public void InsertAndExtractSomeNumbers(int[] input, int[] output)
        {
            var sut = new MinBinaryHeap(5);
            foreach (var item in input)
                sut.Insert(item);

            foreach (var item in output)
            {
                Assert.Equal(item, sut.ExtractMin());
            }
        }

        [Fact]
        public void Insert_when_running_out_space_throws_exception()
        {
            var sut = new MinBinaryHeap(0);
            Assert.Throws<InvalidOperationException>(() => sut.Insert(1));
        }

        [Fact]
        public void Peek_when_is_empty_returns_throws_exception()
        {
            var sut = new MinBinaryHeap(0);
            Assert.Throws<InvalidOperationException>(() => sut.Peek());
        }

    }
}
using System;
using Xunit;

namespace ctci_find_the_running_median
{
    public class MaxBinaryHeapTests
    {
        [Fact]
        public void Insert_4_and_20_peek_must_return_20()
        {
            var sut = new MaxBinaryHeap(10);
            sut.Insert(4);
            sut.Insert(20);
            Assert.Equal(20, sut.Peek());
        }
        
        [Theory]
        [InlineData(new[] { 4, 12, 30, 22, 50 }, new[] { 50, 30, 22, 12, 4 })]
        public void InsertAndExtractSomeNumbers(int[] input, int[] output)
        {
            var sut = new MaxBinaryHeap(5);
            foreach (var item in input)
                sut.Insert(item);

            foreach (var item in output)
               Assert.Equal(item, sut.ExtractMax());
        }

        [Fact]
        public void Insert_when_running_out_space_throws_exception(){
            var sut = new MaxBinaryHeap(0);
            Assert.Throws<InvalidOperationException>(() => sut.Insert(1));
        }
        
         [Fact]
        public void ExtractMax_when_is_empty_returns_throws_exception(){
            var sut = new MaxBinaryHeap(0);
             Assert.Throws<InvalidOperationException>(() => sut.Peek());
        }
    }
}
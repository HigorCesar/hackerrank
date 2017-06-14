using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ctci_find_the_running_median
{
    public class MedianHeapTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new[] { "1.0", "1.5", "2.0", "2.5", "3.0", "3.5", "4.0", "4.5", "5.0", "5.5" })]
        public void InsertNumbersAndCalculateAverage(int[] values, string[] results)
        {
            var medianHeap = new MedianHeap(values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                medianHeap.Insert(values[i]);
                var mediam = medianHeap.Median();
                Assert.Equal(results[i], medianHeap.Median().ToString("0.0"));
            }
        }
    }
}

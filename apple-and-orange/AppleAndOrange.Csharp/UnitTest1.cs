using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace AppleAndOrange.Csharp
{
    public class AppleAndOrangeTests
    {
        static int[] Solve(int startHouseLocation, int endHouseLocation, int appleTreeLocation, int orangeTreeLocation, int[] apples, int[] oranges)
        {
            var applesInRange = (from apple in apples
                                 let fruitLocation = apple + appleTreeLocation
                                 where fruitLocation >= startHouseLocation && fruitLocation <= endHouseLocation
                                 select apple).Count();

            var orangesInRange = (from orange in oranges
                                  let fruitLocation = orange + orangeTreeLocation
                                  where fruitLocation >= startHouseLocation && fruitLocation <= endHouseLocation
                                  select fruitLocation).Count();

            return new[]
            {
                applesInRange, orangesInRange
            };
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            foreach (var fruitCount in Solve(s, t, a, b, apples, oranges))
                Console.WriteLine(fruitCount);
        }

        [Fact]
        public void HackerRankSample()
        {
            var result = Solve(7, 11, 5, 15, new[]
            {
                -2, 2, 1
            }, new[]
            {
                5, -6
            });

            Assert.Equal(new int[]
            {
                1, 1
            }, result);
        }
    }
}
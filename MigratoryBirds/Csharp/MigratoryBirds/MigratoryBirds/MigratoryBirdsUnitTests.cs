using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MigratoryBirds
{
    public class MigratoryBirdsUnitTests
    {
        static int migratoryBirds(List<int> arr)
        {
            var birdsAppearances = new Dictionary<int, int>()
            {
                {
                    1, 0
                },
                {
                    2, 0
                },
                {
                    3, 0
                },
                {
                    4, 0
                },
                {
                    5, 0
                }
            };
            var topBirdAppearance = 1;
            foreach (var bird in arr)
            {
                birdsAppearances[bird]++;
                if ((birdsAppearances[bird] > birdsAppearances[topBirdAppearance]) ||
                    (birdsAppearances[bird] == birdsAppearances[topBirdAppearance] && bird < topBirdAppearance))
                {
                    topBirdAppearance = bird;
                }
            }

            return topBirdAppearance;
        }

        [Theory]
        [InlineData(new[]{1,2,3,4,5,4,3,2,1,3,4})]
        public void MigratoryBirdsTest(int[] arr)
        {
            Assert.Equal(3, migratoryBirds(arr.ToList()));
        }
    }
}
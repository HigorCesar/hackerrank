using System;
using Xunit;

namespace BreakingTheRecords.Csharp
{
    public class UnitTest1
    {
        static int[] breakingRecords(int[] scores)
        {
            int maxScore, minScore, mostPointsRecords, leastPointsRecords;
            maxScore = minScore = scores[0];
            mostPointsRecords = leastPointsRecords = 0;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    mostPointsRecords++;
                }
                else if (scores[i] < minScore)
                {
                    minScore = scores[i];
                    leastPointsRecords++;
                }
            }

            return new[]
            {
                mostPointsRecords, leastPointsRecords
            };
        }

        [Theory]
        [InlineData(new[]
        {
            10, 5, 20, 20, 4, 5, 2, 25, 1
        }, new[]
        {
            2, 4
        })]
        [InlineData(new[]
        {
            3, 4, 21, 36, 10, 28, 35, 5, 24, 42
        }, new[]
        {
            4, 0
        })]
        public void TestWithSamples(int[] scores, int[] expected)
        {
            Assert.Equal(expected, breakingRecords(scores));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MagicSquare.CSharp
{

    public class UnitTest1
    {
        static int FormingMagicSquare(int[][] s)
        {
            var values = new Dictionary<int, List<(int, int)>>();
            var dupIndex = new List<(int, int)>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (values.ContainsKey(s[i][j]))
                        values[s[i][j]].Add((i, j));
                    else
                        values.Add(s[i][j], new List<(int, int)> { (i, j) });
                }
            }
            return 1;
        }

        [Fact]
        public void ChangeAtCostOne()
        {
            var target = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 5}
            };
            Assert.Equal(1, FormingMagicSquare(target));


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Bomberman.CSharp
{
    public class BombermanTests
    {

        private static IEnumerable<int> GetClosePositionsToExplode(int position, int rows, int columns)
        {
            var size = columns * rows;
            var neighboursToExplode = new List<int>();
            neighboursToExplode.Add(position);

            if (position % columns != 0)
                neighboursToExplode.Add(position - 1);

            var rightItem = position + 1;
            if (rightItem % columns != 0)
                neighboursToExplode.Add(rightItem);

            var aboveItem = position - columns;
            if (aboveItem >= 0)
                neighboursToExplode.Add(aboveItem);

            var belowItem = position + columns;
            if (belowItem < size)
                neighboursToExplode.Add(belowItem);

            return neighboursToExplode;
        }
        static string[] BomberMan(int n, string[] input)
        {
            if (n == 1)
                return input;

            var rows = input.Length;
            var columns = input[0].ToCharArray().Length;
            var size = rows * columns;


            if (n % 2 == 0)
                return Enumerable.Range(0, rows).Select(i => String.Concat(Enumerable.Range(0, columns).Select(_ => 'O'))).ToArray();

            var grid = input.SelectMany(g => g.ToCharArray()).ToArray();
            var placesToExplodeNextTime = new List<int>();
            for (int i = 0; i < grid.Length; i++)
                if (grid[i] == 'O')
                    placesToExplodeNextTime.Add(i);

            var placesToExplodeNextTimePattern3 = new List<int>();
            var placesToExplodeNextTimePattern5 = new List<int>();
            bool follow3Pattern = false;
            for (int i = 3; i <= n; i += 2)
            {
                if (i == 3)
                {
                    var allPlacesToExplodeNowPattern3 = placesToExplodeNextTime.SelectMany(x => GetClosePositionsToExplode(x, rows, columns));
                    placesToExplodeNextTime = Enumerable.Range(0, size).Except(allPlacesToExplodeNowPattern3).ToList();
                    placesToExplodeNextTimePattern3 = placesToExplodeNextTime;
                    follow3Pattern = true;
                }
                else if (i == 5)
                {
                    var allPlacesToExplodeNowPattern5 = placesToExplodeNextTime.SelectMany(x => GetClosePositionsToExplode(x, rows, columns));
                    placesToExplodeNextTime = Enumerable.Range(0, size).Except(allPlacesToExplodeNowPattern5).ToList();
                    placesToExplodeNextTimePattern5 = placesToExplodeNextTime;
                    follow3Pattern = false;
                }
                else if (i % 2 == 1)
                {
                    follow3Pattern = !follow3Pattern;
                }
            }

            var resultBomberman = Enumerable.Range(0, size).Select(_ => '.').ToArray();

            (follow3Pattern ? placesToExplodeNextTimePattern3 : placesToExplodeNextTimePattern5).ForEach(v => resultBomberman[v] = 'O');

            var output = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                output[i] = String.Concat(resultBomberman.Skip(columns * i).Take(columns)); ;
            }

            return output;
        }

        [Fact]
        public void Test1()
        {
            var expected = new[] { "OOO.OO", "OO...OO", "OOO...O,", "..OO.OO", "...OOOO", "...OOOO" };
            var actual = BomberMan(3, new[] { ".......", "...O...", "....O..", ".......", "OO.....", "OO....." });
            Assert.True(expected.SequenceEqual(actual));
        }
    }
}

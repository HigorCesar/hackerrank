using System;
using System.Linq;
using Xunit;

namespace mini_max_sum
{
    class MinMaxSolver
    {
        public static void Solve(decimal[] values)
        {
            System.Console.WriteLine($"{MaxSum(values)} {MinSum(values)}");
        }
        public static decimal MinSum(decimal[] values)
        {
            Sort(values);
            return values.Skip(1).Sum();
        }
        public static decimal MaxSum(decimal[] values)
        {
            Sort(values);
            return values.Take(4).Sum();
        }
        public static void Sort(decimal[] values)
        {
            Sort(values, values.Length);
        }
        public static void Sort(decimal[] values, int length)
        {
            var pivot = values[length - 1];
            var lowerThanPivot = new decimal[length];
            var biggerThanPivot = new decimal[length];
            int lowerThanPivotCount = 0;
            int biggerThanPivotCount = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (values[i] < pivot)
                    lowerThanPivot[lowerThanPivotCount++] = values[i];
                else
                    biggerThanPivot[biggerThanPivotCount++] = values[i];
            }
            if (lowerThanPivotCount > 1)
                Sort(lowerThanPivot, lowerThanPivotCount);
            if (biggerThanPivotCount > 1)
                Sort(biggerThanPivot, biggerThanPivotCount);

            int sortedIndex = 0;
            for (int i = 0; i < lowerThanPivotCount; i++)
                values[sortedIndex++] = lowerThanPivot[i];

            values[sortedIndex++] = pivot;

            for (int i = 0; i < biggerThanPivotCount; i++)
                values[sortedIndex++] = biggerThanPivot[i];

        }
    }
    public class MinMaxSolverTests
    {
        [Fact]
        public void Sort3Items()
        {
            var actual = new decimal[] { 3, 1, 2 };
            MinMaxSolver.Sort(actual);
            Assert.Equal(new decimal[] { 1, 2, 3 }, actual);

        }
        [Fact]
        public void Sort10Items()
        {
            var actual = new decimal[] { 3, 1, 2, 0, 99, 2, 54, 67, 888, 4 };
            MinMaxSolver.Sort(actual);
            Assert.Equal(new decimal[] { 0, 1, 2, 2, 3, 4, 54, 67, 99, 888 }, actual);
        }

        [Fact]
        public void MaxSum()
        {
            var actual = new decimal[] { 140638725, 436257910, 953274816, 734065819, 362748590 };
            Assert.Equal((decimal)1673711044, MinMaxSolver.MaxSum(actual));
            Assert.Equal((decimal)2486347135, MinMaxSolver.MinSum(actual));
        }
    }
}

using System;
using System.Linq;
using Xunit;

namespace mini_max_sum
{
    class MinMaxSolver
    {
        public static Int64 MinSum(int[] values){
            Sort(values);
            return values.Skip(1).Sum();
        }
         public static Int64 MaxSum(int[] values){
            Sort(values);
            return values.Take(4).Sum();
        }
        public static void Sort(int[] values)
        {
            Sort(values, values.Length);
        }
        public static void Sort(int[] values, int length)
        {
            var pivot = values[length - 1];
            var lowerThanPivot = new int[length];
            var biggerThanPivot = new int[length];
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
    public class UnitTest1
    {
        [Fact]
        public void Sort3Items()
        {
            var actual = new[] { 3, 1, 2 };
            MinMaxSolver.Sort(actual);
            Assert.Equal(new[] { 1, 2, 3 }, actual);

        }
        [Fact]
        public void Sort10Items()
        {
            var actual = new[] { 3, 1, 2, 0, 99, 2, 54, 67, 888, 4 };
            MinMaxSolver.Sort(actual);
            Assert.Equal(new[] { 0,1, 2, 2,3,4,54,67,99,888 }, actual);

        }
    }
}

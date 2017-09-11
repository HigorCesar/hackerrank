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
            QuickSort(values, 0, values.Length - 1);
            return values.Skip(1).Sum();
        }
        public static decimal MaxSum(decimal[] values)
        {
            QuickSort(values, 0, values.Length - 1);
            return values.Take(4).Sum();
        }
        public static void QuickSort(decimal[] values, int low, int high)
        {
            if (low < high)
            {
                var pi = Partition(values, low, high);
                QuickSort(values, low, pi - 1);
                QuickSort(values, pi + 1, high);
            }
        }
        private static void Swap(decimal[] values, int x, int y)
        {
            var tmp = values[x];
            values[x] = values[y];
            values[y] = tmp;
        }
        private static int Partition(decimal[] values, int low, int high)
        {
            var pivot = values[high]; //rightmost element
            int i = (low - 1); //index of smaller element
            for (int j = low; j <= high; j++)
            {
                if (values[j] < pivot)
                {
                    Swap(values, j, ++i);
                }
            }
            Swap(values, high, ++i);
            return i;

        }
    }
    public class MinMaxSolverTests
    {
        [Fact]
        public void MaxSum()
        {
            var actual = new decimal[] { 140638725, 436257910, 953274816, 734065819, 362748590 };
            Assert.Equal((decimal)1673711044, MinMaxSolver.MaxSum(actual));
            Assert.Equal((decimal)2486347135, MinMaxSolver.MinSum(actual));
        }

        [Fact]
        public void QuickSort3Items()
        {
            var actual = new decimal[] { 3, 1, 2 };
            MinMaxSolver.QuickSort(actual, 0, actual.Length - 1);
            Assert.Equal(new decimal[] { 1, 2, 3 }, actual);

        }

    }
}

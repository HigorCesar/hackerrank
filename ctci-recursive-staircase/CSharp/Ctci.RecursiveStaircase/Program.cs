using System;
using System.Collections.Generic;

namespace Ctci.RecursiveStaircase
{
    public class RecursiveStaircase
    {
        static Dictionary<int, int> cache = new Dictionary<int, int>();
        public static int Fib(int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1)
                return 1;

            if (!cache.ContainsKey(n))
            {
                int count = Fib(n - 1) + Fib(n - 2) + Fib(n - 3);
                cache.Add(n, count);
                return count;
            }
            return cache[n];

        }
        public int CountWays(int stairs)
        {
            return Fib(stairs);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
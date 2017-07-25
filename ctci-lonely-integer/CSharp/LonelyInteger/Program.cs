using System;
using System.Collections.Generic;
using System.Linq;

namespace LonelyInteger
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            var uniqueNumbers = new List<int>();
            var lonelyInteger = 0;
            foreach (var number in a_temp.Select(x => Convert.ToInt32(x)))
            {
                if (uniqueNumbers.Contains(number))
                    lonelyInteger -= number;
                else
                {
                    lonelyInteger += number;
                    uniqueNumbers.Add(number);
                }
            }
            Console.WriteLine(lonelyInteger);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ctci_ice_cream_parlor
{
    public class IceCreamFinder
    {
        private static Tuple<int, int> BinarySearch(Tuple<int, int>[] values, int value, int left, int right)
        {
            if (left > right) return null;
            var middle = left + (right - left) / 2;
            if (values[middle].Item1 == value)
                return values[middle];
            else if (value < values[middle].Item1)
                return BinarySearch(values, value, left, middle - 1);
            else
                return BinarySearch(values, value, middle + 1, right);

        }
        public static string Execute(int[] iceCreamRawValues, int money)
        {
            var iceCreamValues = new Tuple<int, int>[iceCreamRawValues.Length];
            for (int i = 0; i < iceCreamRawValues.Length; i++)
                iceCreamValues[i] = Tuple.Create(iceCreamRawValues[i], i + 1);
            iceCreamValues = iceCreamValues.OrderBy(x => x.Item1).ToArray();

            for (int i = 0; i < iceCreamValues.Length; i++)
            {
                var residualMoney = money - iceCreamValues[i].Item1;
                var found = BinarySearch(iceCreamValues, residualMoney, i + 1, iceCreamValues.Length - 1);
                if (found != null)
                    return iceCreamValues[i].Item2 < found.Item2 ? $"{iceCreamValues[i].Item2} {found.Item2}" : $"{found.Item2} {iceCreamValues[i].Item2}";
            }
            throw new InvalidOperationException("It is guaranteed that there will always be a unique solution");

        }
    }
}

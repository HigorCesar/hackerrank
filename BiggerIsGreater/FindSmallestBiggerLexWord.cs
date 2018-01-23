using System;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework;
using Xunit;

namespace BiggerIsGreater
{
    public class FindSmallestBiggerLexWord
    {
        public static string Execute(string value)
        {
            int? pivotIndex = null;
            for (var i = 0; i < value.Length - 1; i++)
                if (value[i] < value[i + 1])
                    pivotIndex = i;

            if (!pivotIndex.HasValue)
                return "no answer";

            int rightmost = 0;
            for (var i = pivotIndex.Value + 1; i < value.Length; i++)
                if (value[pivotIndex.Value] < value[i])
                    rightmost = i;

            var result = value.ToCharArray();
            Swap(result, pivotIndex.Value, rightmost);
            Array.Sort(result, pivotIndex.Value + 1, result.Length - (pivotIndex.Value + 1));

            return new String(result);
        }

        private static void Swap(char[] values, int i, int j)
        {
            var temp = values[i];
            values[i] = values[j];
            values[j] = temp;
        }
    }
}

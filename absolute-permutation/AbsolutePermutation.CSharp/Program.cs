using System;
using System.IO;
using System.Linq;

namespace AbsolutePermutation.CSharp
{
    class Program
    {
        static int[] AbsolutePermutation(int n, int k)
        {
            var permutation = new int[n];
            for (int i = 1; i <= n; i++)
            {
                var fstPosI = k + i;
                var sndPosI = Math.Abs(k - i);
                if (Math.Abs(sndPosI - i) == k && sndPosI > 0 && permutation[sndPosI - 1] == default(int))
                    permutation[sndPosI - 1] = i;
                else if (fstPosI <= n)
                    permutation[fstPosI - 1] = i;
                else break;
            }

            return permutation.Contains(default(int)) ? new[] { -1 } : permutation;
        }

        static void Main(string[] args)
        {
            var textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nk = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nk[0]);

                int k = Convert.ToInt32(nk[1]);

                int[] result = AbsolutePermutation(n, k);

                textWriter.WriteLine(string.Join(" ", result));
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

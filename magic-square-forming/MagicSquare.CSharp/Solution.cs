using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSquare.CSharp
{
    public class Solution
    {
        public static int[][] ReflectAlongMainDiagonal(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[magicSquare.Length],
                new int[magicSquare.Length],
                new int[magicSquare.Length],
            };
            for (int i = 0; i < magicSquare.Length; i++)
            for (int j = 0; j < magicSquare.Length; j++)
                newMagicSquare[i][j] = magicSquare[i][j];

            for (int i = 0; i < magicSquare.Length; i++)
            for (int j = 0; j < magicSquare.Length; j++)
            {
                if (j < i)
                {
                    var temp = newMagicSquare[j][i];
                    newMagicSquare[j][i] = newMagicSquare[i][j];
                    newMagicSquare[i][j] = temp;
                }
            }

            return newMagicSquare;
        }

        public static int[][] ReflectAlongOffDiagonal(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[magicSquare.Length],
                new int[magicSquare.Length],
                new int[magicSquare.Length],
            };

            for (int i = 0; i < magicSquare.Length; i++)
            for (int j = 0; j < magicSquare.Length; j++)
                newMagicSquare[i][j] = magicSquare[i][j];

            for (int i = 0; i < magicSquare.Length; i++)
            for (int j = 0; j < magicSquare.Length; j++)
            {
                if (j + i > (magicSquare.Length - 1))
                {
                    var diff = j + i - (magicSquare.Length - 1);
                    var temp = newMagicSquare[i - diff][j - diff];
                    newMagicSquare[i - diff][j - diff] = newMagicSquare[i][j];
                    newMagicSquare[i][j] = temp;
                }
            }

            return newMagicSquare;
        }

        public static int[][] ReflectAlongColumns(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[magicSquare.Length],
                new int[magicSquare.Length],
                new int[magicSquare.Length],
            };

            for (int i = 0; i < magicSquare.Length; i++)
            {
                int destColumn = magicSquare.Length - 1;
                for (int j = 0; j < magicSquare.Length; j++)
                    newMagicSquare[i][destColumn - j] = magicSquare[i][j];
            }

            return newMagicSquare;
        }

        public static int[][] ReflectAlongRows(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[magicSquare.Length],
                new int[magicSquare.Length],
                new int[magicSquare.Length],
            };
            int destRow = magicSquare.Length - 1;
            for (int i = 0; i < magicSquare.Length; i++)
            {
                for (int j = 0; j < magicSquare.Length; j++)
                    newMagicSquare[destRow - i][j] = magicSquare[i][j];
            }

            return newMagicSquare;
        }

        public static int[][] Rotate(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[magicSquare.Length],
                new int[magicSquare.Length],
                new int[magicSquare.Length],
            };
            var destColumn = magicSquare.Length - 1;
            for (var i = 0; i < magicSquare.Length; i++)
            {
                for (var j = 0; j < magicSquare.Length; j++)
                    newMagicSquare[j][destColumn - i] = magicSquare[i][j];
            }

            return newMagicSquare;
        }

        public static int DiffMatrices(int[][] a, int[][] b) =>
            a.Select((t, i) => t.Zip(b[i], (i1, i2) => Math.Abs(i1 - i2)).Sum()).Sum();

        public static int FormingMagicSquare(int[][] s)
        {
            var baseSquare = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };
            var magicSquares = new List<int[][]>
            {
                baseSquare,
                Rotate(baseSquare),
                Rotate(Rotate(baseSquare)),
                Rotate(Rotate(Rotate(baseSquare))),
                ReflectAlongRows(baseSquare),
                ReflectAlongColumns(baseSquare),
                ReflectAlongMainDiagonal(baseSquare),
                ReflectAlongOffDiagonal(baseSquare)
            };
            return magicSquares.Min(ms => DiffMatrices(ms, s));
        }
    }
}
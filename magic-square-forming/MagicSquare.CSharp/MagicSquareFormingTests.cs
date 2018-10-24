using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MagicSquare.CSharp
{
    public class MagicSquareFormingTests
    {
        static int[][] ReflectAlongMainDiagonal(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[3],
                new int[3],
                new int[3],
            };
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                newMagicSquare[i][j] = magicSquare[i][j];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j < i)
                    {
                        var temp = newMagicSquare[j][i];
                        newMagicSquare[j][i] = newMagicSquare[i][j];
                        newMagicSquare[i][j] = temp;
                    }
                }
            }

            return newMagicSquare;
        }

        static int[][] ReflectAlongOffDiagonal(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[3],
                new int[3],
                new int[3],
            };
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                newMagicSquare[i][j] = magicSquare[i][j];
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j + i > 2)
                    {
                        var diff = j + i - 2;
                        var temp = newMagicSquare[i - diff][j - diff];
                        newMagicSquare[i - diff][j - diff] = newMagicSquare[i][j];
                        newMagicSquare[i][j] = temp;
                    }
                }
            }

            return newMagicSquare;
        }

        static int[][] ReflectAlongColumns(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[3],
                new int[3],
                new int[3],
            };

            for (int i = 0; i < 3; i++)
            {
                int destColumn = 2;
                for (int j = 0; j < 3; j++)
                    newMagicSquare[i][destColumn - j] = magicSquare[i][j];
            }

            return newMagicSquare;
        }

        static int[][] ReflectAlongRows(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[3],
                new int[3],
                new int[3],
            };

            for (int i = 0; i < 3; i++)
            {
                int destRow = 2;
                for (int j = 0; j < 3; j++)
                    newMagicSquare[destRow - i][j] = magicSquare[i][j];
            }

            return newMagicSquare;
        }

        static int[][] Rotate(int[][] magicSquare)
        {
            var newMagicSquare = new[]
            {
                new int[3],
                new int[3],
                new int[3],
            };
            int destColumn = 2;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    newMagicSquare[j][destColumn] = magicSquare[i][j];
                }

                destColumn--;
            }

            return newMagicSquare;
        }

        static int DiffMatrices(int[][] a, int[][] b)
        {
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            for (int j = 0; j < a.Length; j++)
                diff += Math.Abs(a[i][j] - b[i][j]);

            return diff;
        }

        static int FormingMagicSquare(int[][] s)
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

        bool IsValidMagicSquare(int[][] candidate)
        {
            var isValid = true;
            int magicConstant = 15;
            for (int i = 0; i < 3; i++)
            {
                isValid &= (candidate[0][i] + candidate[1][i] + candidate[2][i]) == magicConstant;
                isValid &= (candidate[i][0] + candidate[i][1] + candidate[i][2]) == magicConstant;
            }

            isValid &= (candidate[0][0] + candidate[1][1] + candidate[2][2]) == magicConstant;
            isValid &= (candidate[2][0] + candidate[1][1] + candidate[0][2]) == magicConstant;
            return isValid;
        }


        [Fact]
        public void GivenMagicSquare_WhenRotateOnce_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = Rotate(givenMagicSquare);
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }

        [Fact]
        public void GivenMagicSquare_WhenRotateTwice_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = Rotate(Rotate(givenMagicSquare));
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }

        [Fact]
        public void GivenMagicSquare_WhenRotateThreeTimes_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = Rotate(Rotate(Rotate(givenMagicSquare)));
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }

        [Fact]
        public void GivenMagicSquare_WhenReflectAlongColumns_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = ReflectAlongColumns(givenMagicSquare);
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }

        [Fact]
        public void GivenMagicSquare_WhenReflectAlongRows_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = ReflectAlongRows(givenMagicSquare);
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }

        [Fact]
        public void GivenMagicSquare_WhenReflectAlongMainDiagonal_ThenReturnsRightMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };
            var expected = new[]
            {
                new[] {6, 1, 8},
                new[] {7, 5, 3},
                new[] {2, 9, 4}
            };
            var anotherMagicSquare = ReflectAlongMainDiagonal(givenMagicSquare);
            Assert.Equal(expected, anotherMagicSquare);
        }

        [Fact]
        public void GivenMagicSquare_WhenReflectAlongOffDiagonal_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };
            var expected = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = ReflectAlongOffDiagonal(givenMagicSquare);
            Assert.Equal(expected, anotherMagicSquare);
        }

        [Fact]
        public void GivenNonMagicSquare_WhenGapToMakeMagicIs7_ThenReturns7()
        {
            var givenMagicSquare = new[]
            {
                new[] {5, 3, 4},
                new[] {1, 5, 8},
                new[] {6, 4, 2}
            };
            Assert.Equal(7, FormingMagicSquare(givenMagicSquare));
        }

        [Fact]
        public void GivenNonMagicSquare_WhenGapToMakeMagicIs4_ThenReturns4()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 8, 2},
                new[] {4, 5, 7},
                new[] {6, 1, 6}
            };
            Assert.Equal(4, FormingMagicSquare(givenMagicSquare));
        }

        [Fact]
        public void GivenNonMagicSquare_WhenGapToMakeMagicIs14_ThenReturns14()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 5, 8},
                new[] {2, 4, 1},
                new[] {1, 9, 7}
            };
            Assert.Equal(14, FormingMagicSquare(givenMagicSquare));
        }
    }
}
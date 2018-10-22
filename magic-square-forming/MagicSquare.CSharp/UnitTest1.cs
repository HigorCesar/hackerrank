using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MagicSquare.CSharp
{
    public class UnitTest1
    {

        static int[][] Mirror(int[][] magicSquare)
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
                    newMagicSquare[i][destColumn-j] = magicSquare[i][j];
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
        private bool IsValidMagicSquare(int[][] candidate)
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
        public void GivenMagicSquare_WhenMirror_ThenReturnsAnotherMagicSquare()
        {
            var givenMagicSquare = new[]
            {
                new[] {4, 9, 2},
                new[] {3, 5, 7},
                new[] {8, 1, 6}
            };
            var anotherMagicSquare = Mirror(givenMagicSquare);
            Assert.True(IsValidMagicSquare(anotherMagicSquare));
        }
    }
}
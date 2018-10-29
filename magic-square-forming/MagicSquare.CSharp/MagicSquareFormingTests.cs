using System.Linq;
using Xunit;

namespace MagicSquare.CSharp
{
    public class MagicSquareFormingTests
    {
        [Fact]
        public void GivenMagicSquare_WhenRotateOnce_ThenReturnsExpected()
        {
            var givenMagicSquare = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };
            var expected = new[]
            {
                new[] {8, 1, 6},
                new[] {3, 5, 7},
                new[] {4, 9, 2}
            };
            Assert.Equal(expected, Solution.Rotate(givenMagicSquare));
        }

        [Fact]
        public void GivenTwoMatrices_WhenDiff_ThenReturnsExpected()
        {
            var a = new[]
            {
                new[] {6, 7, 2},
                new[] {1, 5, 9},
                new[] {8, 3, 4}
            };
            var b = new[]
            {
                new[] {8, 1, 6},
                new[] {3, 5, 7},
                new[] {4, 9, 2}
            };
            var expected = new[]
            {
                new[] {2, 6, 4},
                new[] {2, 0, 2},
                new[] {4, 6, 2}
            };
            Assert.Equal(expected.Sum(x => x.Sum()), Solution.DiffMatrices(a, b));
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
            var expected = new[]
            {
                new[] {6, 1, 8},
                new[] {7, 5, 3},
                new[] {2, 9, 4}
            };
            var actual = Solution.Rotate(Solution.Rotate(givenMagicSquare));
            Assert.Equal(expected, actual);
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
            var expected = new[]
            {
                new[] {2, 7, 6},
                new[] {9, 5, 1},
                new[] {4, 3, 8}
            };
            var actual = Solution.Rotate(Solution.Rotate(Solution.Rotate(givenMagicSquare)));
            Assert.Equal(expected, actual);
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
            var expected = new[]
            {
                new[] {2, 9, 4},
                new[] {7, 5, 3},
                new[] {6, 1, 8}
            };
            Assert.Equal(expected, Solution.ReflectAlongColumns(givenMagicSquare));
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
            var expected = new[]
            {
                new[] {8, 1, 6},
                new[] {3, 5, 7},
                new[] {4, 9, 2}
            };

            Assert.Equal(expected, Solution.ReflectAlongRows(givenMagicSquare));
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
            Assert.Equal(expected, Solution.ReflectAlongMainDiagonal(givenMagicSquare));
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
            Assert.Equal(expected, Solution.ReflectAlongOffDiagonal(givenMagicSquare));
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
            Assert.Equal(7, Solution.FormingMagicSquare(givenMagicSquare));
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
            Assert.Equal(4, Solution.FormingMagicSquare(givenMagicSquare));
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
            Assert.Equal(14, Solution.FormingMagicSquare(givenMagicSquare));
        }
    }
}
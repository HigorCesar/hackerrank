using System;
using System.Linq;
using Xunit;

namespace Grading.Csharp
{
    public class GradingStudentsTest
    {
        static int[] gradingStudents(int[] grades)
        {
            var finalGrades = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                finalGrades[i] = grades[i];
                if (grades[i] < 38 || grades[i] % 5 < 3)
                    continue;

                finalGrades[i] += 5 - grades[i] % 5;
            }

            return finalGrades;
        }

        [Theory]
        [InlineData(new[]
        {
            73, 67, 38, 33
        }, new[]
        {
            75, 67, 40, 33
        })]
        [InlineData(new[]
        {
            0, 1, 99, 100
        }, new[]
        {
            0, 1, 100, 100
        })]
        public void GivenSample0_WhenGradingStudents_ThenReturnsAsExpected(int[] givenGrades, int[] expectations)
        {
            Assert.Equal(expectations, gradingStudents(givenGrades));
        }
    }
}
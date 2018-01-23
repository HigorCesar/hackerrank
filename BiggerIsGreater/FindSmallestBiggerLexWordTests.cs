using System;
using Xunit;

namespace BiggerIsGreater
{
    public class FindSmallestBiggerLexWordTests
    {
        [Theory]
        [InlineData("dkhc", "hcdk")]
        [InlineData("dhck", "dhkc")]
        [InlineData("bb", "no answer")]
        public void Cases(string input, string expected)
        {
            Assert.Equal(expected, FindSmallestBiggerLexWord.Execute(input));
        }
    }
}

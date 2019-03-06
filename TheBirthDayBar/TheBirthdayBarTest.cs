using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TheBirthdayBar
{
    public class TheBirthdayBarTest
    {
        static int birthday(List<int> s, int d, int m)
        {
            var matches = 0;
            for (var i = 0; i <= s.Count - m; i++)
                if (s.Skip(i).Take(m).Sum() == d)
                    matches++;

            return matches;
        }

        [Fact]
        public void Sample0()
        {
            Assert.Equal(2, birthday(new List<int>
            {
                1,
                2,
                1,
                3,
                2
            }, 3, 2));
        }
        [Fact]
        public void Sample1()
        {
            Assert.Equal(0, birthday(new List<int>
            {
               1,1,1,1,1,1
            }, 3, 2));
        }
        [Fact]
        public void Sample2()
        {
            Assert.Equal(1, birthday(new List<int>
            {
                4
            }, 4, 1));
        }
    }
}
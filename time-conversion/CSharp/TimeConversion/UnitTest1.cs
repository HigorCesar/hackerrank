using System;
using Xunit;

namespace TimeConversion
{
    public class TimeConversionTests
    {
        public static string ConvertTo24HourFormat(string input)
        {
            var containsPM = input.Contains("PM");
            var containsAM = input.Contains("AM");
            var inputWithoutAMorPM = input.Replace("PM", "").Replace("AM", "");
            var hourParts = inputWithoutAMorPM.Split(':');

            if (containsAM)
            {
                if (hourParts[0] == "12")
                    return $"00:{hourParts[1]}:{hourParts[2]}";

                return inputWithoutAMorPM;
            }

            if (hourParts[0] == "12")
                return inputWithoutAMorPM;

            return $"{Convert.ToInt32(hourParts[0]) + 12}:{hourParts[1]}:{hourParts[2]}";
        }
        [Theory]
        [InlineData("07:05:45PM", "19:05:45")]
        [InlineData("12:40:22AM", "00:40:22")]
        [InlineData("12:40:22AM", "00:40:22")]
        public void Conversion(string actual, string expected)
        {
            Assert.Equal(expected, ConvertTo24HourFormat(actual));
        }
    }
}

using JetBrains.Annotations;
using NUnit.Framework;
using RomanNumerals;

namespace RomanNumeralsTests
{
    static class Test
    {
        [AssertionMethod]
        public static void RomanToEnglishTest(string roman, int expectedAnswer)
        {
            if (RomanToEnglish.TryConvert(roman, out int answer) == false)
                Assert.Fail("Could not convert " + roman + ".");
            if (answer != expectedAnswer)
                Assert.Fail("Wrong answer. Expected " + expectedAnswer + " but was " + answer + ".");
            Assert.Pass();
        }

        [AssertionMethod]
        public static void EnglishToRomanTest(int number, string expectedAnswer)
        {
            if (EnglishToRoman.TryConvert(number, out string answer) == false)
                Assert.Fail("Could not convert " + number + ".");
            if (answer != expectedAnswer)
                Assert.Fail("Wrong answer. Expected " + expectedAnswer + " but was " + answer + ".");
            Assert.Pass();
        }
    }
}

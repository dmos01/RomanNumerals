using System;
using NUnit.Framework;
using RomanNumerals;

namespace RomanNumeralsTests
{
    [TestFixture]
    class RomanMoreThanThreeSameChars
    {
        [Test]
        public void Four()
        {
            try
            {
                RomanToEnglish.TryConvert("IIII", out _);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.Pass();
        }

        [Test]
        public void Nine()
        {
            try
            {
                RomanToEnglish.TryConvert("VIIII", out _);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.Pass();
        }
    }
}
using NUnit.Framework;
using RomanNumerals;

namespace RomanNumeralsTests
{
    [TestFixture]
    class RomanCharacters
    {
        [Test]
        public void One()
        {
            if (RomanToEnglish.TryConvert('I', out int english)
                && english == 1)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Five()
        {
            if (RomanToEnglish.TryConvert('V', out int english)
                && english == 5)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
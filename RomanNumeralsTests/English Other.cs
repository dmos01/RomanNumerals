using NUnit.Framework;

namespace RomanNumeralsTests
{
    [TestFixture]
    class EnglishOther
    {
        [Test]
        public void _48() => Test.EnglishToRomanTest(48, "XLVIII");

        [Test]
        public void _49() => Test.EnglishToRomanTest(49, "XLIX");

        [Test]
        public void _50() => Test.EnglishToRomanTest(50, "L");

        [Test]
        public void _98() => Test.EnglishToRomanTest(98, "XCVIII");

        [Test]
        public void _99() => Test.EnglishToRomanTest(99, "XCIX");

        [Test]
        public void _100() => Test.EnglishToRomanTest(100, "C");

        [Test]
        public void _998() => Test.EnglishToRomanTest(998, "CMXCVIII");

        [Test]
        public void _999() => Test.EnglishToRomanTest(999, "CMXCIX");

        [Test]
        public void _1000() => Test.EnglishToRomanTest(1000, "M");


    }
}

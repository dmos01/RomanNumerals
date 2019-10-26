using NUnit.Framework;

namespace RomanNumeralsTests
{
    [TestFixture]
    class RomanOther
    {
        [Test]
        public void _48() => Test.RomanToEnglishTest("XLVIII", 48);

        [Test]
        public void _49() => Test.RomanToEnglishTest("XLIX", 49);

        [Test]
        public void _50() => Test.RomanToEnglishTest("L", 50);

        [Test]
        public void _98() => Test.RomanToEnglishTest("XCVIII", 98);

        [Test]
        public void _99() => Test.RomanToEnglishTest("XCIX", 99);

        [Test]
        public void _100() => Test.RomanToEnglishTest("C", 100);

        [Test]
        public void _998() => Test.RomanToEnglishTest("CMXCVIII", 998);

        [Test]
        public void _999() => Test.RomanToEnglishTest("CMXCIX", 999);

        [Test]
        public void _1000() => Test.RomanToEnglishTest("M", 1000);


    }
}

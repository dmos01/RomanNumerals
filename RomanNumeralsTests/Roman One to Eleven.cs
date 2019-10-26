using NUnit.Framework;

namespace RomanNumeralsTests
{
    [TestFixture]
    public class RomanOneToEleven
    {
        [Test]
        public void One() => Test.RomanToEnglishTest("I", 1);

        [Test]
        public void Two() => Test.RomanToEnglishTest("II", 2);

        [Test]
        public void Three() => Test.RomanToEnglishTest("III", 3);

        [Test]
        public void Four() => Test.RomanToEnglishTest("IV", 4);

        [Test]
        public void Five() => Test.RomanToEnglishTest("V", 5);

        [Test]
        public void Six() => Test.RomanToEnglishTest("VI", 6);

        [Test]
        public void Seven() => Test.RomanToEnglishTest("VII", 7);

        [Test]
        public void Eight() => Test.RomanToEnglishTest("VIII", 8);

        [Test]
        public void Nine() => Test.RomanToEnglishTest("IX", 9);

        [Test]
        public void Ten() => Test.RomanToEnglishTest("X", 10);

        [Test]
        public void Eleven() => Test.RomanToEnglishTest("XI", 11);
    }
}
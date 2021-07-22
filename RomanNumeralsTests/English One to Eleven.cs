using NUnit.Framework;

namespace RomanNumeralsTests
{
    class EnglishOneToEleven
    {
        [Test]
        public void One() => Test.EnglishToRomanTest(1, "I");

        [Test]
        public void Two() => Test.EnglishToRomanTest(2, "II");

        [Test]
        public void Three() => Test.EnglishToRomanTest(3, "III");

        [Test]
        public void Four() => Test.EnglishToRomanTest(4, "IV");

        [Test]
        public void Five() => Test.EnglishToRomanTest(5, "V");

        [Test]
        public void Six() => Test.EnglishToRomanTest(6, "VI");

        [Test]
        public void Seven() => Test.EnglishToRomanTest(7, "VII");

        [Test]
        public void Eight() => Test.EnglishToRomanTest(8, "VIII");

        [Test]
        public void Nine() => Test.EnglishToRomanTest(9, "IX");

        [Test]
        public void Ten() => Test.EnglishToRomanTest(10, "X");

        [Test]
        public void Eleven() => Test.EnglishToRomanTest(11, "XI");
    }
}
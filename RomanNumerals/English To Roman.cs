using System;
using System.Text;
using static RomanNumerals.Converters;

namespace RomanNumerals
{
    /// <summary>
    ///     Static class.
    /// </summary>
    public static class EnglishToRoman
    {
        public const int MaxEnglishNumber = 3999;

        /// <summary>
        /// </summary>
        /// <param name="englishNumber">Between 1 and 3999.</param>
        /// <returns></returns>
        public static string Convert(int englishNumber)
        {
            if (englishNumber < 1 || englishNumber > MaxEnglishNumber)
                throw new ArgumentOutOfRangeException();

            char[] charArray = englishNumber.ToString().ToCharArray();
            int length = charArray.Length;
            byte[] digitArray = new byte[length];
            for (byte i = 0; i < charArray.Length; i++)
                digitArray[i] = byte.Parse(charArray[i].ToString());

            StringBuilder output = new StringBuilder();

            for (byte i = 0; i < length; i++)
            {
                //Last index is 1s column and so on up. - 1 for 10^0 = 1.
                int power = length - i - 1;
                AddColumn((int) Math.Pow(10, power), i);
            }

            return output.ToString();

            //Column = 1, 10, 100 or 1000.
            void AddColumn(int column, byte indexOfColumn)
            {
                switch (digitArray[indexOfColumn])
                {
                    case 9:
                        output.Append(EnglishToRomanCharacter[column].ToString());
                        output.Append(EnglishToRomanCharacter[column * 10].ToString());
                        break;
                    case 4:
                        output.Append(EnglishToRomanCharacter[column].ToString());
                        output.Append(EnglishToRomanCharacter[column * 5].ToString());
                        break;

                    default:
                        if (digitArray[indexOfColumn] > 4)
                        {
                            output.Append(EnglishToRomanCharacter[column * 5].ToString());
                            digitArray[indexOfColumn] -= 5;
                        }

                        while (digitArray[indexOfColumn] > 0)
                        {
                            output.Append(EnglishToRomanCharacter[column]);
                            digitArray[indexOfColumn]--;
                        }

                        break;
                }
            }
        }

        /// <summary>
        ///     Outputs null if fails.
        /// </summary>
        /// <param name="englishNumber">Between 1 and 3999.</param>
        /// <param name="romanString">Null if fails.</param>
        /// <returns></returns>
        public static bool TryConvert(int englishNumber, out string romanString)
        {
            try
            {
                romanString = Convert(englishNumber);
                return true;
            }
            catch
            {
                romanString = null;
                return false;
            }
        }
    }
}
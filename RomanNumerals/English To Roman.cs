using System;
using JetBrains.Annotations;
using static RomanNumerals.Converters;

namespace RomanNumerals
{
    /// <summary>
    /// Static class.
    /// </summary>
    public static class EnglishToRoman
    {
        public const int MaxEnglishNumber = 3999;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="englishNumber">Between 1 and 3999.</param>
        /// <returns></returns>
        [NotNull]
        public static string Convert(int englishNumber)
        {
            if (englishNumber < 1 || englishNumber > MaxEnglishNumber)
                throw new ArgumentOutOfRangeException();

            byte[] digitArray = ToDigitArrayPaddedWithOpeningZeroes(englishNumber);
            string output = "";

            for (byte i = 0; i < MaxEnglishNumber.ToString().Length; i++)
            {
                int column;
                switch (i)
                {
                    case 0:
                        column = 1000;
                        break;
                    case 1:
                        column = 100;
                        break;
                    case 2:
                        column = 10;
                        break;
                    case 3:
                        column = 1;
                        break;
                    default:
                        throw new Exception();
                }

                switch (digitArray[i])
                {
                    case 9:
                        output += ConvertEnglishToRoman[column].ToString();
                        output += ConvertEnglishToRoman[column * 10].ToString();
                        break;
                    case 4:
                        output += ConvertEnglishToRoman[column].ToString();
                        output += ConvertEnglishToRoman[column * 5].ToString();
                        break;
                    default:
                        {
                            if (digitArray[i] > 4)
                            {
                                output += ConvertEnglishToRoman[column * 5].ToString();
                                digitArray[i] -= 5;
                            }

                            while (digitArray[i] > 0)
                            {
                                output += ConvertEnglishToRoman[column];
                                digitArray[i]--;
                            }

                            break;
                        }
                }
            }

            return output;
        }

        /// <summary>
        /// Outputs null if fails.
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

        /// <summary>
        /// Creates a 4-character (MaxEnglishNumber.Length) byte array, padded at start by 0s if necessary.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static byte[] ToDigitArrayPaddedWithOpeningZeroes(int input)
        {
            char[] charArray = input.ToString("D" + MaxEnglishNumber.ToString().Length).ToCharArray();
            byte[] byteArray = new byte[charArray.Length];
            for (byte i = 0; i < charArray.Length; i++)
                byteArray[i] = byte.Parse(charArray[i].ToString());
            return byteArray;
        }
    }
}
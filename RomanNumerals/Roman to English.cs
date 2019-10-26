using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    /// <summary>
    /// Static class.
    /// </summary>
    public static class RomanToEnglish
    {
        static int output;
        static List<char> inputList;
        static int countOfNumeralsRepresentingColumnNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="romanCharacter"></param>
        /// <returns></returns>
        public static int Convert(char romanCharacter)
            => Converters.ConvertRomanToEnglish[char.ToUpper(romanCharacter)];

        /// <summary>
        /// Outputs -1 if fails.
        /// </summary>
        /// <param name="romanCharacter"></param>
        /// <param name="englishNumber">-1 if fails.</param>
        /// <returns></returns>
        public static bool TryConvert(char romanCharacter, out int englishNumber)
        {
            try
            {
                englishNumber = Converters.ConvertRomanToEnglish[char.ToUpper(romanCharacter)];
                return true;
            }
            catch
            {
                englishNumber = -1;
                return false;
            }
        }

        /// <summary>
        /// Up to English value 3999.
        /// </summary>
        /// <param name="romanString"></param>
        /// <returns></returns>
        public static int Convert([NotNull]string romanString)
        {
            romanString = romanString.ToUpper();
            output = 0;
            inputList = romanString.ToList();

            Handle(1);
            EndsWithTwoCharactersRepresentingNines(1);
            EndsWithCharacterRepresentingFives(1);

            Handle(10);
            EndsWithTwoCharactersRepresentingNines(10);
            EndsWithCharacterRepresentingFives(10);

            Handle(100);
            EndsWithTwoCharactersRepresentingNines(100);
            EndsWithCharacterRepresentingFives(100);

            Handle(1000);

            return output;
        }

        /// <summary>
        /// Up to English value 3999. Outputs -1 if fails.
        /// </summary>
        /// <param name="romanString"></param>
        /// <param name="englishNumber">-1 if fails.</param>
        /// <returns></returns>
        public static bool TryConvert([NotNull]string romanString, out int englishNumber)
        {
            try
            {
                englishNumber = Convert(romanString);
                return true;
            }
            catch
            {
                englishNumber = -1;
                return false;
            }
        }

        /// <summary>
        /// Handle Roman Numerals representing English 10s: I, X, C, M.
        /// </summary>
        /// <param name="base10Column">1, 10, 100 or 1000.</param>
        private static void Handle(int base10Column)
        {
            countOfNumeralsRepresentingColumnNumber =
                inputList.Count(x => x == Converters.ConvertEnglishToRoman[base10Column]);
            if (countOfNumeralsRepresentingColumnNumber > 3)
                throw new ArgumentException();

            while (inputList.Any() && inputList[inputList.Count - 1] == Converters.ConvertEnglishToRoman[base10Column])
            {
                output += base10Column;
                inputList.RemoveAt(inputList.Count - 1);
                countOfNumeralsRepresentingColumnNumber--;
            }
        }

        /// <summary>
        /// For example, IX.
        /// </summary>
        /// <param name="base10Column">1, 10, 100 or 1000.</param>
        private static void EndsWithTwoCharactersRepresentingNines(int base10Column)
        {
            if (inputList.Count > 1 &&
                inputList[inputList.Count - 1] == Converters.ConvertEnglishToRoman[base10Column * 10] &&
                inputList[inputList.Count - 2] == Converters.ConvertEnglishToRoman[base10Column])
            {
                output += base10Column * 9;
                inputList.RemoveAt(inputList.Count - 1);
                inputList.RemoveAt(inputList.Count - 1);
                countOfNumeralsRepresentingColumnNumber--;
            }
        }

        /// <summary>
        /// Adds V or L to the static output. They can only appear once each and cannot subtract.
        /// </summary>
        /// <param name="base10Column">1, 10, 100 or 1000.</param>
        private static void EndsWithCharacterRepresentingFives(int base10Column)
        {
            int five = base10Column * 5;

            if (inputList.Any() && inputList[inputList.Count - 1] == Converters.ConvertEnglishToRoman[five])
            {
                //Has found a 'five' numeral in this Base 10 Column but output has already reached 9 in the Base 10 Column. Impossible.
                if (output >= base10Column * 9)
                    throw new Exception();

                if (inputList.Count == 1)
                {
                    output += five;
                    return;
                }

                if (inputList[inputList.Count - 2] == Converters.ConvertEnglishToRoman[base10Column]
                ) //Ends with IV, for example.
                {
                    output += base10Column * 4;
                    inputList.RemoveAt(inputList.Count - 1);
                    inputList.RemoveAt(inputList.Count - 1);
                    countOfNumeralsRepresentingColumnNumber--;
                    return;
                }

                output += five;
                inputList.RemoveAt(inputList.Count - 1);
            }

            //The current Base 10 Column has not been properly dealt with.
            if (countOfNumeralsRepresentingColumnNumber > 0 || inputList.Contains(Converters.ConvertEnglishToRoman[five]))
                throw new Exception();
        }
    }
}
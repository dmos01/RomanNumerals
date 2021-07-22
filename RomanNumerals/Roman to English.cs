using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    /// <summary>
    ///     Static class.
    /// </summary>
    public static class RomanToEnglish
    {
        static int output;
        static List<char> characterList;
        static char characterOfColumn;

        /// <summary>
        /// </summary>
        /// <param name="romanCharacter">In uppercase.</param>
        /// <returns></returns>
        public static int Convert(char romanCharacter)
            => Converters.RomanCharacterToEnglish[char.ToUpper(romanCharacter)];

        /// <summary>
        ///     Outputs -1 if fails.
        /// </summary>
        /// <param name="romanCharacter"></param>
        /// <param name="englishNumber">-1 if fails.</param>
        /// <returns></returns>
        public static bool TryConvert(char romanCharacter, out int englishNumber)
        {
            try
            {
                englishNumber = Converters.RomanCharacterToEnglish[char.ToUpper(romanCharacter)];
                return true;
            }
            catch
            {
                englishNumber = -1;
                return false;
            }
        }


        /// <summary>
        ///     Up to English value 3999.
        /// </summary>
        /// <param name="romanString"></param>
        /// <returns></returns>
        public static int Convert(string romanString)
        {
            if (romanString is null)
                throw new ArgumentNullException();

            characterList = new List<char>(romanString.Length);
            characterList.AddRange(from x in romanString where x != ' ' select char.ToUpper(x));
            if (characterList.Count == 0)
                throw new ArgumentException();

            output = 0;

            HandleColumn(1);
            HandleColumn(10);
            HandleColumn(100);
            characterOfColumn = Converters.EnglishToRomanCharacter[1000];
            EndsWithNonFiveNonNineCharacter(1000);

            characterList = null;
            return output;

            void HandleColumn(int column)
            {
                characterOfColumn = Converters.EnglishToRomanCharacter[column];
                EndsWithNonFiveNonNineCharacter(column);
                EndsWithTwoCharactersRepresentingNines(column);
                EndsWithCharacterRepresentingFives(column);
            }
        }

        /// <summary>
        ///     Handle Roman Numerals representing English 10s: I, X, C, M.
        /// </summary>
        /// <param name="column">1, 10, 100 or 1000.</param>
        private static void EndsWithNonFiveNonNineCharacter(int column)
        {
            while (characterList.Any() && characterList[characterList.Count - 1] == characterOfColumn)
            {
                output += column;
                characterList.RemoveAt(characterList.Count - 1);
            }
        }

        /// <summary>
        ///     For example, IX.
        /// </summary>
        /// <param name="column">1, 10, 100 or 1000.</param>
        private static void EndsWithTwoCharactersRepresentingNines(int column)
        {
            if (characterList.Count > 1 &&
                characterList[characterList.Count - 1] == Converters.EnglishToRomanCharacter[column * 10] &&
                characterList[characterList.Count - 2] == characterOfColumn)
            {
                output += column * 9;
                characterList.RemoveAt(characterList.Count - 1);
                characterList.RemoveAt(characterList.Count - 1);
            }
        }

        /// <summary>
        ///     Adds V or L to the static output. They can only appear once each and cannot subtract.
        /// </summary>
        /// <param name="column">1, 10, 100 or 1000.</param>
        private static void EndsWithCharacterRepresentingFives(int column)
        {
            int five = column * 5;

            if (!characterList.Any() ||
                characterList[characterList.Count - 1] != Converters.EnglishToRomanCharacter[five])
                return;

            //Has found a 'five' numeral in this column but output has already reached 9 in the column. Impossible.
            if (output >= column * 9)
                throw new Exception();

            if (characterList.Count == 1)
            {
                output += five;
                return;
            }

            if (characterList[characterList.Count - 2] == characterOfColumn) //Ends with IV, for example.
            {
                output += column * 4;
                characterList.RemoveAt(characterList.Count - 1);
                characterList.RemoveAt(characterList.Count - 1);
                return;
            }

            output += five;
            characterList.RemoveAt(characterList.Count - 1);
        }


        /// <summary>
        ///     Up to English value 3999. Outputs -1 if fails.
        /// </summary>
        /// <param name="romanString"></param>
        /// <param name="englishNumber">-1 if fails.</param>
        /// <returns></returns>
        public static bool TryConvert(string romanString, out int englishNumber)
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
    }
}
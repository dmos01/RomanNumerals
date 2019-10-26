using System.Collections.Generic;

namespace RomanNumerals
{
    internal static class Converters
    {
        public static readonly Dictionary<char, int> ConvertRomanToEnglish =
            new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

        public static readonly Dictionary<int, char> ConvertEnglishToRoman =
            new Dictionary<int, char>
            {
                {1, 'I'},
                {5, 'V'},
                {10, 'X'},
                {50, 'L'},
                {100, 'C'},
                {500, 'D'},
                {1000, 'M'}
            };
    }
}
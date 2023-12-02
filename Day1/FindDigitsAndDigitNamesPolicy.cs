using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class FindDigitsAndDigitNamesPolicy : IDigitFinderPolicy
    {
        private readonly Dictionary<string, int> TextToDigit = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };

        private readonly FindDigitsOnlyPolicy findDigitsOnly = new();

        public int GetFirstDigit(string input)
            => GetDigit(input, (10, int.MaxValue), (input, key) => input.IndexOf(key), (a, b) => a < b, findDigitsOnly.GetFirstDigit);

        public int GetLastDigit(string input)
            => GetDigit(input, (0, int.MinValue), (input, key) => input.LastIndexOf(key), (a, b) => a > b, findDigitsOnly.GetLastDigit);

        private int GetDigit(string input, 
                             (int digit, int index) digitNameAndIndex, 
                             Func<string, string, int> FindIndex,  
                             Func<int, int, bool> CompareInts, 
                             Func<string, int> FindDigit)
        {
            foreach (var digitNameAndValue in TextToDigit)
            {
                var indexOfDigitName = FindIndex(input, digitNameAndValue.Key);
                if ((indexOfDigitName != -1) && CompareInts(indexOfDigitName, digitNameAndIndex.index))
                {
                    digitNameAndIndex.digit = digitNameAndValue.Value;
                    digitNameAndIndex.index = indexOfDigitName;
                }
            }

            var digit = FindDigit(input);

            return CompareInts(FindIndex(input, digit.ToString()), digitNameAndIndex.index)
                         ? digit
                         : digitNameAndIndex.digit;
        }
    }
}

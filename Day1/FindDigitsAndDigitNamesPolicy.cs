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


        public int GetFirstDigit(string input)
            => GetDigit(input, (10, int.MaxValue), (input, key) => input.IndexOf(key), (a, b) => a < b, input => input.First(char.IsDigit));


        public int GetLastDigit(string input)
            => GetDigit(input, (0, int.MinValue), (input, key) => input.LastIndexOf(key), (a, b) => a > b, input => input.Last(char.IsDigit));

        private int GetDigit(string input, 
                             (int digit, int index) digitNameAndIndex, 
                             Func<string, string, int> FindIndex,  
                             Func<int, int, bool> CompareInts, 
                             Func<string, char> FindDigitChar)
        {

            foreach (var digit in TextToDigit)
            {
                var indexOfDigitName = FindIndex(input, digit.Key);
                if ((indexOfDigitName != -1) && CompareInts(indexOfDigitName, digitNameAndIndex.index))
                {
                    digitNameAndIndex.Item1 = digit.Value;
                    digitNameAndIndex.Item2 = indexOfDigitName;
                }
            }

            var digitChar = FindDigitChar(input);

            return CompareInts(FindIndex(input, digitChar.ToString()), digitNameAndIndex.index)
                         ? digitChar - '0'
                         : digitNameAndIndex.digit;
        }
    }
}

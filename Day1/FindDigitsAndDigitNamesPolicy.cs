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
        {
            var firstDigitNameAndIndex = (10, int.MaxValue);

            foreach (var digit in TextToDigit)
            {
                var firstIndexOfDigitName = input.IndexOf(digit.Key);
                if ((firstIndexOfDigitName != -1) && (firstIndexOfDigitName < firstDigitNameAndIndex.Item2))
                {
                    firstDigitNameAndIndex.Item1 = digit.Value;
                    firstDigitNameAndIndex.Item2 = firstIndexOfDigitName;
                }
            }

            var firstDigitChar = input.First(char.IsDigit);

            return input.IndexOf(firstDigitChar) < firstDigitNameAndIndex.Item2
                         ? firstDigitChar - '0'
                         : firstDigitNameAndIndex.Item1;
        }

        public int GetLastDigit(string input)
        {
            var lastDigitNameAndIndex = (0, int.MinValue);

            foreach (var digit in TextToDigit)
            {
                var lastIndexOfDigitName = input.LastIndexOf(digit.Key);
                if ((lastIndexOfDigitName != -1) && (lastIndexOfDigitName > lastDigitNameAndIndex.Item2))
                {
                    lastDigitNameAndIndex.Item1 = digit.Value;
                    lastDigitNameAndIndex.Item2 = lastIndexOfDigitName;
                }
            }

            var lastDigitChar = input.Last(char.IsDigit);

            return input.LastIndexOf(lastDigitChar) > lastDigitNameAndIndex.Item2
                         ? lastDigitChar - '0'
                         : lastDigitNameAndIndex.Item1;
        }
    }
}

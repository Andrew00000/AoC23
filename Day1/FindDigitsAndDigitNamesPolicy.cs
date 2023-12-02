namespace Day1
{
    public class FindDigitsAndDigitNamesPolicy : IDigitFinderPolicy
    {
        private readonly Dictionary<string, int> textToDigit = new()
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
                             Func<string, string, int> findIndex,
                             Func<int, int, bool> compareInts,
                             Func<string, int> findDigit)
        {
            foreach (var digitNameAndValue in textToDigit)
            {
                var indexOfDigitName = findIndex(input, digitNameAndValue.Key);
                if ((indexOfDigitName != -1) && compareInts(indexOfDigitName, digitNameAndIndex.index))
                {
                    digitNameAndIndex.digit = digitNameAndValue.Value;
                    digitNameAndIndex.index = indexOfDigitName;
                }
            }

            var digit = findDigit(input);

            return compareInts(findIndex(input, digit.ToString()), digitNameAndIndex.index)
                         ? digit
                         : digitNameAndIndex.digit;
        }
    }
}

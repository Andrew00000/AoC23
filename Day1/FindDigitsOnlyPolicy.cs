namespace Day1
{
    public class FindDigitsOnlyPolicy : IDigitFinderPolicy
    {
        public int GetFirstDigit(string input)
            => input.First(char.IsDigit) - '0';

        public int GetLastDigit(string input)
            => input.Last(char.IsDigit) - '0';
    }
}

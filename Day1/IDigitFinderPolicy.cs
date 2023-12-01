namespace Day1
{
    public interface IDigitFinderPolicy
    {
        public int GetFirstDigit(string input);
        public int GetLastDigit(string input);
    }
}
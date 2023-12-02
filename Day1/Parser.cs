namespace Day1
{
    internal class Parser
    {
        private readonly IDigitFinderPolicy policy;

        public Parser(IDigitFinderPolicy policy)
        {
            this.policy = policy;
        }

        public int GetNumber(string input)
            => GetFirstDigit(input) * 10 + GetLastDigit(input);

        private int GetFirstDigit(string input)
            => policy.GetFirstDigit(input);

        private int GetLastDigit(string input)
            => policy.GetLastDigit(input);

    }
}

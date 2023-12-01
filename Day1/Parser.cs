namespace Day1
{
    internal class Parser
    {
        private readonly IDigitFinderPolicy policy;

        public Parser(IDigitFinderPolicy policy)
        {
            this.policy = policy;
        }

       public int GetFirstDigit(string input)
            => policy.GetFirstDigit(input);

       public int GetLastDigit(string input)
            => policy.GetLastDigit(input);
    }
}

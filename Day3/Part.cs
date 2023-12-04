using System.Reflection;

namespace Day3
{
    public record Part
    {
        public int Number { get; init; }
        public bool IsMissing { get; init; }

        public Part(int number, HashSet<char> neighbours) 
        { 
            Number = number;
            IsMissing = !neighbours.Any(IsSymbol); ;
        }

        private bool IsSymbol(char character)
            => !char.IsDigit(character) && character != '.';
    }
}

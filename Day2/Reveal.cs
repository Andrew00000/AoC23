namespace Day2
{
    public class Reveal
    {
        private readonly int green;
        private readonly int blue;
        private readonly int red;
        public Reveal(int green, int blue, int red)
        {
            this.green = green;
            this.blue = blue;
            this.red = red;
        }
        public bool IsAnyLargerThan(Reveal comparedTo)
            => IsGreenLargerThan(comparedTo) || IsBlueLargerThan(comparedTo) || IsRedLargerThan(comparedTo);
        public long GetThePowerOfTheReveal()
            => 1L * green * blue * red;
        public Reveal GetMinimumRevealNeeded(Reveal comparedTo)
            => new(FindMinGreenNeeded(comparedTo), FindMinBlueNeeded(comparedTo), FindMinRedNeeded(comparedTo));
        private bool IsGreenLargerThan(Reveal comparedTo)
            => green > comparedTo.green;
        private bool IsBlueLargerThan(Reveal comparedTo)
            => blue > comparedTo.blue;
        private bool IsRedLargerThan(Reveal comparedTo)
            => red > comparedTo.red;
        private int FindMinGreenNeeded(Reveal comparedTo)
            => Math.Max(green, comparedTo.green);
        private int FindMinBlueNeeded(Reveal comparedTo)
            => Math.Max(blue, comparedTo.blue);
        private int FindMinRedNeeded(Reveal comparedTo)
            => Math.Max(red, comparedTo.red);
    }
}

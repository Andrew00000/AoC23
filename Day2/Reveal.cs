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
        public Reveal GetMinimumRevealNeeded(Reveal[] pool)
            => new(FindMinGreenNeeded(pool), FindMinBlueNeeded(pool), FindMinRedNeeded(pool));
        private bool IsGreenLargerThan(Reveal comparedTo)
            => green > comparedTo.green;
        private bool IsBlueLargerThan(Reveal comparedTo)
            => blue > comparedTo.blue;
        private bool IsRedLargerThan(Reveal comparedTo)
            => red > comparedTo.red;
        private int FindMinGreenNeeded(Reveal[] pool)
            => pool.Select(x => x.green).Max();
        private int FindMinBlueNeeded(Reveal[] pool)
            => pool.Select(x => x.blue).Max();
        private int FindMinRedNeeded(Reveal[] pool)
            => pool.Select(x => x.red).Max();
    }
}

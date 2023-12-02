namespace Day2
{
    public class Game
    {
        public int Id { get; init; }
        private readonly Reveal[] reveals;

        public Game(int id, Reveal[] reveals)
        {
            Id = id;
            this.reveals = reveals;
        }

        public bool IsValidGame(Reveal maxReveal)
            => reveals.All(x => !x.IsAnyLargerThan(maxReveal));

        public long GetMinimumPower()
            => reveals[0].GetMinimumRevealNeeded(reveals).GetThePowerOfTheReveal();
    }
}

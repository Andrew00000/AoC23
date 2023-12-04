public class Card
{
    public int Id { get; init; }
    private readonly HashSet<int> winningNumbers;
    private readonly HashSet<int> cardNumbers;

    public Card(int id, IEnumerable<int> winningNumbers, IEnumerable<int> cardNumbers)
    {
        Id = id;
        this.winningNumbers = winningNumbers.ToHashSet();
        this.cardNumbers = cardNumbers.ToHashSet();
    }

    public int GetNumberOfMatches()
        => winningNumbers.Intersect(cardNumbers).Count();
    public int GetWinnings()
        => GetNumberOfMatches() == 0? 0 : 1 << (GetNumberOfMatches() - 1);
}
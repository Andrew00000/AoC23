public class Card
{
    private readonly HashSet<int> winningNumbers;
    private readonly HashSet<int> cardNumbers;

    public Card(HashSet<int> winningNumbers, HashSet<int> cardNumbers)
    {
        this.winningNumbers = winningNumbers;
        this.cardNumbers = cardNumbers;
    }

    public int GetNumberOfMatches()
        => winningNumbers.Intersect(cardNumbers).Count();
    public int GetWinnings()
        => (int) Math.Pow(2, GetNumberOfMatches() - 1);
}
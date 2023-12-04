internal class Bookie
{
    public int[] GetWinnings(Card[] cards)
    {
        var cardCounts = new int[cards.Length];

        for (var i = 0; i < cards.Length; i++)
        {
            cardCounts[i] += 1;
            var winning = cards[i].GetNumberOfMatches();

            for (var j = i + 1; j <= i + winning; j++)
            {
                cardCounts[j] += cardCounts[i];
            }
        }

        return cardCounts;
    }
}
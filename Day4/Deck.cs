internal class Deck
{
    public Dictionary<int, int> ExecuteCards(IEnumerable<Card> inputCards)
    {
        var cardCounts = new Dictionary<int, int>();
        foreach (var card in inputCards)
        {
            cardCounts[card.Id] = 1;
        }

        var index = 0;
        foreach (var card in inputCards)
        {
            var winning = card.GetNumberOfMatches();

            for (var j = 0; j < winning; j++)
            {
                var key = j + index + 1;
                cardCounts[key] += cardCounts[index];
            }

            index++;
        }

        return cardCounts;
    }
}
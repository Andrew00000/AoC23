public class Parser
{
    public IEnumerable<Card> Parse(string[] input)
    {
        var cards = new Card[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            var raw = input[i].Split(": ")[1].Split(" | ");

            var winning = raw[0].Trim().Replace("  ", " ").Split(' ').Select(int.Parse).ToHashSet();

            var card = raw[1].Trim().Replace("  ", " ").Split(' ').Select(int.Parse).ToHashSet();

            cards[i] = new Card(winning, card);
        }

        return cards;
    }
}
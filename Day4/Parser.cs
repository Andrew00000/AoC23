public class Parser
{
    public IEnumerable<Card> Parse(IEnumerable<string> input)
    {
        var cards = new List<Card>();
        foreach (var line in input)
        {
            var id = int.Parse(line.Split(": ")[0].Split("Card ")[1].Trim()) - 1;

            var raw = line.Split(": ")[1].Split(" | ");
            var winning = raw[0].Trim().Replace("  ", " ").Split(' ').Select(int.Parse);
            var card = raw[1].Trim().Replace("  ", " ").Split(' ').Select(int.Parse);

            cards.Add(new Card(id, winning, card));
        }

        return cards;
    }
}
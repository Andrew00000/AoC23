internal class Parser
{
    private readonly Dictionary<char, int> cardsWithoutJokerToInt = new Dictionary<char, int>
    {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 }
    };

    private readonly Dictionary<char, int> cardsWithJokerToInt;

    public Parser()
    {
        cardsWithJokerToInt = new Dictionary<char, int>(cardsWithoutJokerToInt);
        cardsWithJokerToInt['J'] = 1;
    }

    public IEnumerable<Hand> Parse(IEnumerable<string> input)
    {
        var hands = new List<Hand>();

        foreach (var handRaw in input)
        {
            var bid = int.Parse(handRaw.Split(' ')[1]);

            var valuesRaw = handRaw.Split(' ')[0];
            var values = valuesRaw.Select(x => cardsWithoutJokerToInt[x]);            
            var groupedValues = values.GroupBy(x => x).OrderByDescending(x => x.Count());
            var strength = GetStrength(groupedValues.First().Count(), groupedValues.Count());

            hands.Add(new Hand(values, strength, bid));
        }

        return hands;
    }

    public IEnumerable<Hand> ParseWithJokers(IEnumerable<string> input)
    {

        var hands = new List<Hand>();

        foreach (var handRaw in input)
        {
            var bid = int.Parse(handRaw.Split(' ')[1]);

            var valuesRaw = handRaw.Split(' ')[0];
            var values = valuesRaw.Select(x => cardsWithJokerToInt[x]);
            var groupedValues = values.Where(x => x != 1).GroupBy(x => x).OrderByDescending(x => x.Count());
            var jokers = values.Where(x => x == 1).Count();
            var strength = GetStrengthWithJokers(groupedValues, jokers);

            hands.Add(new Hand(values, strength, bid));
        }

        return hands;
    }

    private Strength GetStrengthWithJokers(IOrderedEnumerable<IGrouping<int, int>> groupedValues, int jokers)
    {
        var numberOfGroups = groupedValues.Count() == 0 ? 1 : groupedValues.Count(); 

        var firstGroupCountWithOutJokers = groupedValues.Count() == 0 ? 0 : groupedValues.First().Count();
        var firstGroupCount = firstGroupCountWithOutJokers + jokers;

        return GetStrength(firstGroupCount, numberOfGroups);
    }

    private Strength GetStrength(int firstGroupCount, int numberOfGroups)
        => (firstGroupCount, numberOfGroups) switch
            {
                (5, 1) => Strength.FiveOfAKind,
                (4, 2) => Strength.FourOfAKind,
                (3, 2) => Strength.FullHouse,
                (3, 3) => Strength.TheeOfAKind,
                (2, 3) => Strength.TwoPair,
                (2, 4) => Strength.OnePair,
                (1, 5) => Strength.HighCard,
                _ => throw new ArgumentOutOfRangeException($"I dont know this hand strength: {firstGroupCount}, {numberOfGroups}"),
            };
}
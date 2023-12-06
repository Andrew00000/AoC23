internal class Parser
{
    public IEnumerable<Race> Parse(IEnumerable<string> input)
    {
        var times = input.First().Split(":")[1].Split(' ').Where(x => x != "").Select(long.Parse);
        var records = input.Last().Split(":")[1].Split(' ').Where(x => x != "").Select(long.Parse);

        return times.Zip(records, (times, records) => new Race(times, records));
    }

    public Race ParseToOneRace(IEnumerable<string> input)
    {
        var time = long.Parse(input.First().Where(char.IsDigit).Aggregate("", (acc, x) => acc += x));
        var record = long.Parse(input.Last().Where(char.IsDigit).Aggregate("", (acc, x) => acc += x));

        return new Race(time,record);
    }

}
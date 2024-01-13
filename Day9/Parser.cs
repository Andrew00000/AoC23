public class Parser
{
    public IEnumerable<Reading> Parse(string[] input)
    {
        var readings = new List<Reading>();

        foreach (var line in input)
        {
            readings.Add(new Reading(line.Split(' ').Select(long.Parse)));
        }

        return readings;
    }
}
internal class Parser
{
    public IEnumerable<Map> Parse(IEnumerable<string> input)
    {
        var maps = new List<Map>();
        foreach (var mapRaw in input)
        {
            var valuesRaw = mapRaw.Split($":{Environment.NewLine}")[1].Split(Environment.NewLine);

            var mapSegments = new List<MapSegments>();

            foreach (var segment in valuesRaw)
            {
                var values = segment.Split(' ');
                mapSegments.Add(new MapSegments(long.Parse(values[1]), long.Parse(values[0]), long.Parse(values[2])));
            }

            maps.Add(new Map(mapSegments));
        }

        return maps;
    }
}
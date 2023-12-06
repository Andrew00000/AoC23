internal class Mapper
{
    private readonly IEnumerable<long> seeds;
    private readonly IEnumerable<Map> mappings;

    public Mapper(IEnumerable<long> seeds, IEnumerable<Map> mappings)
    {
        this.seeds = seeds;
        this.mappings = mappings;
    }

    public IEnumerable<long> MapSeedsToLocations() 
    {
        var locations = new List<long>();   

        foreach (var seed in seeds)
        {
            var location = mappings.Aggregate(seed, (current, map) => map.GetMappedPoint(current));

            locations.Add(location);
        }

        return locations;
    }

    public IEnumerable<SeedRange> MapAndSplitSeedRanges(IEnumerable<SeedRange> seedRanges)
    {
        var splitRanges = new HashSet<SeedRange>(seedRanges);

        foreach (var map in mappings)
        {
            foreach (var seed in splitRanges)
            {
                splitRanges.Remove(seed);
                splitRanges = splitRanges.Concat(map.SplitRanges(seed)).ToHashSet();
            }

            foreach (var seed in splitRanges)
            {
                seed.RemapSeedTo(map.GetMappedPoint(seed.SeedStart));
            }
        }

        return splitRanges;
    }
}
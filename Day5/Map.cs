public class Map
{
    private readonly IEnumerable<MapSegments> mapSegments;

    public Map(IEnumerable<MapSegments> mapSegments)
    {
        this.mapSegments = mapSegments;
    }

    public long GetMappedPoint(long toMap)
        => mapSegments.Any(x => x.IsPointInMapSegment(toMap))
                ? mapSegments.First(x => x.IsPointInMapSegment(toMap)).MapPoint(toMap)
                : toMap;

    public IEnumerable<SeedRange> SplitRanges(SeedRange toSplit)
    {
        var seedRanges = new HashSet<SeedRange> { toSplit };

        foreach(var segment in mapSegments)
        {
            var newSeedRanges = new HashSet<SeedRange>();

            foreach(var seedRange in seedRanges)
            {
                var splitted = segment.SplitSeedRange(seedRange);
                newSeedRanges = newSeedRanges.Concat(splitted.Where(x => x.Range != 0)).ToHashSet();
            }

            seedRanges = newSeedRanges;
        }

        return seedRanges;
    }
}
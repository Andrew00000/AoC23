public class MapSegments
{
    private readonly long sourceStart;
    private readonly long destinationStart;
    private readonly long range;

    public MapSegments(long sourceStart, long destinationStart, long range)
    {
        this.sourceStart = sourceStart;
        this.destinationStart = destinationStart;
        this.range = range;
    }
    public long MapPoint(long pointToMap)
        => destinationStart + (pointToMap - sourceStart);

    public bool IsPointInMapSegment(long point)
        => (sourceStart <= point) 
        && (point < sourceStart + range);

    public bool IsOverlapedByRange(SeedRange seedRange)
        => IsOverlapedByRange(seedRange) 
           || IsOverlapingRangeFromLeft(seedRange) 
           || IsOverlapingRangeFromRight(seedRange);

    public IEnumerable<SeedRange> SplitSeedRange(SeedRange original)
    {
        var split= new List<SeedRange>();

        if (IsIncludingRange(original))
        {
            split.Add(original);
        }
        else if (IsIncludedInRange(original))
        {
            split.Add(new SeedRange(original.SeedStart, sourceStart - original.SeedStart));
            split.Add(new SeedRange(sourceStart, range));
            split.Add(new SeedRange(sourceStart + range, (original.SeedStart + original.Range) - (sourceStart + range)));
        }
        else if(IsOverlapingRangeFromRight(original))
        {
            split.Add(new SeedRange(original.SeedStart, sourceStart - original.SeedStart));
            split.Add(new SeedRange(sourceStart, (original.SeedStart + original.Range) - sourceStart));
        }
        else if(IsOverlapingRangeFromLeft(original))
        {
            split.Add(new SeedRange(original.SeedStart, (sourceStart + range) - original.SeedStart));
            split.Add(new SeedRange(sourceStart + range, (original.SeedStart + original.Range) - (sourceStart + range)));
        }
        else
        {
            split.Add(original);
        }

        return split;
    }

    private bool IsIncludingRange(SeedRange seedRange)
        => (sourceStart <= seedRange.SeedStart) 
        && (seedRange.SeedStart + seedRange.Range <= sourceStart + range);
    private bool IsIncludedInRange(SeedRange seedRange)
        => (seedRange.SeedStart <= sourceStart) 
        && (sourceStart + range <= seedRange.SeedStart + seedRange.Range);
    
    private bool IsOverlapingRangeFromRight(SeedRange seedRange)
        => (seedRange.SeedStart <= sourceStart)
        && (sourceStart <= seedRange.SeedStart + seedRange.Range)
        && (seedRange.SeedStart + seedRange.Range < sourceStart + range);
    
    private bool IsOverlapingRangeFromLeft(SeedRange seedRange)
        => (sourceStart < seedRange.SeedStart)
        && (seedRange.SeedStart <= sourceStart + range)
        && (sourceStart + range <= seedRange.SeedStart + seedRange.Range);

}
public class SeedRange
{
    public long SeedStart { get; private  set; }
    public long Range { get; init; }

    public SeedRange(long seedStart, long range)
    {
        SeedStart = seedStart;
        Range = range;
    }

    public void RemapSeedTo(long seed)
        => SeedStart = seed; 

    public override int GetHashCode()
    {
        return SeedStart.GetHashCode() ^ Range.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }

        SeedRange other = (SeedRange)obj;
        return SeedStart == other.SeedStart && Range == other.Range;
    }
}
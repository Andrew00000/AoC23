public class Race
{
    private readonly long time;
    private readonly long record;

    public Race(long time, long record)
    {
        this.time = time;
        this.record = record;
    }

    public long GetNumberOfPossibleRecordBreaks()
    {
        var notBreaking = 0L;

        var attempt = notBreaking * (time - notBreaking);
        while (attempt <= record)
        {
            notBreaking++;
            attempt = notBreaking * (time - notBreaking);
        }

        return time - 2L * notBreaking + 1;
    }
}
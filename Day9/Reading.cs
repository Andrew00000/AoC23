public class Reading
{
    private IEnumerable<IEnumerable<long>> sequences;

    public Reading(IEnumerable<long> readings)
    {
        sequences = CountDifferences(readings);
    }

    private IEnumerable<IEnumerable<long>> CountDifferences(IEnumerable<long> readings)
    {
        var differences = new List<IEnumerable<long>>
        {
            readings
        };

        while (differences.Last().Sum() != 0)
        {
            differences.Add(differences.Last().Zip(differences.Last().Skip(1), (current, next) => next - current));
        }

        return differences;
    }

    public long ExtrapolateForwards()
        => sequences.Reverse().Aggregate(0L, (acc, x) => x.Last() + acc);

    public long ExtrapolateBackwards()
        => sequences.Reverse().Aggregate(0L, (acc, x) => x.First() - acc);
}
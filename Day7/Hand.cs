public class Hand
{
    private readonly IEnumerable<int> values;
    private readonly Strength strength;
    private readonly int bid;

    public Hand(IEnumerable<int> values, Strength strength, int bid)
    {
        this.values = values;
        this.strength = strength;
        this.bid = bid;
    }

    public int GetWinning(int rank)
        => rank * bid;

    public bool IsStrongerThan(Hand comparedTo)
    {
        if (strength > comparedTo.strength)
        {
            return true;
        }
        else if (strength < comparedTo.strength)
        {
            return false;
        }
        else
        {
            return HasStrongerValueThan(comparedTo);
        }
    }

    private bool HasStrongerValueThan(Hand comparedTo)
    {
        var values = this.values.ToArray();
        var comparedToValues = comparedTo.values.ToArray();

        for (var i = 0; i < values.Length; i++)
        {
            if (values[i] > comparedToValues[i])
            {
                return true;
            }
            else if (values[i] < comparedToValues[i])
            {
                return false;
            }
        }

        return false;
    }
}
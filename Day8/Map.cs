public class Map
{
    private readonly IEnumerable<int> pattern;
    private readonly Dictionary<string, string[]> steps;

    public Map(IEnumerable<int> pattern, Dictionary<string, string[]> steps)
    {
        this.pattern = pattern;
        this.steps = steps;
    }

    public int CountStepsBetween(string start, string finish)
    {
        var counter = 0;
        var current = start;

        while(current != finish)
        {
            foreach (var line in pattern)
            {
                current = steps[current][line];
                counter++;

                if (current == finish)
                {
                    return counter;
                }
            }
        }

        return counter;
    }

    private (long, long) CountStepsBetweenEndings(string start, char finish)
    {
        var counter = 0L;
        var current = start;

        var offset = 0L;
        var past = new HashSet<string>();

        var isAfterOffset = false;
        
        while (!past.Contains(current))
        {
            foreach (var line in pattern)
            {
                current = steps[current][line];
                
                counter++;


                if ((current.Last() == finish) || isAfterOffset)
                {
                    isAfterOffset= true;

                    if (offset == 0L)
                    {
                        offset = counter;
                    }

                    past.Add(current);

                    current = steps[current][line];

                    counter++;

                    if (past.Contains(current))
                    {
                        return (offset, counter - offset);
                    }
                }
            }
        }

        return (offset, counter - offset);
    }

    public IEnumerable<(long, long)> GetCounts()
    {
        var finish = 'Z';
        var counts = steps.Keys.Where(x => x.Last() == 'A');

        var numbers = new List<(long, long)>();

        foreach (var count in counts)
        {
            numbers.Add(CountStepsBetweenEndings(count, finish));
        }

        return numbers;
    }
}
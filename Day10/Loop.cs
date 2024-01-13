public class Loop
{
    private (int y, int x) start;
    private List<((int y, int x) position, char sign)> loop;

    public Loop((int y, int x) start, List<((int y, int x) position, char sign)> loop)
    {
        this.start = start;
        this.loop = loop;
    }

    public int GetFurthestPointFromStart()
        => (int)Math.Ceiling((decimal)loop.Count / 2);

    public int GetEnclosed()
    {
        var visitedMixed = loop.ToHashSet();

        var visited = visitedMixed.Where(a => a.sign != '-')
                                  .OrderBy(a => a.position.y)
                                  .GroupBy(a => a.position.y)
                                  .Select(a => a.OrderBy(b => b.position.x))
                                  .Skip(1).SkipLast(1);

        var enclosed = 0;

        foreach (var line in visited)
        {
            ((int y, int x) position, char sign) first;
            ((int y, int x) position, char sign) second;

            var values = line.ToArray();

            for (var i = 0; i < values.Length; i++)
            {
                first = values[i];
                i++;

                if (i < values.Length)
                {
                    second = values[i];

                    enclosed += second.position.x - first.position.x - 1;

                    if ((second.sign == 'F') || (second.sign == 'L'))
                    {
                        i++;
                    }
                }
            }
        }

        return enclosed;
    }
}
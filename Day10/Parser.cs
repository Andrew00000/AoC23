public class Parser
{
    public Loop Parse(string[] input)
    {
        var start = GetStart(input);

        (var firstSteps, var startSign) = GetFirstSteps(input, start);
        var visited = new HashSet<(int y, int x)> { start };
        var loop = new List<((int y, int x) position, char sign)> { (start, startSign) };


        var previous = start;
        var current = firstSteps.First();

        while (!visited.Contains(current))
        {
            loop.Add((current, input[current.y][current.x]));
            visited.Add(firstSteps.First());
    
            var temp = GetNextStep(previous, current, input);
            previous = current;
            current = temp;
        }

        return new Loop(start, loop);        
    }

    private (int y, int x) GetNextStep((int y, int x) previous, (int y, int x) current, string[] input)
        => input[current.y][current.x] switch
        {
            '|' => previous.y == current.y - 1 ? (current.y + 1, current.x) : (current.y - 1, current.x),
            '-' => previous.x == current.x - 1 ? (current.y, current.x + 1) : (current.y, current.x - 1),
            'L' => previous.y == current.y ? (current.y - 1, current.x) : (current.y, current.x + 1),
            'J' => previous.y == current.y ? (current.y - 1, current.x) : (current.y, current.x - 1),
            '7' => previous.y == current.y ? (current.y + 1, current.x) : (current.y, current.x - 1),
            'F' => previous.y == current.y ? (current.y + 1, current.x) : (current.y, current.x + 1),
            _ => throw new ArgumentOutOfRangeException()
        };
    

    private (IEnumerable<(int y, int x)>, char startSign) GetFirstSteps(string[] input, (int y, int x) start)
    {
        var connections = new List<(int y, int x)>();

        var neighbour = 0;

        if ( (0 <= start.y - 1) && ((input[start.y - 1][start.x] == '|')
                                    || (input[start.y - 1][start.x] == '7')
                                    || (input[start.y - 1][start.x] == 'F')))
        {
            connections.Add((start.y - 1, start.x));
            neighbour += 1;
        }

        if ((start.y + 1 < input.Length) && ((input[start.y + 1][start.x] == '|')
                                              || (input[start.y + 1][start.x] == 'L')
                                              || (input[start.y + 1][start.x] == 'J')))
        {
            connections.Add((start.y + 1, start.x));
            neighbour += 10;
        }

        if ((0 <= start.x - 1) && ((input[start.y][start.x - 1] == '-')
                                    || (input[start.y][start.x - 1] == 'L')
                                    || (input[start.y][start.x - 1] == 'F')))
        {
            connections.Add((start.y, start.x - 1));
            neighbour += 100;
        }

        if ((start.x + 1 < input[0].Length) && ((input[start.y][start.x + 1] == '-')
                                                || (input[start.y][start.x + 1] == '7')
                                                || (input[start.y][start.x + 1] == 'J')))
        {
            connections.Add((start.y, start.x + 1));
            neighbour += 1000;
        }

        return neighbour switch
        {
            11 => (connections, '|'),
            101 => (connections, 'J'),
            1001 => (connections, 'L'),
            110 => (connections, '7'),
            1010 => (connections, 'F'),
            1100 => (connections, '-'),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private (int y, int x) GetStart(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] == 'S')
                {
                    return (i, j);
                }    
            }
        }

        throw new ArgumentOutOfRangeException();
    }
}
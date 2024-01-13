public class Parser
{
    public Map Parse(string input)
    {
        var patternRaw = input.Split(Environment.NewLine + Environment.NewLine)[0];
        var stepsRaw = input.Split(Environment.NewLine + Environment.NewLine)[1].Split(Environment.NewLine);

        var pattern = patternRaw.Select(x => x == 'L' ? 0 : 1);

        var steps = new Dictionary<string, string[]>();

        foreach (var step in stepsRaw)
        {
            var name = step.Split(" = ")[0];
            var nextSteps = step.Split(" = ")[1].TrimStart('(').TrimEnd(')').Split(", ");

            steps[name] = nextSteps;
        }

        return new Map(pattern, steps);
    }
}
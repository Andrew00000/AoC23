var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 379811651;
var solution2 = 39477886;

//Problem One: https://adventofcode.com/2023/day/5


var splitInput = input.Split(Environment.NewLine + Environment.NewLine);
var seeds = splitInput[0].Split(": ")[1].Split(' ').Select(long.Parse);
var mapsRaw = splitInput[1..];

var parser = new Parser();
var mappings = parser.Parse(mapsRaw);

var mapper = new Mapper(seeds, mappings);

var locations = mapper.MapSeedsToLocations();

var minLocation = locations.Min();

var problemOneResult = solution1 == minLocation ? $"Yes the answer is {minLocation}"
                                                : $"No the answer isnt {minLocation}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/5#part2

var seedsAndRanges = new List<SeedRange>();

var temp = 0L;
var index = 0;

foreach (var line in seeds)
{
    if (index % 2 == 0)
    {
        temp= line;
        index++;
    }
    else
    {
        seedsAndRanges.Add(new SeedRange(temp, line));
        index++;
    }
}

var seedRanges = mapper.MapAndSplitSeedRanges(seedsAndRanges);

var minLocation2 = seedRanges.Min(x => x.SeedStart);

var problemTwoResult = solution2 == minLocation2 ? $"Yes the answer is {minLocation2}"
                                                 : $"No the answer isnt {minLocation2}";

Console.WriteLine(problemTwoResult);
using Day3;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 531932;
var solution2 = 73646890;

//Problem One: https://adventofcode.com/2023/day/3

var parser = new Parser();

var parts = parser.ParseParts(input);

var sum1 = parts.Where(x => !x.IsMissing).Sum(x => x.Number);

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/3#part2

var gearRatios = parser.ParseGears(input);
var sum2 = gearRatios.Sum();

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);

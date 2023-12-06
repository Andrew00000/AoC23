var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 2756160;
var solution2 = 34788142;

//Problem One: https://adventofcode.com/2023/day/6

var parser = new Parser();

var races = parser.Parse(input).Select(x => x.GetNumberOfPossibleRecordBreaks());

var answer1 = races.Aggregate(1L, (acc, x) => x * acc);

var problemOneResult = solution1 == answer1 ? $"Yes the answer is {answer1}"
                                            : $"No the answer isnt {answer1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/6#part2

var race = parser.ParseToOneRace(input);

var answer2 = race.GetNumberOfPossibleRecordBreaks();

var problemTwoResult = solution2 == answer2 ? $"Yes the answer is {answer2}"
                                            : $"No the answer isnt {answer2}";

Console.WriteLine(problemTwoResult);
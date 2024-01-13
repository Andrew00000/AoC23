var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 23147;
var solution2 = 0;

//Problem One: https://adventofcode.com/2023/day/8

var parser = new Parser();

var map = parser.Parse(input);
var start = "AAA";
var finish = "ZZZ";

var stepsCount = map.CountStepsBetween(start, finish);

var problemOneResult = solution1 == stepsCount ? $"Yes the answer is {stepsCount}"
                                         : $"No the answer isnt {stepsCount}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/8#part2

var startEnd = 'A';
var finishEnd = 'Z';

var stepsCount2 = map.GetCounts();

//var problemTwoResult = solution2 == stepsCount2 ? $"Yes the answer is {stepsCount2}"
//                                         : $"No the answer isnt {stepsCount2}";

//Console.WriteLine(problemTwoResult);
Console.WriteLine();
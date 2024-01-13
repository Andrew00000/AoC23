var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 1868368343;
var solution2 = 1022;

//Problem One: https://adventofcode.com/2023/day/9

var parser = new Parser();

var readings = parser.Parse(input);
var sum1 = readings.Sum(x => x.ExtrapolateForwards());

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/9#part2

var asd = readings.Select(x => x.ExtrapolateBackwards());
var sum2 = readings.Sum(x => x.ExtrapolateBackwards());

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);

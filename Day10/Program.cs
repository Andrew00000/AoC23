var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\miin.txt")!;
var solution1 = 6599;
var solution2 = 6284877;

//Problem One: https://adventofcode.com/2023/day/10

var parser = new Parser();

var loop = parser.Parse(input);

var sum1 = loop.GetFurthestPointFromStart();

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/10#part2

var sum2 = loop.GetEnclosed();

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);
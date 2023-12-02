using Day1;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 53334;
var solution2 = 52834;

//Problem One: https://adventofcode.com/2023/day/1

var digitsOnlyPolicy = new FindDigitsOnlyPolicy();
var parser = new Parser(digitsOnlyPolicy);

var sum1 = input.Select(parser.GetNumber).Sum();

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/2

var digitsAndDigitNamesPolicy = new FindDigitsAndDigitNamesPolicy();
var parser2 = new Parser(digitsAndDigitNamesPolicy);

var sum2 = input.Select(parser2.GetNumber).Sum();

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);


using Day2;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 2156;
var solution2 = 66909;

//Problem One: https://adventofcode.com/2023/day/2

var parser = new Parser();

var games = parser.Parse(input);
var maxReveal = new Reveal(13, 14, 12);
var sum1 = games.Where(x => x.IsValidGame(maxReveal)).Sum(x => x.Id);

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/2#part2

var sum2 = games.Sum(x => x.GetMinimumPower());

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);

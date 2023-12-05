var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 26443;
var solution2 = 6284877;

//Problem One: https://adventofcode.com/2023/day/4

var parser = new Parser();

var cards = parser.Parse(input);
var sum1 = cards.Sum(x => x.GetWinnings());

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/4#part2

var deck = new Deck();

var cardsFinal = deck.CountCardsAfterWinning(cards);
var sum2 = cardsFinal.Sum();

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);


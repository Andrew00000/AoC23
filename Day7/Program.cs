using Day7;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}\in.txt")!;
var solution1 = 250058342;
var solution2 = 250506580;

//Problem One: https://adventofcode.com/2023/day/7

var parser = new Parser();

var hands = parser.Parse(input);

var orderedHands = hands.OrderBy(hand => hand, new HandStrengthComparer());

var rank = 1;
var sum1 = 0L;

foreach (var hand in orderedHands)
{
    sum1 += hand.GetWinning(rank);
    rank++;
}

var problemOneResult = solution1 == sum1 ? $"Yes the answer is {sum1}"
                                         : $"No the answer isnt {sum1}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2023/day/7#part2

var hands2 = parser.ParseWithJokers(input);

var orderedHands2 = hands2.OrderBy(hand => hand, new HandStrengthComparer());

rank = 1;
var sum2 = 0L;

foreach (var hand in orderedHands2)
{
    sum2 += hand.GetWinning(rank);
    rank++;
}

var problemTwoResult = solution2 == sum2 ? $"Yes the answer is {sum2}"
                                         : $"No the answer isnt {sum2}";

Console.WriteLine(problemTwoResult);
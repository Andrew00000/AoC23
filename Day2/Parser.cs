using System.Text.RegularExpressions;

namespace Day2
{
    public class Parser
    {
        public Game[] Parse(string[] input)
        {
            var greenPattern = $@"\b(\d+)\s+green\b";
            var bluePattern = $@"\b(\d+)\s+blue\b";
            var redPattern = $@"\b(\d+)\s+red\b";

            var greenRegex = new Regex(greenPattern);
            var blueRegex = new Regex(bluePattern);
            var redRegex = new Regex(redPattern);

            var games = new Game[input.Length];

            for (var i = 0; i < input.Length; i++) 
            {
                var rawReveals = input[i].Split(": ")[1].Split("; ");
                var reveals = new Reveal[rawReveals.Length];

                for (var j = 0; j < rawReveals.Length; j++)
                {
                    var green = 0;
                    var greenMatch = greenRegex.Match(rawReveals[j]);

                    if (greenMatch.Success)
                    {
                        green = int.Parse(greenMatch.Value.Split(" ")[0]);
                    }

                    var blue = 0;
                    var blueMatch = blueRegex.Match(rawReveals[j]);

                    if (blueMatch.Success)
                    {
                        blue = int.Parse(blueMatch.Value.Split(" ")[0]);
                    }

                    var red = 0;
                    var redMatch = redRegex.Match(rawReveals[j]);

                    if (redMatch.Success)
                    {
                        red = int.Parse(redMatch.Value.Split(" ")[0]);
                    }

                    reveals[j] = new Reveal(green, blue, red);
                }

                games[i] = new Game(i + 1, reveals);
            }

            return games;
        }
    }
}

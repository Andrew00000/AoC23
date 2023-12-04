using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day3
{
    public class Parser
    {
        private int rowLength = 0;
        private int columnLength = 0;
        private string[] input = Array.Empty<string>();
        private const char GEAR = '*';

        public IEnumerable<Part> ParseParts(string[] inputTable)
        {
            input = inputTable;
            columnLength = input.Length - 1;
            rowLength = input[0].Length - 1;
            var parts = new List<Part>();

            for (var i = 0; i <= columnLength; i++)
            {
                for (var j = 0; j <= rowLength; j++)
                {
                    if (char.IsDigit(input[i][j]))
                    {
                        var neighbours = new HashSet<char>();
                        var number = "";
                        var offset = 0;
                        
                        neighbours = AddEndNeighbours(i, j - 1, neighbours);

                        while ((j + offset <= rowLength) && (char.IsDigit(input[i][j + offset])))
                        {
                            number += input[i][j + offset];
                            neighbours = AddUpDownNeighbours(neighbours, i, j + offset);
                            offset++;
                        }

                        neighbours = AddEndNeighbours(i, j + offset, neighbours);

                        var partNumber = int.Parse(number);

                        parts.Add(new Part(partNumber, neighbours));

                        j += offset;
                    }

                }
            }

            return parts;
        }

        private HashSet<char> AddEndNeighbours(int i, int j, HashSet<char> neighbours)
        {
            if (IsWithinBounds(i, j))
            {
                neighbours.Add(input[i][j]);
                neighbours = AddUpDownNeighbours(neighbours, i, j);
            }

            return neighbours;
        }

        public IEnumerable<long> ParseGears(string[] inputTable)
        {
            input = inputTable;
            columnLength = input.Length - 1;
            rowLength = input[0].Length - 1;
            var gearRatios = new List<long>();

            for (var i = 0; i <= columnLength; i++)
            {
                for (var j = 0; j <= rowLength; j++)
                {
                    var isGear = input[i][j] == GEAR;
;
                    if (isGear)
                    {
                        var neighbourNumbers = new List<long>();

                        GetNumbersFromSide(i, j, (x) => --x, neighbourNumbers, GetNumberLeft);

                        GetNumbersFromSide(i, j, (x) => ++x, neighbourNumbers, GetNumberRight);

                        if (neighbourNumbers.Count == 2)
                        {
                            gearRatios.Add(neighbourNumbers.Aggregate((acc, x) => 1L * acc * x));
                        }
                    }
                }
            }

            return gearRatios;
        }

        private void GetNumbersFromSide(int i, int j, Func<int, int> increment, List<long> neighbourNumbers, Func<int, int, long> GetNumberDirection)
        {
            GetNeighbourNumber(i, increment(j), neighbourNumbers, GetNumberDirection);

            GetNumbersFromSideUpDown(increment(i), j, neighbourNumbers);
        }

        private void GetNumbersFromSideUpDown(int i, int j, List<long> neighbourNumbers)
        {
            if (IsWithinBounds(i, j) && !char.IsDigit(input[i][j]))
            {
                GetNeighbourNumber(i, j - 1, neighbourNumbers, GetNumberLeft);

                GetNeighbourNumber(i, j + 1, neighbourNumbers, GetNumberRight);
            }
            else if (IsWithinBounds(i, j) && char.IsDigit(input[i][j]))
            {
                var index = 0;
                while (IsWithinBounds(i, j + index + 1) && char.IsDigit(input[i][j + index + 1]))
                {
                    index++;
                }

                neighbourNumbers.Add(GetNumberLeft(i, j + index));
            }
        }

        private void GetNeighbourNumber(int i, int j, List<long> neighbourNumbers, Func<int, int, long> getNumberFrom)
        {
            if (IsWithinBounds(i, j) && char.IsDigit(input[i][j]))
            {
                neighbourNumbers.Add(getNumberFrom(i, j));
            }
        }

        private long GetNumberFromDirection(int y, int x, Func<int, int> increment, Func<char, string, string> digitCollector)
        {
            var number = "";
            while (IsWithinRow(x) && (char.IsDigit(input[y][x])))
            {
                number = digitCollector(input[y][x], number);
                x = increment(x);
            }

            return long.Parse(number);
        }
        private long GetNumberLeft(int y, int x)
            => GetNumberFromDirection(y, x, (a) => --a, (b, c) => b + c);

        private long GetNumberRight(int y, int x)
            => GetNumberFromDirection(y, x, (a) => ++a, (b, c) => c + b);
        private HashSet<char> AddUpDownNeighbours(HashSet<char> neighbours, int y, int x)
        {
            if (IsWithinBounds(y - 1, x))
            {
                neighbours.Add(input[y - 1][x]);
            }

            if (IsWithinBounds(y + 1, x))
            {
                neighbours.Add(input[y + 1][x]);
            }

            return neighbours;
        }

        private bool IsWithinRow(int x)
            => 0 <= x
            && x <= rowLength;
        private bool IsWithinColumn(int y)
            => 0 <= y
            && y <= columnLength;
        private bool IsWithinBounds(int y, int x)
            => IsWithinColumn(y)
            && IsWithinRow(x);
    }
}

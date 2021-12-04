using aoc2021.Models;

namespace aoc2021.Processors
{
    internal class Day4 : DayBase, IDayProcessor
    {
        public void Announce()
        {
            Console.WriteLine("Day 4");
        }

        public void Part1()
        {
            var input = LoadInput<string>("Day4.txt").ToArray();

            var calledNumers = input.First().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var cards = new List<BingoCard>();

            List<string> rows = new List<string>();

            for (var i = 2; i< input.Length; i++)
            {
                var row = input[i];

                if (string.IsNullOrWhiteSpace(row))
                {
                    // add the rows and the card
                    var card = new BingoCard(rows.ToArray());
                    cards.Add(card);
                    rows = new List<string>();
                    continue;
                }

                rows.Add(row);
            }
            
            cards.Add(new BingoCard(rows.ToArray()));

            var hasWinner = false;

            foreach (var number in calledNumers)
            {
                foreach (var card in cards)
                {
                    card.MarkNumber(number);
                    if (card.HasWon)
                    {
                        var value = number * card.UnmarkedSum;
                        Console.WriteLine($"Part 1 - {number} * {card.UnmarkedSum} = {value}");
                        hasWinner = true;
                        break;
                    }
                }

                if (hasWinner)
                {
                    break;
                }
            }
        }

        public void Part2()
        {
            
        }
    }
}

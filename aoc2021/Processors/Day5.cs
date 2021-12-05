using aoc2021.Models;

namespace aoc2021.Processors
{
    internal class Day5 : DayBase, IDayProcessor
    {
        public void Part1()
        {
            var input = LoadInput<string>("Day5.txt");
            var lines = input.Select(i => new VentLine(i))
                             .Where(i => i.IsStraight)
                             .ToArray();

            var intersections = new List<VentLine.Coord>();
            
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                for (var j = i + 1; j < lines.Length; j++)
                {
                    var otherLine = lines[j];

                    var routes1 = line.AllPoints;
                    var routes2 = otherLine.AllPoints;

                    var newPoints = routes1.Intersect(routes2);

                    foreach (var point in newPoints)
                    {
                        if (!intersections.Any(i => i.X == point.X && i.Y == point.Y))
                        {
                            intersections.Add(point);
                        }
                    }
                }
            }

            OutputResult(1, intersections.Count());
        }

        public void Part2()
        {

        }
    }
}

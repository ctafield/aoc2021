namespace aoc2021.Models
{
    internal class VentLine
    {
        public struct Coord
        {
            public int X { get; set; }

            public int Y { get; set; }
        }

        public Coord Start { get; set; }

        public Coord End { get; set; }

        public bool IsStraight
        {
            get
            {
                return Start.X == End.X || Start.Y == End.Y;
            }
        }

        public List<Coord> AllPoints
        {
            get
            {
                var allPoints = new List<Coord>();

                if (Start.Y == End.Y)
                {
                    // Horizontally
                    var start = Math.Min(Start.X, End.X);
                    var end = Math.Max(Start.X, End.X);

                    for (var x = start; x <= end; x++)
                    {
                        allPoints.Add(new Coord { Y = Start.Y, X = x });
                    }

                }
                else if (Start.X == End.X)
                {
                    // Vertically
                    var start = Math.Min(Start.Y, End.Y);
                    var end = Math.Max(Start.Y, End.Y);

                    for (var y = start; y <= end; y++)
                    {
                        allPoints.Add(new Coord { Y = y, X = Start.X });
                    }
                }

                return allPoints;
            }
        }

        public VentLine(string input)
        {
            var points = input.Split("->", StringSplitOptions.TrimEntries);

            var startPoints = points[0].Split(",");
            Start = new Coord
            {
                X = int.Parse(startPoints[0]),
                Y = int.Parse(startPoints[1]),
            };

            var endPoints = points[1].Split(",");
            End = new Coord
            {
                X = int.Parse(endPoints[0]),
                Y = int.Parse(endPoints[1]),
            };
        }
    }
}

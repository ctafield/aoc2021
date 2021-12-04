namespace aoc2021.Processors
{
    internal class Day2 : DayBase, IDayProcessor
    {
        public void Announce()
        {
            Console.WriteLine("Day 2");
        }

        public void Part1()
        {
            var input = LoadInput<string>("Day2.txt");

            var pos = new Position();

            foreach(var line in input)
            {
                var movement = new Day2Direction(line);
                pos.Apply(movement);
            }

            Console.WriteLine("Value = " + (pos.Horizontal * pos.Depth));
        }

        public void Part2()
        {
            var input = LoadInput<string>("Day2.txt");

            var pos = new Position2();

            foreach (var line in input)
            {
                var movement = new Day2Direction(line);
                pos.Apply(movement);
            }

            Console.WriteLine("Value = " + (pos.Horizontal * pos.Depth));
        }

        private class Position
        {
            public int Depth { get; set; } = 0;

            public int Horizontal { get; set; } = 0;

            public int Aim { get; set; } = 0;

            internal void Apply(Day2Direction movement)
            {
                switch(movement.Direction)
                {
                    case "forward":
                        Horizontal += movement.Value;
                        break;

                    case "up":
                        Depth -= movement.Value;
                        break;

                    case "down":
                        Depth += movement.Value;
                        break;
                }
            }
        }

        private class Position2
        {
            public int Depth { get; set; } = 0;

            public int Horizontal { get; set; } = 0;

            public int Aim { get; set; } = 0;

            internal void Apply(Day2Direction movement)
            {
                switch (movement.Direction)
                {
                    case "forward":
                        Horizontal += movement.Value;
                        Depth += (Aim * movement.Value);
                        break;

                    case "up":
                        Aim -= movement.Value;
                        break;

                    case "down":
                        Aim += movement.Value;
                        break;
                }
            }
        }

        private class Day2Direction
        {
            public Day2Direction(string val)
            {
                var split = val.Split(" ");
                Direction = split[0];
                Value = int.Parse(split[1]);
            }

            public string Direction { get; set; }

            public int Value { get; set; }
        }
    }
}

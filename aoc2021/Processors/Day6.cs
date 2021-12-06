namespace aoc2021.Processors
{
    internal class Day6 : DayBase, IDayProcessor
    {
        public const byte ResetSpawnDays = 6;
        public const byte DefaultChildSpawnDays = 8;

        public void Part1()
        {
            ProcessFish(1, 80);
        }

        public void Part2()
        {
            ProcessFish(2, 256);
        }

        private void ProcessFish(short partNumber, int days)
        {
            var dict = LoadInput<string>("Day6.txt")
                .First()
                .Split(",")
                .Select(x => Convert.ToInt16(x))
                .GroupBy(x => x)
                .Select(x => new
                {
                    x.Key,
                    Value = x.Count()
                })
                .ToDictionary(x => x.Key, x => x.Value);

            var fish = new long[9] {
                0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            foreach (var kvp in dict)
            {
                fish[kvp.Key] = kvp.Value;
            }

            for (var day = 0; day < days; day++)
            {
                var zero = fish[0];

                for (var j = 1; j <= 8; j++)
                {
                    fish[j - 1] = fish[j];
                }

                fish[DefaultChildSpawnDays] = zero;
                fish[ResetSpawnDays] += zero;
            }

            var fishCount = fish.Sum();

            OutputResult(partNumber, fishCount);
        }
    }
}

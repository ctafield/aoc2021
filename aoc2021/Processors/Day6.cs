using aoc2021.Models;

namespace aoc2021.Processors
{
    internal class Day6 : DayBase, IDayProcessor
    {
        public void Part1()
        {
            var fish = LoadInput<string>("Day6.txt")
                .ToArray()[0]
                .Split(",")
                .Select(x => new LanternFish(byte.Parse(x)))
                .ToArray();

            OutputDebug($"There are {fish.Count()} fish initially.");

            const int days = 80;

            for (var i = 0; i < days; i++)
            {
                foreach (var item in fish)
                {
                    item.ProcessDay();
                }
            }

            long fishCount = 0;

            foreach (var item in fish)
            {
                fishCount += item.CountFish();
            }

            OutputResult(1, fishCount);
        }

        public void Part2()
        {
            var fish = LoadInput<string>("Day6.txt")
                .ToArray()[0]
                .Split(",")
                .Select(x => new LanternFish(byte.Parse(x)))
                .ToArray();

            OutputDebug($"There are {fish.Count()} fish initially.");

            const int days = 256;

            for (var i = 0; i < days; i++)
            {
                foreach (var item in fish.AsParallel())
                {
                    item.ProcessDay();
                }
            }

            long fishCount = 0;

            foreach (var item in fish.AsParallel())
            {
                fishCount += item.CountFish();
            }

            OutputResult(2, fishCount);
        }
    }
}

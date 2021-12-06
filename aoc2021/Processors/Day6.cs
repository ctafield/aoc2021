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
            ProcessFish(1, 256);
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
                    Key = x.Key,
                    Value = x.LongCount()
                })
                .ToDictionary(x => x.Key, x => x.Value);

            for (var i = 0; i < days; i++)
            {
                var newDict = new Dictionary<short, long>();

                for (short j = 8; j >= 0; j--)
                {
                    if (dict.ContainsKey(j))
                    {
                        newDict.Add((short)(j - 1), dict[j]);
                    }
                }

                if (newDict.ContainsKey(-1))
                {
                    long spawn = 0;
                    if (newDict.ContainsKey(ResetSpawnDays))
                    {
                        spawn = newDict[ResetSpawnDays];
                    }

                    var old = spawn + newDict[-1];
                    newDict[ResetSpawnDays] = old;
                    newDict[DefaultChildSpawnDays] = newDict[-1];
                }

                dict = newDict;
            }

            var fishCount = dict.Where(x => x.Key >= 0).Sum(x => x.Value);

            OutputResult(partNumber, fishCount);
        }
    }
}

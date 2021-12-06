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
            var fish = LoadInput<string>("Day6.txt")
                .ToArray()[0]
                .Split(",")
                .Select(x => Convert.ToInt16(x))
                .ToList();

            OutputDebug($"There are {fish.Count()} fish initially.");

            var dict = new Dictionary<int, long>();

            for (var i = 0; i < 8; i++)
            {
                dict.Add(i, fish.Count(x => x == i));
            }
            
            for (var i = 0; i < days; i++)
            {
                var newDict = new Dictionary<int, long>()
                {
                    { 0, 0 },
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 4, 0 },
                    { 5, 0 },
                    { 6, 0 },
                    { 7, 0 },
                    { 8, 0 },
                };

                for (var j = 8; j >= 0; j--)
                {
                    if (dict.ContainsKey(j))
                    {
                        newDict[j - 1] = dict[j];
                    }
                }

                if (newDict[-1] > 0)
                {
                    var old = newDict[ResetSpawnDays] + newDict[-1];
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

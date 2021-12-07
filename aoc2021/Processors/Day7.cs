namespace aoc2021.Processors
{
    internal class Day7 : DayBase, IDayProcessor
    {
        public void Part1()
        {
            var crabs = LoadInput<string>("Day7.txt")
                .First()
                .Split(",")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            var min = crabs.Min();
            var max = crabs.Max();

            var vals = new Dictionary<int, int>();

            for (var i = min; i <= max; i++)
            {
                var sum = 0;

                foreach (var c in crabs)
                {
                    var ma = Math.Max(i, c);
                    var mi = Math.Min(i, c);
                    sum += ma - mi;
                }

                vals.Add(i, sum);
            }

            var least = vals.Min(x => x.Value);

            OutputResult(1, least);
        }

        public void Part2()
        {
            var crabs = LoadInput<string>("Day7.txt")
                .First()
                .Split(",")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            var min = crabs.Min();
            var max = crabs.Max();

            var vals = new Dictionary<int, int>();

            for (var i = min; i <= max; i++)
            {
                var sum = 0;

                foreach (var c in crabs)
                {
                    var ma = Math.Max(i, c);
                    var mi = Math.Min(i, c);

                    for (var j = mi; j < ma; j++)
                    {
                        sum += j - mi + 1;
                    }

                }

                vals.Add(i, sum);
            }

            var least = vals.OrderBy(x => x.Value).First().Value;

            OutputResult(2, least);
        }
    }
}

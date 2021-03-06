using aoc2021.Inputs;

namespace aoc2021.Processors
{
    internal class Day1 : DayBase, IDayProcessor
    { 
        public void Part1()
        {
            int increases = 0;
            var lastDepth = InputDay1.Input[0];

            foreach (var depth in InputDay1.Input)
            {
                if (depth > lastDepth) increases++;
                lastDepth = depth;
            }

            OutputResult(1, increases);
        }

        public void Part2()
        {
            int increases = 0;
            var lastSum = InputDay1.Input.Take(3).Sum();

            for (var index = 0; index < InputDay1.Input.Length - 2; index++)
            {
                Range range = new Range(index, index + 3);
                var thisSum = InputDay1.Input.Take(range).Sum();
                if (thisSum > lastSum) increases++;
                lastSum = thisSum;
            }

            OutputResult(2, increases);
        }
    }
}

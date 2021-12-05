using aoc2021;
using aoc2021.Processors;

class AOC2021
{
    public static int Main(string[] args)
    {
        var processors = new List<IDayProcessor>
        {
            new Day1(),
            new Day2(),
            new Day3(),
            new Day4(),
            new Day5(),
        };
     
        foreach(var processor in processors)
        {
            Console.WriteLine($"Running: {processor.GetType().Name}");
            processor.Part1();
            processor.Part2();
            Console.WriteLine();
        }

        return 0;
    }
}
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
        };
     
        foreach(var processor in processors)
        {
            processor.Announce();
            processor.Part1();
            processor.Part2();            
        }

        return 0;
    }
}
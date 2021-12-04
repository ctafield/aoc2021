namespace aoc2021.Processors
{
    internal class Day3 : DayBase, IDayProcessor
    {
        public void Announce()
        {
            Console.WriteLine("Day 3");
        }

        public void Part1()
        {
            var input = LoadInput<string>("Day3.txt").ToArray();

            // get length of the row
            var bits = input[0].Length;

            string gamma = "";
            string episilon = "";

            for (var i = 0; i < bits; i++)
            {
                var zeros = input.Count(x => x[i] == '0');
                var ones = input.Count(x => x[i] == '1');

                if (zeros > ones)
                {
                    gamma += "0";
                    episilon += "1";
                }
                else
                {
                    gamma += "1";
                    episilon += "0";
                }
            }

            var g = Convert.ToInt32(gamma, 2);
            var e = Convert.ToInt32(episilon, 2);

            Console.WriteLine($"Gamma = {g}");
            Console.WriteLine($"Episilon = {e}");
            Console.WriteLine($"Value = {g * e}");

        }

        public void Part2()
        {

        }
    }
}


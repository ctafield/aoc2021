namespace aoc2021.Processors
{
    internal class Day3 : DayBase, IDayProcessor
    {
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

            OutputResult(1, g * e);
        }

        public void Part2()
        {
            var input = LoadInput<string>("Day3.txt").ToArray();

            var validOxygen = new List<string>();
            validOxygen.AddRange(input);

            var validCo2 = new List<string>();
            validCo2.AddRange(input);

            var oxy = Process(validOxygen, true);
            var co2 = Process(validCo2, false);

            Console.WriteLine($"Oxygen = {oxy}");
            Console.WriteLine($"Co2 = {co2}");

            OutputResult(2, oxy * co2);
        }

        private static int Process(IList<string> values, bool keepMost)
        {
            // get length of the row
            var bits = values[0].Length;

            for (var i = 0; i < bits; i++)
            {
                if (values.Count == 1)
                {
                    break;
                }

                var zeros = values.Count(x => x[i] == '0');
                var ones = values.Count(x => x[i] == '1');

                if (zeros > ones)
                {
                    if (keepMost)
                    {
                        values = values.Where(x => x[i] == '0').ToList();
                    }
                    else
                    {
                        values = values.Where(x => x[i] == '1').ToList();
                    }
                }
                else
                {
                    if (keepMost)
                    {
                        values = values.Where(x => x[i] == '1').ToList();
                    }
                    else
                    {
                        values = values.Where(x => x[i] == '0').ToList();
                    }
                }
            }

            var val = Convert.ToInt32(values.First(), 2);
            return val;
        }
    }
}


using System.Text;

namespace aoc2021.Processors
{
    internal abstract class DayBase
    {
        protected void OutputResult(short part, string result)
        {
            SafeOutput($"Result for part {part} : {result}", ConsoleColor.Green);
        }

        protected void OutputResult(short part, int result)
        {
            OutputResult(part, result.ToString());
        }
        protected void OutputResult(short part, long result)
        {
            OutputResult(part, result.ToString());
        }

        protected void OutputDebug(string debug)
        {
            SafeOutput(debug, ConsoleColor.DarkGray);
        }

        private void SafeOutput(string value, ConsoleColor colour)
        {
            var oldColour = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            Console.WriteLine(value);
            Console.ForegroundColor = oldColour;
        }

        protected IEnumerable<T> LoadInput<T>(string fileName)
        {
            return File.ReadAllLines($"Inputs\\{fileName}").Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }

        protected IEnumerable<T> ParseInput<T>(IEnumerable<string> input, Func<string, T> factory)
        {
            var results = new List<T>();
            var result = new StringBuilder();

            foreach (var row in input)
            {
                if (!string.IsNullOrWhiteSpace(row))
                {
                    result.Append(row + " ");
                }
                else
                {
                    results.Add(factory(result.ToString()));
                    result = new StringBuilder();
                }
            }

            results.Add(factory(result.ToString()));

            return results;
        }
    }
}

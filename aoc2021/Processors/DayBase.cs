using System.Text;

namespace aoc2021.Processors
{
    internal abstract class DayBase
    {
        protected void OutputResult(short part, string result)
        {
            Console.WriteLine($"Result for part {part} : {result}");
        }

        protected void OutputResult(short part, int result)
        {
            OutputResult(part, result.ToString());  
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

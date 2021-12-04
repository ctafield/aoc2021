namespace aoc2021.Models
{
    internal class BingoCard
    {
        private class Number
        {
            public int Value { get; set; }

            public bool Marked { get; set; }

            public Number(int value)
            {
                Value = value;
                Marked = false;
            }
        }
       
        private List<List<Number>> Rows { get; set; }

        public BingoCard(string[] rows)
        {
            Rows = new List<List<Number>>();

            foreach(var row in rows)
            {
                var rawNumbers = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var numbers = new List<Number>();
                foreach (var rawNumber in rawNumbers)
                {
                    numbers.Add(new Number(int.Parse(rawNumber)));
                }
                
                Rows.Add(numbers);
            }                                   
        }

        public bool AlreadyWon = false;

        public bool HasWon
        {
            get
            {
                if (AlreadyWon)
                {
                    return true;
                }

                foreach (var row in Rows)
                {
                    if (row.All(x => x.Marked))
                        return true;
                }

                var width = Rows.First().Count();

                for (var i = 0; i < width; i++)
                {
                    if (Rows.Select(x => x[i]).All(x => x.Marked))
                    {                        
                        return true;
                    }
                }
                
                return false;
            }
        }

        internal void MarkNumber(int number)
        {
            foreach(var row in Rows)
            {
                foreach (var num in row)
                {
                    if (num.Value == number)
                    {
                        num.Marked = true;
                    }
                }
            }
        }

        public int UnmarkedSum
        {
            get
            {
                var sum = 0;
                foreach (var row in Rows)
                {
                    sum += row.Where(n => !n.Marked).Sum(n => n.Value);

                }
                return sum;
            }
        }
    }
}

namespace aoc2021.Models
{
    public class LanternFish
    {
        public const byte ResetSpawnDays = 6;
        public const byte DefaultChildSpawnDays = 8;

        public short SpawnDays { get; set; }

        public List<LanternFish> Children { get; set; }        

        public LanternFish(short spawnDays)
        {
            SpawnDays = spawnDays;
            Children = new List<LanternFish>();
        }

        public void ProcessDay()
        {
            foreach (var child in Children)
            {
                child.ProcessDay();
            }

            ProcessThisFish();
        }

        private void ProcessThisFish()
        {
            SpawnDays--;

            if (SpawnDays < 0)
            {
                var newFish = new LanternFish(DefaultChildSpawnDays);
                Children.Add(newFish);

                SpawnDays = ResetSpawnDays;
            }
        }

        public long CountFish()
        {
            long fish = 1; // this one

            foreach (var child in Children)
            {
                fish += child.CountFish();
            }

            return fish;
        }
    }
}
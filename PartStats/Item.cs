namespace PartStats
{
    internal class Item
    {
        public Item(string line)
        {
            line = line.Trim();
            var s = line.Split(',');
            if (s != null && s.Length == 2)
            {
                this.Name = s[0];
                if (uint.TryParse(s[1], out uint count))
                {
                    this.Count = count;
                }
                else
                {
                    throw new System.Exception($"Incorrect number in line: {line}");
                }
            }
            else
            {
                throw new System.Exception($"Incorrect line in file: {line}");
            }
        }

        public string Name
        {
            get; set;
        }

        public uint Count
        {
            get; set;
        }
    }
}
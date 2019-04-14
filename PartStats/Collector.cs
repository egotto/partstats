using System.Collections.Generic;

namespace PartStats
{
    public static class Collector
    {
        private static Dictionary<string, uint> result = new Dictionary<string, uint>();

        public static void AddItem(Item item)
        {
            item.Name = item.Name.ToLowerInvariant();
            if (result.ContainsKey(item.Name))
            {
                result[item.Name] += item.Count;
            }
            else
            {
                result.Add(item.Name, item.Count);
            }
        }

        public static void AddRangeItems(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                AddItem(item);
            }
        }

        public static Dictionary<string, uint> GetResult()
        {
            return result;
        }

        public static uint GetCountByName(string name)
        {
            if (result.ContainsKey(name.ToLowerInvariant()))
            {
                return result[name.ToLowerInvariant()];
            }
            else
            {
                return 0;
            }
        }

        public static void Clear()
        {
            result.Clear();
        }
    }
}
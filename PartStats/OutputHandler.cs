namespace PartStats
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    internal static class OutputHandler
    {
        private static readonly string fileName = "output.txt";

        internal static async Task WriteOutputFileAsync()
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (var item in Collector.GetResult())
                    {
                        tasks.Add(writer.WriteLineAsync($"{item.Key},{item.Value}"));
                    }

                    await Task.WhenAll(tasks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on writing output file: {ex.Message}");
            }
        }
    }
}
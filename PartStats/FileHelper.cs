namespace PartStats
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    internal static class FileHelper
    {
        internal static async Task ReadFileAsync(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        Collector.AddItem(new Item(await reader.ReadLineAsync()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in file: {path}. {ex.Message}");
            }
        }
    }
}
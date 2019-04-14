namespace PartStats.Workers.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    internal class HttpWorker : IWorker
    {
        private const string fileName = "sources.txt";

        public Task ProcessDataAsync(string path)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(new Uri(path), fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on getting source file: {ex.Message}");
            }

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    List<Task> tasks = new List<Task>();
                    while (!reader.EndOfStream)
                    {
                        tasks.Add(ProcessLineUrlAsync(reader.ReadLineAsync()));
                    }

                    return Task.WhenAll(tasks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on reading source file: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        private async Task ProcessLineUrlAsync(Task<string> task)
        {
            var tempFileName = DateTime.Now.Ticks.ToString() + ".txt";
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(await task, tempFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on getting data file: {ex.Message}");
                throw;
            }

            await FileHelper.ReadFileAsync(tempFileName);
            //File.Delete(tempFileName);
        }
    }
}
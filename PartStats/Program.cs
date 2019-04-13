namespace PartStats
{
    using PartStats.Workers.FileSystem;
    using PartStats.Workers.Http;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Task> list = new List<Task>();
            if (string.Equals(args[0].ToLowerInvariant(), "filesystem"))
            {
                for (uint i = 1; i < args.Length; i++)
                {
                    var worker = new FileSystemWorker();
                    list.Add(worker.ProcessDataAsync(args[i]));
                }
            }
            else if (string.Equals(args[0].ToLowerInvariant(), "http"))
            {
                for (uint i = 1; i < args.Length; i++)
                {
                    var worker = new HttpWorker();
                    list.Add(worker.ProcessDataAsync(args[i]));
                }
            }
            else
            {
                Console.WriteLine("Incorrect \"input_mode\". Please check: filesystem or http.");
                Console.ReadKey();
                return;
            }

            HandleResult(list);
            Console.WriteLine("Work is done. Check output file: output.txt");
            Console.WriteLine("Press any key for close");
            Console.ReadKey();
        }

        private static async void HandleResult(IList<Task> tasks)
        {
            await Task.WhenAll(tasks);
            await OutputHandler.WriteOutputFileAsync();
        }
    }
}
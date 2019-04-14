namespace PartStats.Workers.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    internal class FileSystemWorker : IWorker
    {
        public Task ProcessDataAsync(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Directory - {path}, is not exists");
                return Task.CompletedTask;
            }

            var directories = Directory.GetDirectories(path);
            if (directories != null && directories.Length > 0)
            {
                foreach (var dir in directories)
                {
                    ProcessDataAsync(dir);
                }
            }

            var files = Directory.GetFiles(path);
            if (files != null && files.Length > 0)
            {
                List<Task> tasks = new List<Task>();
                foreach (var file in files)
                {
                    tasks.Add(FileHelper.ReadFileAsync(file));
                }

                return Task.WhenAll(tasks);
            }

            return Task.CompletedTask;
        }
    }
}
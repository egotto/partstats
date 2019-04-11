using System;

namespace PartStats
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            if(string.Equals(args[0].ToLowerInvariant(), "filesystem"))
            {
                for(uint i = 1; i < args.Length; i++)
                {
                    var worker = new FileSystemWorker();
                    var result = await worker.ProcessDataAsync(args[i]);
                }
            }
        }
    }
}

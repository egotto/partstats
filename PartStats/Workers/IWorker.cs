namespace PartStats.Workers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IWorker
    {
        Task ProcessDataAsync(string path);
    }
}
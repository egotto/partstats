namespace PartStats
{
    using System.Threading.Tasks;

    internal interface IWorker
    {
        Task<string> ProcessDataAsync(string path);
    }
}
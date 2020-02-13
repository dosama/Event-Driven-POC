using System.Threading.Tasks;

namespace CarService.Repositories.MessageLogs
{
    public interface IMessageLogsRepository
    {
        Task Log(Data.MessageLogs logData);
        long GetLastOffset();

    }
}

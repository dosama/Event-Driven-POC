using System.Threading.Tasks;

namespace FlightService.Repositories.MessageLogs
{
    public interface IMessageLogsRepository
    {
        Task Log(Data.MessageLogs logData);
        long GetLastOffset();



    }
}

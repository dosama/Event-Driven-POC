using System.Threading.Tasks;

namespace OrderServiceApi.Repositories.MessageLogs
{
    public interface IMessageLogsRepository
    {
        Task Log(Data.MessageLogs logData);
        long GetLastOffset();

    }
}

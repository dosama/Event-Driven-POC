using System.Threading.Tasks;

namespace HotelService.Repositories.MessageLogs
{
    public interface IMessageLogsRepository
    {
        Task Log(Data.MessageLogs logData);
        long GetLastOffset();


    }
}

using System.Linq;
using System.Threading.Tasks;
using FlightService.Data;

namespace FlightService.Repositories.MessageLogs
{
    public class MessageLogsRepository : Repository<Data.MessageLogs>, IMessageLogsRepository
    {
        public MessageLogsRepository(FlightContext context) : base(context)
        {

        }

        public FlightContext OrderContext => Context as FlightContext;

        public async Task Log(Data.MessageLogs logData)
        {
            OrderContext.Add(logData);
            OrderContext.SaveChanges();
        }

        public long GetLastOffset()
        {
            return OrderContext.MessageLogs.LastOrDefault().Offset.GetValueOrDefault();

        }
    }
}

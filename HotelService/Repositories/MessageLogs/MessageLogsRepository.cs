using System.Linq;
using System.Threading.Tasks;
using HotelService.Data;

namespace HotelService.Repositories.MessageLogs
{
    public class MessageLogsRepository : Repository<Data.MessageLogs>, IMessageLogsRepository
    {
        public MessageLogsRepository(HotelContext context) : base(context)
        {

        }

        public HotelContext OrderContext => Context as HotelContext;

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

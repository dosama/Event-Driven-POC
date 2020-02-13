using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderServiceApi.Data;

namespace OrderServiceApi.Repositories.MessageLogs
{
    public class MessageLogsRepository : Repository<Data.MessageLogs>, IMessageLogsRepository
    {
        public MessageLogsRepository(OrderContext context) : base(context)
        {

        }

        public OrderContext OrderContext => Context as OrderContext;

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

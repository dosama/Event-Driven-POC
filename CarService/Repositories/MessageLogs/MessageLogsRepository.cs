using System;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data;

namespace CarService.Repositories.MessageLogs
{
    public class MessageLogsRepository : Repository<Data.MessageLogs>, IMessageLogsRepository
    {
        public MessageLogsRepository(CarContext context) : base(context)
        {

        }

        public CarContext CarContext => Context as CarContext;

        public async Task Log(Data.MessageLogs logData)
        {

            CarContext.Add(logData);
            CarContext.SaveChanges();
            
          
        }

        public long GetLastOffset()
        {
            return CarContext.MessageLogs.LastOrDefault().Offset.GetValueOrDefault();

        }

    }
}

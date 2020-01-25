using System.Linq;
using System.Threading.Tasks;
using FlightService.Data;

namespace FlightService.Repositories.Bookings
{
    public class BookingRepository : Repository<Data.Bookings>, IBookingRepository
    {
        public BookingRepository(FlightContext context) : base(context)
        {

        }

        public FlightContext FlightContext=> Context as FlightContext;


        public async Task<int> BookFlight(Data.Bookings model)
        {
            Add(model);
            FlightContext.SaveChanges();
            return model.Id;
        }

        public async Task CancelBookFlight(string transationId)
        {
            var carRentRecord = FlightContext.Bookings.FirstOrDefault(x => x.TransactionId == transationId);
            if (carRentRecord!= null)
            {
                carRentRecord.BookingStatus = "Canceled";
                FlightContext.SaveChanges();
            }
           
        }
    }
}

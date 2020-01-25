using System.Linq;
using System.Threading.Tasks;
using HotelService.Data;

namespace HotelService.Repositories.Reservations
{
    public class ReservationRepository : Repository<Data.Reservations>, IReservationRepository
    {
        public ReservationRepository(HotelContext context) : base(context)
        {

        }

        public HotelContext HotelContext => Context as HotelContext;

        public async Task<int> ReserveHotel(Data.Reservations model)
        {

            Add(model);
            HotelContext.SaveChanges();
            return model.Id;
        }

        public async Task CancelReserveHotel(string transationId)
        {
            var carRentRecord = HotelContext.Reservations.FirstOrDefault(x => x.TransactionId == transationId);
            if (carRentRecord != null)
            {
                carRentRecord.ReservationStatus = "Canceled";
                HotelContext.SaveChanges();
            }
        }
    }
}

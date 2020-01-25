using System.Threading.Tasks;

namespace FlightService.Repositories.Bookings
{
    public interface IBookingRepository
    {
        Task<int> BookFlight(Data.Bookings model);
        Task CancelBookFlight(string transationId);
    }
}

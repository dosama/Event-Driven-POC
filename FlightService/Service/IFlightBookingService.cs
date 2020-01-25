using System.Threading.Tasks;
using FlightService.Models;

namespace FlightService.Service
{
    public interface IFlightBookingService
    {
  
         Task<int> BookFlight(BookingModel model);
         Task CancelBookFlight(string transactionId);
    }
}

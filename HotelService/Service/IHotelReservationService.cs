using System.Threading.Tasks;
using HotelService.Models;

namespace HotelService.Service
{
    public interface IHotelReservationService
    {
        Task<int> ReserveHotel(ReserveModel model);
        Task CancelReserveHotel(string transationId);
    }
}

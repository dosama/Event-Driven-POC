using System.Threading.Tasks;

namespace HotelService.Repositories.Reservations
{
    public interface IReservationRepository
    {
        Task<int> ReserveHotel(Data.Reservations model);
        Task CancelReserveHotel(string transationId);
    }
}

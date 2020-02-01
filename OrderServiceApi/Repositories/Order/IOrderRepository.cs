using System.Threading.Tasks;
using OrderServiceApi.Messaging.Data;

namespace OrderServiceApi.Repositories.Order
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Data.Orders model);
        Task CancelOrder(string transactionId);
        Task<bool> IsConfirmedOrder(string transationId);
        Task ConfirmHotelOrder(string transactionId , int reservationId);
        Task ConfirmFlightOrder(string transactionId, int flightBookingId);
        Task ConfirmCarOrder(string transactionId, int carRentId);

    }
}

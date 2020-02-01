using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderServiceApi.Data;

namespace OrderServiceApi.Repositories.Order
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {

        }

        public OrderContext OrderContext => Context as OrderContext;


        public async Task<int> AddOrder(Orders model)
        {
            OrderContext.Add(model);
            OrderContext.SaveChanges();
            return model.OrderNumber;
        }

        public async Task CancelOrder(string transactionId)
        {
            var order = await OrderContext.Orders.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
            order.OrderStatus = "Cancelled";
            OrderContext.SaveChanges();

        }

        public async Task<bool> IsConfirmedOrder(string transactionId)
        {
            var order = await OrderContext.Orders.FirstOrDefaultAsync(x => x.TransactionId == transactionId);

            return order.CarRentId != null && order.FlightBookingId != null && order.HotelReservationId != null;

        }

        public async Task ConfirmHotelOrder(string transactionId, int reservationId)
        {
            var order = await OrderContext.Orders.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
            order.HotelReservationId = reservationId;
            OrderContext.SaveChanges();
        }

        public async Task ConfirmFlightOrder(string transactionId, int flightBookingId)
        {
            var order = await OrderContext.Orders.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
            order.FlightBookingId = flightBookingId;
            OrderContext.SaveChanges();
        }

        public async Task ConfirmCarOrder(string transactionId, int carRentId)
        {
            var order = await OrderContext.Orders.FirstOrDefaultAsync(x => x.TransactionId == transactionId);
            order.CarRentId = carRentId;
            OrderContext.SaveChanges();
        }
    }
}

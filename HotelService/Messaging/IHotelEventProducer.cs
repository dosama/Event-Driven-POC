using System.Threading.Tasks;
using HotelService.Messaging.Data;

namespace HotelService.Messaging
{
    public interface IHotelEventProducer
    {
        Task SendOrderDoneMessage(HotelOrderConfirmedMessage model);
        Task SendOrderNotCompleterdMessage(string transactionId);
    }
  
}

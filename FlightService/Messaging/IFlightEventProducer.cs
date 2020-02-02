using System.Threading.Tasks;
using FlightService.Messaging.Data;

namespace FlightService.Messaging
{
    public interface IFlightEventProducer
    {
        Task SendOrderDoneMessage(FlightOrderConfirmedMessage model);
        Task SendOrderNotCompleterdMessage(string transactionId);
    }
  
}

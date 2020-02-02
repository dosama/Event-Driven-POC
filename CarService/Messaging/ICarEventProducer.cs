using System.Threading.Tasks;
using CarService.Messaging.Data;

namespace CarService.Messaging
{
    public interface ICarEventProducer
    {
        Task SendOrderDoneMessage(CarOrderConfirmedMessage model);
        Task SendOrderNotCompleterdMessage(string transactionId);
    }
  
}

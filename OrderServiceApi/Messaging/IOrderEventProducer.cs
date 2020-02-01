using System.Threading.Tasks;
using OrderServiceApi.Models;

namespace OrderServiceApi.Messaging
{
    public interface IOrderEventProducer
    {
        Task SendPlaceOrderMessages(string transactionId, SubmitOrderModel model);
        Task SendCancelOrderMessages(string transactionId);
    }
  
}

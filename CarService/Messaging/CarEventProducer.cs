using System.Threading.Tasks;
using CarService.Messaging.Data;

namespace CarService.Messaging
{
    public class CarEventProducer : ICarEventProducer
    {
        private IKafkaService _kafkaService;
        private IMessageSerializer _messageSerializer;
        public CarEventProducer(IKafkaService kafkaService, IMessageSerializer messageSerializer)
        {
            _kafkaService = kafkaService;
            _messageSerializer = messageSerializer;
        }

        public async Task SendOrderDoneMessage(CarOrderConfirmedMessage model)
        {
             _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Car_Order_Done_Event,
                _messageSerializer.Serialize(new CarOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    CarRentId = model.CarRentId
                }));
        }

        public async Task SendOrderNotCompleterdMessage(string transactionId)
        {
            _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Car_Order_Not_Completed_Event, transactionId);
        }
    }
}

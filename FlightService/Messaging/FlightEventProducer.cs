using System.Threading.Tasks;
using FlightService.Messaging.Data;

namespace FlightService.Messaging
{
    public class FlightEventProducer : IFlightEventProducer
    {
        private IKafkaService _kafkaService;
        private IMessageSerializer _messageSerializer;
        public FlightEventProducer(IKafkaService kafkaService, IMessageSerializer messageSerializer)
        {
            _kafkaService = kafkaService;
            _messageSerializer = messageSerializer;
        }

        public async Task SendOrderDoneMessage(FlightOrderConfirmedMessage model)
        {
             _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Flight_Order_Done_Event,
                _messageSerializer.Serialize(new FlightOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    FlightBookingId = model.FlightBookingId
                }));
        }

        public async Task SendOrderNotCompleterdMessage(string transactionId)
        {
            _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Flight_Order_Not_Completed_Event, transactionId);
        }
    }
}

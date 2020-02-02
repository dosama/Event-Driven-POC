using System.Threading.Tasks;
using HotelService.Messaging.Data;

namespace HotelService.Messaging
{
    public class HotelEventProducer : IHotelEventProducer
    {
        private IKafkaService _kafkaService;
        private IMessageSerializer _messageSerializer;
        public HotelEventProducer(IKafkaService kafkaService, IMessageSerializer messageSerializer)
        {
            _kafkaService = kafkaService;
            _messageSerializer = messageSerializer;
        }

        public async Task SendOrderDoneMessage(HotelOrderConfirmedMessage model)
        {
             _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Hotel_Order_Done_Event,
                _messageSerializer.Serialize(new HotelOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    HotelReservationId = model.HotelReservationId
                }));
        }

        public async Task SendOrderNotCompleterdMessage(string transactionId)
        {
            _kafkaService.SendEvent(KafkaConstants.Order_Topic, KafkaConstants.Hotel_Order_Not_Completed_Event, transactionId);
        }
    }
}

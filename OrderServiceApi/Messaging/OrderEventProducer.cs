using System.Threading.Tasks;
using OrderServiceApi.Messaging.Data;
using OrderServiceApi.Models;

namespace OrderServiceApi.Messaging
{
    public class OrderEventProducer : IOrderEventProducer
    {
        private IKafkaService _kafkaService;
        private IMessageSerializer _messageSerializer;
        public OrderEventProducer(IKafkaService kafkaService, IMessageSerializer messageSerializer)
        {
            _kafkaService = kafkaService;
            _messageSerializer = messageSerializer;
        }

        public async Task SendPlaceOrderMessages(string transactionId, SubmitOrderModel model)
        {
            _kafkaService.SendEvent(KafkaConstants.Hotel_Topic, KafkaConstants.Place_Hotel_Order_Event,
                _messageSerializer.Serialize(new PlaceHotelOrderMessage()
                {
                    TransactionId = transactionId,
                    HotelReservationDate = model.HotelReservationDate
                }));
            _kafkaService.SendEvent(KafkaConstants.Flight_Topic, KafkaConstants.Place_Flight_Order_Event,
                _messageSerializer.Serialize(new PlaceFlightOrderMessage()
                {
                    TransactionId = transactionId,
                    FlightNumber = model.FlightNumber
                }));
            _kafkaService.SendEvent(KafkaConstants.Car_Topic, KafkaConstants.Place_Car_Order_Event,
                _messageSerializer.Serialize(new PlaceCarOrderMessage()
                {
                    TransactionId = transactionId,
                    CarRentPrice = model.CarRentPrice
                }));

        }

        public async Task SendCancelOrderMessages(string transactionId)
        {
            _kafkaService.SendEvent(KafkaConstants.Hotel_Topic, KafkaConstants.Cancel_Hotel_Order_Event,transactionId);
            _kafkaService.SendEvent(KafkaConstants.Flight_Topic, KafkaConstants.Cancel_Flight_Order_Event,transactionId);
            _kafkaService.SendEvent(KafkaConstants.Car_Topic, KafkaConstants.Cancel_Car_Order_Event,transactionId);
        }
    }
}

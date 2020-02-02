using System;
using System.Threading.Tasks;
using HotelService.Messaging.Data;
using HotelService.Models;
using HotelService.Service;

namespace HotelService.Messaging
{
    public class HotelEventHandler: IHotelEventHandler
    {
        private IHotelReservationService _hotelReservationService;
        private IMessageSerializer _messageSerializer;
        public HotelEventHandler(IHotelReservationService hotelReservationService, IMessageSerializer messageSerializer)
        {
            _hotelReservationService = hotelReservationService;
            _messageSerializer = messageSerializer;
        }
        
        public async Task Handle(string eventName, string message)
        {
            switch (eventName)
            {
                case KafkaConstants.Place_Hotel_Order_Event:
                    var hotelModel = _messageSerializer.DeSerialize<PlaceHotelOrderMessage>(message);
                    _hotelReservationService.ReserveHotel(new ReserveModel()
                    {
                        TransactionId = hotelModel.TransactionId,
                        ReservationDate = hotelModel.HotelReservationDate,
                        Price = 20,
                        CreatedDate = DateTime.Now,
                        ReservationStatus = "Done"
                    });
                    return;
                case KafkaConstants.Cancel_Hotel_Order_Event:
                    _hotelReservationService.CancelReserveHotel(message);
                    return;
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.Messaging.Data;
using HotelService.Models;
using HotelService.Repositories.Reservations;
using HotelService.Service;

namespace HotelService.Messaging
{
    public class HotelEventHandler: IHotelEventHandler
    {
        private IHotelReservationService _hotelReservationService;
        private IMessageSerializer _messageSerializer;
        public HotelEventHandler(IHotelReservationService hotelReservationOrder, IMessageSerializer messageSerializer)
        {
            _hotelReservationService = hotelReservationOrder;
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

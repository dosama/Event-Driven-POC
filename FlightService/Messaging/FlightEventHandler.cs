using System;
using System.Threading.Tasks;
using FlightService.Data;
using FlightService.Messaging.Data;
using FlightService.Models;
using FlightService.Repositories.Bookings;
using FlightService.Service;

namespace FlightService.Messaging
{
    public class FlightEventHandler: IFlightEventHandler
    {
        private IFlightBookingService _bookingService;
        private IMessageSerializer _messageSerializer;
        public FlightEventHandler(IFlightBookingService bookingService, IMessageSerializer messageSerializer)
        {
            _bookingService = bookingService;
            _messageSerializer = messageSerializer;
        }
        
        public async Task Handle(string eventName, string message)
        {
            switch (eventName)
            {
                case KafkaConstants.Place_Flight_Order_Event:
                    var flightModel = _messageSerializer.DeSerialize<PlaceFlightOrderMessage>(message);
                    _bookingService.BookFlight(new BookingModel()
                    { TransactionId = flightModel.TransactionId,BookingStatus = "Done",CreatedDate = DateTime.Now,FlightNumber = flightModel.FlightNumber});
                   
                    return;
                case KafkaConstants.Cancel_Flight_Order_Event:
                    _bookingService.CancelBookFlight(message);
                    return;
            }
        }
    }
}

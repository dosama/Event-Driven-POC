using System;
using System.Threading.Tasks;
using FlightService.Messaging.Data;
using FlightService.Models;
using FlightService.Service;

namespace FlightService.Messaging
{
    public class FlightEventHandler: IFlightEventHandler
    {
        private IFlightBookingService _flightBookingService;
        private IMessageSerializer _messageSerializer;
        public FlightEventHandler(IFlightBookingService flightBookingService, IMessageSerializer messageSerializer)
        {
            _flightBookingService = flightBookingService;
            _messageSerializer = messageSerializer;
        }
        
        public async Task Handle(string eventName, string message)
        {
            switch (eventName)
            {
                case KafkaConstants.Place_Flight_Order_Event:
                    var flightModel = _messageSerializer.DeSerialize<PlaceFlightOrderMessage>(message);
                    _flightBookingService.BookFlight(new BookingModel()
                    { TransactionId = flightModel.TransactionId,BookingStatus = "Done",CreatedDate = DateTime.Now,FlightNumber = flightModel.FlightNumber});
                   
                    return;
                case KafkaConstants.Cancel_Flight_Order_Event:
                    _flightBookingService.CancelBookFlight(message);
                    return;
            }
        }
    }
}

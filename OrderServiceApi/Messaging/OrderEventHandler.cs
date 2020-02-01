using OrderServiceApi.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Messaging.Data;
using OrderServiceApi.Models;

namespace OrderServiceApi.Service
{
    public class OrderEventHandler: IOrderEventHandler
    {
        private IOrderService _orderService;
        private IMessageSerializer _messageSerializer;
        public OrderEventHandler(IOrderService orderService, IMessageSerializer messageSerializer)
        {
            _orderService = orderService;
            _messageSerializer = messageSerializer;
        }
        
        public async Task Handle(string eventName, string message)
        {
            switch (eventName)
            {
                case KafkaConstants.Hotel_Order_Done_Event:
                    var hotelModel = _messageSerializer.DeSerialize<HotelOrderConfirmedMessage>(message);
                    _orderService.ConfirmHotelOrder(hotelModel);
                    return;
                case KafkaConstants.Flight_Order_Done_Event:
                    var flightModel = _messageSerializer.DeSerialize<FlightOrderConfirmedMessage>(message);
                    _orderService.ConfirmFlightOrder(flightModel);
                    return;
                case KafkaConstants.Car_Order_Done_Event:
                    var carModel = _messageSerializer.DeSerialize<CarOrderConfirmedMessage>(message);
                    _orderService.ConfirmCarOrder(carModel);
                    return;
                case KafkaConstants.Hotel_Order_Not_Completed_Event:
                case KafkaConstants.Flight_Order_Not_Completed_Event:
                case KafkaConstants.Car_Order_Not_Completed_Event:
                    _orderService.CancelOrder(message);
                    return;
            }
        }
    }
}

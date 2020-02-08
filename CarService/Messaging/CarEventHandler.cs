using System;
using System.Threading.Tasks;
using CarService.Messaging;
using CarService.Messaging.Data;
using CarService.Models;
using CarService.Repositories.Rents;
using CarService.Service;
using CarService.Data;

namespace CarService.Messaging
{
    public class CarEventHandler: ICarEventHandler
    {
        private IRentCarService _rentCarService;
        private IMessageSerializer _messageSerializer;
        public CarEventHandler(IRentCarService rentCarService, IMessageSerializer messageSerializer)
        {
            _rentCarService = rentCarService;
            _messageSerializer = messageSerializer;
        }
        
        public async Task Handle(string eventName, string message)
        {
            switch (eventName)
            {
                case KafkaConstants.Place_Car_Order_Event:
                    var carModel = _messageSerializer.DeSerialize<PlaceCarOrderMessage>(message);
                    _rentCarService.RentCar(new RentModel()
                    {
                        CarNumber = "hskjds89",
                        CreatedDate = DateTime.Now,
                        RentPrice = carModel.CarRentPrice,
                        Staus = "Done",
                        TransactionId = carModel.TransactionId
                    });
                   
                    return;
                case KafkaConstants.Cancel_Car_Order_Event:
                    _rentCarService.CancelRentCar(message);
                    return;
            }
        }

    }
}

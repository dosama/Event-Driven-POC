using System;
using System.Threading.Tasks;
using CarService.Messaging;
using CarService.Messaging.Data;
using CarService.Models;
using CarService.Repositories.Rents;

namespace CarService.Service
{
    class RentCarService : IRentCarService
    {
        private readonly IRentRepository _rentRepository;
        private ICarEventProducer _carEventProducer;

        public RentCarService(IRentRepository rentRepository, ICarEventProducer carEventProducer)
        {
            _rentRepository = rentRepository;
            _carEventProducer = carEventProducer;


        }

        public async Task<int> RentCar(RentModel model)
        {
            try
            {
                var carRentId = await _rentRepository.RentCar(new Data.Rents()
                {
                    CarNumber = model.CarNumber,
                    CreatedDate = model.CreatedDate,
                    RentPrice = model.RentPrice,
                    Staus = model.Staus,
                    TransactionId = model.TransactionId
                });

                _carEventProducer.SendOrderDoneMessage(new CarOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    CarRentId = carRentId
                });
               // throw  new Exception();
                return carRentId;
            }
            catch (Exception e)
            {

                _carEventProducer.SendOrderNotCompleterdMessage(model.TransactionId);
                Console.WriteLine(e);
                return -1;
            }
           
        }

        public async Task CancelRentCar(string transactionId)
        {
            try
            {
                _rentRepository.CancelRentCar(transactionId);
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

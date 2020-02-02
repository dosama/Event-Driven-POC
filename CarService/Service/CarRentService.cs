using System;
using System.Threading.Tasks;
using CarService.Models;
using CarService.Repositories.Rents;

namespace CarService.Service
{
    class RentCarService : IRentCarService
    {
        private readonly IRentRepository _rentRepository;

        public RentCarService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
       
        }

        public Task<int> RentCar(RentModel model)
        {
            try
            {
                var carRentId = _rentRepository.RentCar(new Data.Rents()
                {
                    CarNumber = model.CarNumber,
                    CreatedDate = model.CreatedDate,
                    RentPrice = model.RentPrice,
                    Staus = model.Staus,
                    TransactionId = model.TransactionId
                });

                return carRentId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
                throw;
            }
        }
    }
}

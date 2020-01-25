using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data;
using CarService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.Repositories.Rents
{
    public class RentRepository : Repository<Data.Rents>, IRentRepository
    {
        public RentRepository(CarContext context) : base(context)
        {

        }

        public CarContext CarContext => Context as CarContext;


        public async Task<int> RentCar(Data.Rents model)
        {
            Add(model);
            CarContext.SaveChanges();
            return model.Id;
        }

        public async Task CancelRentCar(string transationId)
        {
            var carRentRecord = CarContext.Rents.FirstOrDefault(x => x.TransactionId == transationId);
            if (carRentRecord!= null)
            {
                carRentRecord.Staus = "Canceled";
                CarContext.SaveChanges();
            }
           
        }
    }
}

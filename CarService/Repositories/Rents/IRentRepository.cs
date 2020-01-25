using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Repositories.Rents
{
    public interface IRentRepository
    {
        Task<int> RentCar(Data.Rents model);
        Task CancelRentCar(string transationId);
    }
}

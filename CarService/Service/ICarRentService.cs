using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Service
{
    public interface IRentCarService
    {
  
         Task<int> RentCar(RentModel model);
         Task CancelRentCar(string transactionId);
    }
}

using System.Threading.Tasks;

namespace OrderServiceApi.Repositories.Order
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Data.Orders model);
        Task<bool> IsValidOrder(string transationId);
    }
}

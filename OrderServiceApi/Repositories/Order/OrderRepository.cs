using System.Threading.Tasks;
using OrderServiceApi.Data;

namespace OrderServiceApi.Repositories.Order
{
    public class OrderRepository : Repository<Orders>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {

        }

        public OrderContext OrderContext => Context as OrderContext;


        public Task<int> AddOrder(Orders model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsValidOrder(string transationId)
        {
            throw new System.NotImplementedException();
        }
    }
}

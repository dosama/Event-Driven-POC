using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Models;

namespace OrderServiceApi.Service
{
    public class OrderService:IOrderService
    {
        public Task PlaceOrder(SubmitOrderModel model)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

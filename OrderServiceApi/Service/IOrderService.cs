using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Models;

namespace OrderServiceApi.Service
{
    interface IOrderService
    {
        Task PlaceOrder(SubmitOrderModel model);
    }
}

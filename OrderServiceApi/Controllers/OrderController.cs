using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderServiceApi.Models;
using OrderServiceApi.Service;

namespace OrderServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] SubmitOrderModel value)
        {
            try
            {
                _orderService.SubmitOrder(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        [HttpGet]
        public string Get()
        {
            return "Welcome To Order Submission Service";
        }
    }
}

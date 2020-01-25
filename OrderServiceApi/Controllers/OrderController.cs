using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderServiceApi.Models;

namespace OrderServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] SubmitOrderModel value)
        {
            try
            {
              //  _reservationService.ReserveHotel(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        [HttpGet]
        public string Get()
        {
            return "Welcome To Order Submition Service";
        }
    }
}

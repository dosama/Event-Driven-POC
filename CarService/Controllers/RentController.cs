using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Models;
using CarService.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private IRentCarService _rentCarService;
        public RentController(IRentCarService rentCarService)
        {
            _rentCarService = rentCarService;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] RentModel value)
        {
            try
            {
                _rentCarService.RentCar(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
        }

        [HttpPost("Cancel")]
        public void Cancel([FromBody] string transactionId)
        {
            try
            {
                _rentCarService.CancelRentCar(transactionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [HttpGet]
        public string Get()
        {
            return "Welcome To Car Renting Service";
        }
    }

}

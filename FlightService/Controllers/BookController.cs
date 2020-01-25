using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightService.Models;
using FlightService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IFlightBookingService _flightBookingService;
        public BookController(IFlightBookingService flightBookingService)
        {
            _flightBookingService = flightBookingService;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] BookingModel value)
        {
            try
            {
                _flightBookingService.BookFlight(value);
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
                _flightBookingService.CancelBookFlight(transactionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [HttpGet]
        public string Get()
        {
            return "Welcome To Flight Booking Service";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelService.Models;
using HotelService.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private IHotelReservationService _reservationService;
        public ReserveController(IHotelReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] ReserveModel value)
        {
            try
            {
                _reservationService.ReserveHotel(value);
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
                _reservationService.CancelReserveHotel(transactionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        [HttpGet]
        public string Get()
        {
            return "Welcome To Hotel Reservation Service";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Models
{
    public class SubmitOrderModel
    {
        public DateTime HotelReservationDate { get; set; }
        public int FlightNumber { get; set; }
        public decimal CarRentPrice { get; set; }
    }
}

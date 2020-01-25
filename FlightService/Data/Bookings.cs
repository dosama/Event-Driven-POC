using System;
using System.Collections.Generic;

namespace FlightService.Data
{
    public partial class Bookings
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public int FlightNumber { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

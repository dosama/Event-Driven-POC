using System;

namespace FlightService.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public int FlightNumber { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

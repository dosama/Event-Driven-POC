using System;
using System.Collections.Generic;

namespace OrderServiceApi.Data
{
    public partial class Orders
    {
        public int OrderNumber { get; set; }
        public string TransactionId { get; set; }
        public int? CarRentId { get; set; }
        public int? FlightBookingId { get; set; }
        public int? HotelReservationId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
    }
}

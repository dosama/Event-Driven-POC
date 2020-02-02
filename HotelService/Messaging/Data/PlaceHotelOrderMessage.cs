using System;

namespace HotelService.Messaging.Data
{
    public class PlaceHotelOrderMessage
    {
        public string TransactionId { get; set; }
        public DateTime HotelReservationDate { get; set; }
    }
}

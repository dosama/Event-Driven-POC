using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging.Data
{
    public class PlaceHotelOrderMessage
    {
        public string TransactionId { get; set; }
        public DateTime HotelReservationDate { get; set; }
    }
}

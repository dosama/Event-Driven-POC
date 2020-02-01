using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging.Data
{
    public class PlaceFlightOrderMessage
    {
        public string TransactionId { get; set; }
        public int FlightNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging.Data
{
    public class FlightOrderConfirmedMessage
    {
        public string TransactionId { get; set; }
        public int FlightBookingId { get; set; }
    }
}

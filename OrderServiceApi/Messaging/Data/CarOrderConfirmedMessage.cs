using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging.Data
{
    public class CarOrderConfirmedMessage
    {
        public string TransactionId { get; set; }
        public int CarRentId { get; set; }
    }
}

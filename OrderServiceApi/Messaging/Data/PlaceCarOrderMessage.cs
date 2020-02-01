using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging.Data
{
    public class PlaceCarOrderMessage
    {
        public string TransactionId { get; set; }
        public decimal CarRentPrice { get; set; }
    }
}

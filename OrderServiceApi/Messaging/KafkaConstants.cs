using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging
{
    public static class KafkaConstants
    {
        // Topics
        public const string Hotel_Topic = "hotel";
        public const string Flight_Topic = "flight";
        public const string Car_Topic = "car";
        public const string Order_Topic = "orders";

        // Events
        public const string Place_Hotel_Order_Event = "Place_Hotel_Order";
        public const string Place_Flight_Order_Event = "Place_Flight_Order";
        public const string Place_Car_Order_Event = "Place_Car_Order";
        public const string Cancel_Hotel_Order_Event = "Cancel_Hotel_Order";
        public const string Cancel_Flight_Order_Event = "Cancel_Flight_Order";
        public const string Cancel_Car_Order_Event = "Cancel_Car_Order";

        public const string Hotel_Order_Done_Event = "Hotel_Order_Done";
        public const string Hotel_Order_Not_Completed_Event = "Hotel_Order_Not_Completed";
        public const string Flight_Order_Done_Event = "Flight_Order_Done";
        public const string Flight_Order_Not_Completed_Event = "Flight_Order_Not_Completed";
        public const string Car_Order_Done_Event = "Car_Order_Done";
        public const string Car_Order_Not_Completed_Event = "Car_Order_Not_Completed";
      
        
    }
}

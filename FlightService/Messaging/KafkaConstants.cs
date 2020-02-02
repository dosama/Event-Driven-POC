namespace FlightService.Messaging
{
    public static class KafkaConstants
    {
        // Topics

        public const string Flight_Topic = "flight";

        public const string Order_Topic = "orders";
        // Events
      
        public const string Place_Flight_Order_Event = "Place_Flight_Order";
        public const string Cancel_Flight_Order_Event = "Cancel_Flight_Order";

        
        public const string Flight_Order_Done_Event = "Flight_Order_Done";
        public const string Flight_Order_Not_Completed_Event = "Flight_Order_Not_Completed";
       

    }
}

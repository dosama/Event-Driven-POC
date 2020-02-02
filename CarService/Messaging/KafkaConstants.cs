namespace CarService.Messaging
{
    public static class KafkaConstants
    {
        // Topics
  
        public const string Car_Topic = "car";
        public const string Order_Topic = "orders";

        // Events
       
        public const string Place_Car_Order_Event = "Place_Car_Order";
        public const string Cancel_Car_Order_Event = "Cancel_Car_Order";

        public const string Car_Order_Done_Event = "Car_Order_Done";
        public const string Car_Order_Not_Completed_Event = "Car_Order_Not_Completed";


    }
}

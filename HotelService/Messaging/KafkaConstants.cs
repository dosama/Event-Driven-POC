namespace HotelService.Messaging
{
    public static class KafkaConstants
    {
        // Topics
        public const string Hotel_Topic = "hotel";

        public const string Order_Topic = "orders";
        // Events
        public const string Place_Hotel_Order_Event = "Place_Hotel_Order";
     
        public const string Cancel_Hotel_Order_Event = "Cancel_Hotel_Order";
    

        public const string Hotel_Order_Done_Event = "Hotel_Order_Done";
        public const string Hotel_Order_Not_Completed_Event = "Hotel_Order_Not_Completed";
        
      
        
    }
}

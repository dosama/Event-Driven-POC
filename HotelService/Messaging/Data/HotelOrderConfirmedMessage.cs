namespace HotelService.Messaging.Data
{
    public class HotelOrderConfirmedMessage
    {
        public string TransactionId { get; set; }
        public int HotelReservationId { get; set; }
    }
}

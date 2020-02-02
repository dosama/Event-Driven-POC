namespace FlightService.Messaging.Data
{
    public class FlightOrderConfirmedMessage
    {
        public string TransactionId { get; set; }
        public int FlightBookingId { get; set; }
    }
}

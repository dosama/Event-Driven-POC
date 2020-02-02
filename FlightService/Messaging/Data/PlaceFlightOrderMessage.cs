namespace FlightService.Messaging.Data
{
    public class PlaceFlightOrderMessage
    {
        public string TransactionId { get; set; }
        public int FlightNumber { get; set; }
    }
}

namespace CarService.Messaging.Data
{
    public class CarOrderConfirmedMessage
    {
        public string TransactionId { get; set; }
        public int CarRentId { get; set; }
    }
}

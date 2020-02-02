namespace CarService.Messaging.Data
{
    public class PlaceCarOrderMessage
    {
        public string TransactionId { get; set; }
        public decimal CarRentPrice { get; set; }
    }
}

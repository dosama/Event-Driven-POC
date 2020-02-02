namespace HotelService.Messaging
{
    public interface IMessageSerializer
    {
        string Serialize(object value);
        T DeSerialize<T>(string value);
    }
}

using Newtonsoft.Json;

namespace FlightService.Messaging
{
    public class MessageSelrializer: IMessageSerializer
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T DeSerialize<T>(string value)
        {
           return JsonConvert.DeserializeObject<T>(value);
        }
    }
}

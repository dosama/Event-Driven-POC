using System.Threading.Tasks;

namespace HotelService.Messaging
{
    public interface IKafkaService
    {
        Task SendEvent(string topic ,string eventName, string payload);
    }
}

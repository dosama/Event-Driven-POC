using System.Threading.Tasks;

namespace FlightService.Messaging
{
    public interface IKafkaService
    {
        Task SendEvent(string topic ,string eventName, string payload);
    }
}

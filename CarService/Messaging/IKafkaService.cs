using System.Threading.Tasks;

namespace CarService.Messaging
{
    public interface IKafkaService
    {
        Task SendEvent(string topic ,string eventName, string payload);
    }
}

using System.Threading.Tasks;

namespace OrderServiceApi.Messaging
{
    public interface IOrderEventHandler
    {
       Task Handle(string eventName, string message);
    }
}

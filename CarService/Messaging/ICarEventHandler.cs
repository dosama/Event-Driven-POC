using System.Threading.Tasks;

namespace CarService.Messaging
{
    public interface ICarEventHandler
    {
       Task Handle(string eventName, string message);
    }
}

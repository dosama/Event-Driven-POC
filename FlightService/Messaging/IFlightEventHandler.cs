using System.Threading.Tasks;

namespace FlightService.Messaging
{
    public interface IFlightEventHandler
    {
       Task Handle(string eventName, string message);
    }
}

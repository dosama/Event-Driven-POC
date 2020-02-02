using System.Threading.Tasks;

namespace HotelService.Messaging
{
    public interface IHotelEventHandler
    {
       Task Handle(string eventName, string message);
    }
}

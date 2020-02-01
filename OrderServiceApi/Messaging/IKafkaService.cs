using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging
{
    public interface IKafkaService
    {
        Task SendEvent(string topic ,string eventName, string payload);
    }
}

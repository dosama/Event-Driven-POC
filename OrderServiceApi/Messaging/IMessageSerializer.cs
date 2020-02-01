using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.Messaging
{
    public interface IMessageSerializer
    {
        string Serialize(object value);
        T DeSerialize<T>(string value);
    }
}

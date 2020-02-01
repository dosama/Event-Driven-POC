using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrderServiceApi.Messaging
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

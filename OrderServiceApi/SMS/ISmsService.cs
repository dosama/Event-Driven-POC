using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.SMS
{
    public interface ISmsService
    {
        Task SendSms(string message);
    }
}

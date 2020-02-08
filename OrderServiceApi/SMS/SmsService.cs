using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApi.SMS
{
    public class SmsService: ISmsService
    {
        public async Task SendSms(string message)
        {
            Console.WriteLine(message);
        }
    }
}

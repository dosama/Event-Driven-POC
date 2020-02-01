using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Models;

namespace OrderServiceApi.Service
{
    public interface IOrderEventHandler
    {
       Task Handle(string eventName, string message);
    }
}

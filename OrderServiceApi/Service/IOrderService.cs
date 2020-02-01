using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Messaging.Data;
using OrderServiceApi.Models;

namespace OrderServiceApi.Service
{
    public interface IOrderService
    {
        //Task IntializeOrder(SubmitOrderModel model);
        Task SubmitOrder(SubmitOrderModel model);
        Task ConfirmHotelOrder(HotelOrderConfirmedMessage model);
        Task ConfirmFlightOrder(FlightOrderConfirmedMessage model);
        Task ConfirmCarOrder(CarOrderConfirmedMessage model);
        Task CancelOrder(string transactionId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Data;
using OrderServiceApi.Messaging;
using OrderServiceApi.Messaging.Data;
using OrderServiceApi.Models;
using OrderServiceApi.Repositories.Order;
using OrderServiceApi.SMS;

namespace OrderServiceApi.Service
{
    public class OrderService:IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderEventProducer _orderEventProducer;
        private ISmsService _smsService;
        public OrderService(IOrderRepository orderRepository, IOrderEventProducer orderEventProducer, ISmsService smsService)
        {
            _orderRepository = orderRepository;
            _orderEventProducer = orderEventProducer;
            _smsService = smsService;
        }
        public async Task SubmitOrder(SubmitOrderModel model)
        {
            try
            {
                var orderModel = new Orders()
                {
                    CreatedDate = DateTime.Now,
                    OrderStatus = "Initiated",
                    TransactionId = Guid.NewGuid().ToString()
                };
                await _orderRepository.AddOrder(orderModel);
                _orderEventProducer.SendPlaceOrderMessages(orderModel.TransactionId, model);
                _smsService.SendSms("Your Order Has been Submitted Sucssesfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
          

        }

        private async Task<bool> IsOrderConfirmed(string transactionId)
        {
           return await _orderRepository.IsConfirmedOrder(transactionId);
        }

        private async Task HandleConfirmedOrder(string transactionID)
        {
            var isConfirmedOrder = await IsOrderConfirmed(transactionID);
            if (isConfirmedOrder)
            {
                _orderRepository.UpdateOrderConfirmationData(transactionID);
                _smsService.SendSms("Your Order Has been Submitted Sucssesfully");
            }
         

        }
        public async Task ConfirmHotelOrder(HotelOrderConfirmedMessage model)
        {
            await _orderRepository.ConfirmHotelOrder(model.TransactionId, model.HotelReservationId);
            HandleConfirmedOrder(model.TransactionId);
        }

        public async Task ConfirmFlightOrder(FlightOrderConfirmedMessage model)
        {
            await _orderRepository.ConfirmFlightOrder(model.TransactionId, model.FlightBookingId);
            HandleConfirmedOrder(model.TransactionId);
        }

        public async Task ConfirmCarOrder(CarOrderConfirmedMessage model)
        {
           await _orderRepository.ConfirmCarOrder(model.TransactionId, model.CarRentId);
            HandleConfirmedOrder(model.TransactionId);
        }

        public async Task CancelOrder(string transactionId)
        {
            try
            {
                _orderRepository.CancelOrder(transactionId);
                _orderEventProducer.SendCancelOrderMessages(transactionId);
                _smsService.SendSms("Your Order Is not confirmed .. Please contact System Admin for more information");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
        }
    }
}

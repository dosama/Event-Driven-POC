using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderServiceApi.Data;
using OrderServiceApi.Messaging;
using OrderServiceApi.Messaging.Data;
using OrderServiceApi.Models;
using OrderServiceApi.Repositories.Order;

namespace OrderServiceApi.Service
{
    public class OrderService:IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderEventProducer _orderEventProducer;
        public OrderService(IOrderRepository orderRepository, IOrderEventProducer orderEventProducer)
        {
            _orderRepository = orderRepository;
            _orderEventProducer = orderEventProducer;
        }
        public async Task SubmitOrder(SubmitOrderModel model)
        {
            var orderModel = new Orders()
            {
                CreatedDate = DateTime.Now,
                OrderStatus = "Initiated",
                TransactionId = Guid.NewGuid().ToString()
            };
          await _orderRepository.AddOrder(orderModel);
          _orderEventProducer.SendPlaceOrderMessages(orderModel.TransactionId, model);

        }

        public async Task ConfirmHotelOrder(HotelOrderConfirmedMessage model)
        {
            _orderRepository.ConfirmHotelOrder(model.TransactionId, model.HotelReservationId);
        }

        public async Task ConfirmFlightOrder(FlightOrderConfirmedMessage model)
        {
            _orderRepository.ConfirmFlightOrder(model.TransactionId, model.FlightBookingId);
        }

        public async Task ConfirmCarOrder(CarOrderConfirmedMessage model)
        {
            _orderRepository.ConfirmCarOrder(model.TransactionId, model.CarRentId);
        }

        public async Task CancelOrder(string transactionId)
        {
            await _orderRepository.CancelOrder(transactionId);
            _orderEventProducer.SendCancelOrderMessages(transactionId);
        }
    }
}

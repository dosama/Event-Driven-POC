using System;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.Messaging;
using HotelService.Messaging.Data;
using HotelService.Models;
using HotelService.Repositories.Reservations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HotelService.Service
{
    class HotelReservationService : IHotelReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IHotelEventProducer _hotelEventProducer;
        public HotelReservationService(IReservationRepository reservationRepository, IHotelEventProducer hotelEventProducer)
        {
            _reservationRepository = reservationRepository;
            _hotelEventProducer = hotelEventProducer;
        }

        public async Task<int> ReserveHotel(ReserveModel model)
        {

            try
            {
                var hotelReservationId = await _reservationRepository.ReserveHotel(new Reservations()
                {
                    Price = model.Price,
                    CreatedDate = model.CreatedDate,
                    ReservationDate = model.ReservationDate,
                    ReservationStatus = model.ReservationStatus,
                    TransactionId = model.TransactionId
                });
                _hotelEventProducer.SendOrderDoneMessage(new HotelOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    HotelReservationId = hotelReservationId
                });

                return hotelReservationId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _hotelEventProducer.SendOrderNotCompleterdMessage(model.TransactionId);
                throw;
            }

        }

        public async Task CancelReserveHotel(string transationId)
        {
            try
            {
                _reservationRepository.CancelReserveHotel(transationId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

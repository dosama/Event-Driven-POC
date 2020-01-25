using System;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.Models;
using HotelService.Repositories.Reservations;

namespace HotelService.Service
{
    class HotelReservationService : IHotelReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public HotelReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
       
        }

        public Task<int> ReserveHotel(ReserveModel model)
        {

            try
            {
                var carreservationId = _reservationRepository.ReserveHotel(new Reservations()
                {
                    Price = model.Price,
                    CreatedDate = model.CreatedDate,
                    ReservationDate = model.ReservationDate,
                    ReservationStatus = model.ReservationStatus,
                    TransactionId = model.TransactionId
                });

                return carreservationId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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

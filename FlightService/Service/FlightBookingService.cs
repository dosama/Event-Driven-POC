using System;
using System.Threading.Tasks;
using FlightService.Data;
using FlightService.Models;
using FlightService.Repositories.Bookings;

namespace FlightService.Service
{
    class FlightBookingService : IFlightBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public FlightBookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
       
        }

        public Task<int> BookFlight(BookingModel model)
        {

            try
            {
                var carbookingId = _bookingRepository.BookFlight(new Bookings()
                {
                    FlightNumber = model.FlightNumber,
                    CreatedDate = model.CreatedDate,
                    BookingStatus = model.BookingStatus,
                    TransactionId = model.TransactionId
                });

                return carbookingId;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }

        public async Task CancelBookFlight(string transactionId)
        {
            try
            {
                _bookingRepository.CancelBookFlight(transactionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

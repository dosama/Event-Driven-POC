using System;
using System.Threading.Tasks;
using FlightService.Data;
using FlightService.Messaging;
using FlightService.Messaging.Data;
using FlightService.Models;
using FlightService.Repositories.Bookings;

namespace FlightService.Service
{
    class FlightBookingService : IFlightBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private IFlightEventProducer _flightEventProducer;
        public FlightBookingService(IBookingRepository bookingRepository, IFlightEventProducer flightEventProducer)
        {
            _bookingRepository = bookingRepository;
            _flightEventProducer = flightEventProducer;
        }

        public async Task<int> BookFlight(BookingModel model)
        {

            try
            {
                var flightbookingId = await _bookingRepository.BookFlight(new Bookings()
                {
                    FlightNumber = model.FlightNumber,
                    CreatedDate = model.CreatedDate,
                    BookingStatus = model.BookingStatus,
                    TransactionId = model.TransactionId
                });

                _flightEventProducer.SendOrderDoneMessage(new FlightOrderConfirmedMessage()
                {
                    TransactionId = model.TransactionId,
                    FlightBookingId = flightbookingId
                });

                return flightbookingId;

            }
            catch (Exception e)
            {

                _flightEventProducer.SendOrderNotCompleterdMessage(model.TransactionId);
                Console.WriteLine(e);
                return -1;
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

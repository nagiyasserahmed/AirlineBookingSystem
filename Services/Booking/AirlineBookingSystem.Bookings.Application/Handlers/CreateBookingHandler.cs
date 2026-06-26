using AirlineBookingSystem.Bookings.Application.Commands;
using AirlineBookingSystem.Bookings.Core;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Bookings.Application.Handlers;

public class CreateBookingHandler(IBookingRepository bookingRepository, IPublishEndpoint endpoint) : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow
        };

        await bookingRepository.AddBookingAsync(booking);

        await endpoint.Publish(new FlightBookedEvent(
               booking.Id,
               booking.FlightId,
               booking.PassengerName,
               booking.SeatNumber,
               booking.BookingDate
            ));

        return booking.Id;
    }
}
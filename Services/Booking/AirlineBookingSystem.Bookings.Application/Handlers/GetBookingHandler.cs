using AirlineBookingSystem.Bookings.Application.Queries;
using AirlineBookingSystem.Bookings.Core;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Exceptions;
using MediatR;

namespace AirlineBookingSystem.Bookings.Application.Handlers;

public class GetBookingHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetBookingQuery, Booking>
{
    public async Task<Booking> Handle(
        GetBookingQuery request,
        CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetBookingByIdAsync(request.Id);

        if (booking is null)
        {
            throw new NotFoundException(
                nameof(Booking),
                request.Id);
        }

        return booking;
    }
}
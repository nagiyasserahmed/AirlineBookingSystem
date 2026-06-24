using AirlineBookingSystem.Bookings.Core;
using MediatR;

namespace AirlineBookingSystem.Bookings.Application.Queries;

public record GetBookingQuery(Guid Id): IRequest<Booking>;
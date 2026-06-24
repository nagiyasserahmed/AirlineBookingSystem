using MediatR;

namespace AirlineBookingSystem.Flights.Application.Commands;

public record DeleteFlightCommand(Guid Id): IRequest;
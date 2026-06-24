using AirelineBookingSystem.Flights.Core.Repositories;
using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Core.Entities;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers;

public class CreateFlightHandler(IFlightRepository flightRepository) : IRequestHandler<CreateFlightCommand, Guid>
{
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureTime = request.DepartureTime,
            ArrivalTime = request.ArrivalTime
        };

        await flightRepository.AddFlightAsync(flight);

        return flight.Id;
    }
}
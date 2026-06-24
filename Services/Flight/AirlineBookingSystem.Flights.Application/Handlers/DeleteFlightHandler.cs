using AirelineBookingSystem.Flights.Core.Repositories;
using AirlineBookingSystem.Flights.Application.Commands;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Handlers;


public class DeleteFlightHandler(IFlightRepository flightRepository) : IRequestHandler<DeleteFlightCommand>
{
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await flightRepository.DeleteFlightAsync(request.Id);
    }
}


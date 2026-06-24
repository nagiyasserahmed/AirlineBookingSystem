using AirelineBookingSystem.Flights.Core.Repositories;
using AirlineBookingSystem.Flights.Core.Entities;
using MediatR;

namespace AirlineBookingSystem.Flights.Application.Queries;

public class GetAllFlightsHandler(IFlightRepository flightRepository) : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight>>
{
    public async Task<IEnumerable<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await flightRepository.GetFlightsAsync();
    }
}
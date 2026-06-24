using AirlineBookingSystem.Flights.Core.Entities;

namespace AirelineBookingSystem.Flights.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task AddFlightAsync(Flight flight);
        Task DeleteFlightAsync(Guid id);
    }
}
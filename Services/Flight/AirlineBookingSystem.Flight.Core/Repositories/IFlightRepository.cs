using AirlineBookingSystem.Flight.Core.Entities;

namespace AirlineBookingSystem.Flight.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Booking> GetFlightByIdAsync(Guid id);
        Task AddFlightAsync(Flight flight);
        Task DeleteFlightAsync(Guid id);
    }
}
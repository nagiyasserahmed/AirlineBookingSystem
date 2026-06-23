using AirlineBookingSystem.Bookins.Core.Entities;

namespace AirlineBookingSystem.Bookins.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(Guid id);
        Task AddBookingAsync(Booking booking);
    }
}
namespace AirlineBookingSystem.Bookings.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking?> GetBookingByIdAsync(Guid id);
        Task AddBookingAsync(Booking booking);
    }
}
using System.Data;
using AirlineBookingSystem.Bookings.Core;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;

namespace AirlineBookingSystems.Bookings.Infrastructure;

public class BookingRepository(IDbConnection dbConnection) : IBookingRepository
{
    public async Task AddBookingAsync(Booking booking)
    {
        const string sql = """
            INSERT INTO Bookings
            (
                Id,
                FlightId,
                PassengerName,
                SeatNumber,
                BookingDate
            )
            VALUES
            (
                @Id,
                @FlightId,
                @PassengerName,
                @SeatNumber,
                @BookingDate
            );
            """;

        await dbConnection.ExecuteAsync(sql, booking);
    }

    public async Task<Booking?> GetBookingByIdAsync(Guid id)
    {
        const string sql = """
            SELECT
                Id,
                FlightId,
                PassengerName,
                SeatNumber,
                BookingDate
            FROM Bookings
            WHERE Id = @Id;
            """;

        return await dbConnection.QuerySingleOrDefaultAsync<Booking>(
            sql,
            new { Id = id });
    }
}
using System.Data;
using Dapper;
using AirelineBookingSystem.Flights.Core.Repositories;
using AirlineBookingSystem.Flights.Core.Entities;

namespace AirelineBookingSystem.Flights.Infrastructure;

public class FlightRepository(IDbConnection dbConnection) : IFlightRepository
{
    public async Task AddFlightAsync(Flight flight)
    {
        const string sql = """
            INSERT INTO Flights
            (
                Id,
                FlightNumber,
                Origin,
                Destination,
                DepartureTime,
                ArrivalTime
            )
            VALUES
            (
                @Id,
                @FlightNumber,
                @Origin,
                @Destination,
                @DepartureTime,
                @ArrivalTime
            );
            """;

        await dbConnection.ExecuteAsync(sql, flight);
    }

    public async Task DeleteFlightAsync(Guid id)
    {
        const string sql = """
            DELETE FROM Flights
            WHERE Id = @Id;
            """;

        await dbConnection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<Flight>> GetFlightsAsync()
    {
        const string sql = """
            SELECT
                Id,
                FlightNumber,
                Origin,
                Destination,
                DepartureTime,
                ArrivalTime
            FROM Flights;
            """;

        return await dbConnection.QueryAsync<Flight>(sql);
    }
}
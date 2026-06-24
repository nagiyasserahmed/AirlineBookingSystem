using System.Data;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Payments.Infrastructure;

public class PaymentRepository(IDbConnection dbConnection) : IPaymentRepository
{
    public async Task ProcessPaymentAsync(Payment payment)
    {
        const string sql = """
            INSERT INTO Payments
            (
                Id,
                BookingId,
                Amount,
                PaymentDate
            )
            VALUES
            (
                @Id,
                @BookingId,
                @Amount,
                @PaymentDate
            );
            """;

        await dbConnection.ExecuteAsync(sql, payment);
    }

    public async Task RefundPaymentAsync(Guid id)
    {
        const string sql = """
            DELETE FROM Payments
            WHERE Id = @Id;
            """;

        await dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}
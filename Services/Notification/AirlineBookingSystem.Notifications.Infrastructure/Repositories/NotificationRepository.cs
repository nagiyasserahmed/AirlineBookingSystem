using System.Data;
using Dapper;
using AirlineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.Notifications.Core.Repositories;

namespace AirlineBookingSystem.Notifications.Infrastructure;

public class NotificationRepository(IDbConnection dbConnection) : INotificationRepository
{
    public async Task LogNotificationAsync(Notification notification)
    {
        const string sql = """
            INSERT INTO Notifications
            (
                Id,
                Recipient,
                Message,
                Type
            )
            VALUES
            (
                @Id,
                @Recipient,
                @Message,
                @Type
            );
            """;

        await dbConnection.ExecuteAsync(sql, notification);
    }
}
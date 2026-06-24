using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService : INotificationService
{
    public Task<Boolean> SendNotificationAsync(Notification notification)
    {
        Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");

        return Task.FromResult(true);
    }
}
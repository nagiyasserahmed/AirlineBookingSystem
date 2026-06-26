using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Services;

public class NotificationService(IPublishEndpoint publishEndpoint) : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");

        var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);

        await publishEndpoint.Publish(notificationEvent);
    }
}
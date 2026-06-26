
using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Notification notification);
}
using AirlineBookingSystem.Notification.Core.Entities;

namespace AirlineBookingSystem.Notification.Core.Repositories
{
    public interface INotificationRepository
    {
       Task LogNotificationAsync(Notification notification);
    }
}
using AirlineBookingSystem.Notifications.Application.Commands;
using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.Notifications.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Notifications.Application.Handlers;

public class SendNotificationHandler(INotificationService notificationService) : IRequestHandler<SendNotificationCommand, Guid>
{
    public async Task<Guid> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type
        };


        await notificationService.SendNotificationAsync(notification);

        return notification.Id;
    }
}
using MediatR;

namespace AirlineBookingSystem.Notifications.Application.Commands;

public record SendNotificationCommand(string Recipient, string Message, string Type): IRequest<Guid>;
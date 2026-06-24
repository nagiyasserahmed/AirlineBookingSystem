using AirlineBookingSystem.Notifications.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Notifications.Api.Controllers;

[Controller]
[Route("api/notifications")]
public class NotificationsController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Payments.Api.Controllers;

[Controller]
[Route("api/payments")]
public class PaymentsController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(ProcessPayment), new {id}, command);
    }

    [HttpPost("refund/{id}")]
    public async Task<IActionResult> RefundPayment(Guid Id)
    {
       await mediator.Send(new RefundPaymentCommand(Id));

       return NoContent();
    }
}
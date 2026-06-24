using AirlineBookingSystem.Bookings.Application.Commands;
using AirlineBookingSystem.Bookings.Application.Queries;
using AirlineBookingSystem.Bookings.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Bookings.Api.Controller;

[Controller]
[Route("api/bookings")]
public class BookingsController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetBookingById), new {id}, command);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(Guid Id)
    {
        var booking = await mediator.Send(new GetBookingQuery(Id));

        return Ok(booking);
    } 
}
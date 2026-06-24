using AirlineBookingSystem.Flights.Application.Commands;
using AirlineBookingSystem.Flights.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirelineBookingSystem.Flights.Api.Controllers;

[Controller]
[Route("api/flights")]
public class FlightsController(IMediator mediator): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var flights = await mediator.Send(new GetAllFlightsQuery());

        return Ok(flights);
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
    {
        var id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetFlights), new {id}, command);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFlight(Guid Id)
    {
        await mediator.Send(new DeleteFlightCommand(Id));

        return NoContent();
    }
}
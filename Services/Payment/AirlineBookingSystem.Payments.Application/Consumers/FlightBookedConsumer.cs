using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using MassTransit;

namespace AirlineBookingSystem.Payments.Application.Consumers
{
    public class FlightBookedConsumer(IMediator mediator) : IConsumer<FlightBookedEvent>
    {
        public async Task Consume(ConsumeContext<FlightBookedEvent> context)
        {
            var flightBookedEvent = context.Message;

            var command = new ProcessPaymentCommand(flightBookedEvent.BookingId, 200.00m);
            await mediator.Send(command);
        }
    }
}

using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Notifications.Application.Commands;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.Notifications.Application.Consumers
{
    public class PaymentProcessedConsumer(IMediator mediator) : IConsumer<PaymentProcessedEvent>
    {
        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessedEvent = context.Message;
            var message = $"Payment of ${paymentProcessedEvent.Amount} for BookingId: {paymentProcessedEvent.BookingId} was processed successfully.";

            var command = new SendNotificationCommand("nagiyasserahmed@gmail.com", message, "Email");

            await mediator.Send(command);
        }
    }
}

using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;

public class ProcessPaymentHandler(IPaymentRepository paymentRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<ProcessPaymentCommand, Guid>
{
    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
          Id = Guid.NewGuid(),
          BookingId = request.BookingId,
          Amount = request.Amount,
          PaymentDate = DateTime.UtcNow
        };

        await paymentRepository.ProcessPaymentAsync(payment);

        await publishEndpoint.Publish(new PaymentProcessedEvent(payment.Id, payment.BookingId, payment.Amount, payment.PaymentDate));

        return payment.Id;
    }
}
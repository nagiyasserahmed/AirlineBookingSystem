using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;

public class ProcessPaymentHandler(IPaymentRepository paymentRepository) : IRequestHandler<ProcessPaymentCommand, Guid>
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

        return payment.Id;
    }
}
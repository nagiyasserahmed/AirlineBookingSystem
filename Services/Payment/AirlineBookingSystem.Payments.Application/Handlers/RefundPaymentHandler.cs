using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;

public class RefundPaymentHandler(IPaymentRepository paymentRepository) : IRequestHandler<RefundPaymentCommand>
{
    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await paymentRepository.RefundPaymentAsync(request.PaymentId);
    }
}
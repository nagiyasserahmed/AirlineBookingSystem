using MediatR;

namespace AirlineBookingSystem.Payments.Application.Commands;

public record RefundPaymentCommand(Guid PaymentId): IRequest;
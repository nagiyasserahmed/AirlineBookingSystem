using MediatR;

namespace AirlineBookingSystem.Payments.Application.Commands;

public record ProcessPaymentCommand(Guid BookingId, decimal Amount): IRequest<Guid>;
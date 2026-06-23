using AirlineBookingSystem.Payment.Core.Entities;

namespace AirlineBookingSystem.Payment.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Payment payment);
        Task RefundPaymentAsync(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages
{
    public record PaymentProcessedEvent(Guid PaymentId, Guid BookingId, Decimal Amount, DateTime PaymentDate);
}

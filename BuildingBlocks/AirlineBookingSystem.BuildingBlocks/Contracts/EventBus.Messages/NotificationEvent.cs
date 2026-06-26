using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages
{
    public record NotificationEvent(string Recipient, string Message, string Type);
}

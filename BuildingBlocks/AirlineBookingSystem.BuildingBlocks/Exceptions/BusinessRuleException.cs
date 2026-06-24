namespace AirlineBookingSystem.BuildingBlocks.Exceptions;

public sealed class BusinessRuleException : AppException
{
    public BusinessRuleException(string message)
        : base(message)
    {
    }
}
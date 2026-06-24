namespace AirlineBookingSystem.BuildingBlocks.Exceptions;

public sealed class NotFoundException : AppException
{
    public NotFoundException(string entityName, object key)
        : base($"{entityName} with id '{key}' was not found.")
    {
    }
}
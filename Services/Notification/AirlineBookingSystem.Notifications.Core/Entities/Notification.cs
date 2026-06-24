namespace AirlineBookingSystem.Notifications.Core.Entities
{
    public class Notification
    {
        public Guid Id {get;set;}
        public string Recipient {get;set;} = string.Empty;
        public string Message {get;set;} = string.Empty;
        public string Type {get;set;} = string.Empty;
    }
}
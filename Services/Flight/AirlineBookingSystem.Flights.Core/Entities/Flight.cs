namespace AirlineBookingSystem.Flights.Core.Entities
{
     public class Flight
    {
        public Guid Id {get;set;}
        public string FlightNumber {get;set;} = string.Empty;
        public string Origin {get;set;} = string.Empty;
        public string Destination {get;set;} = string.Empty;
        public DateTime DepartureTime {get;set;}
        public DateTime ArrivalTime {get;set;}
    }
}
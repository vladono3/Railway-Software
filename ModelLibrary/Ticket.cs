using System;

namespace ModelLibrary
{
    public class Ticket
    {
        public int Id { get; set; }
        public string StartingStation { get; set; }
        public string EndStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int Price { get; set; }
        public int ClientId { get; set; }
        public TicketFeatures Features { get; set; }

        public Ticket(int id, string start, string end, DateTime depart, DateTime arrive, int price, TicketFeatures features)
        {
            Id = id;
            StartingStation = start;
            EndStation = end;
            DepartureDate = depart;
            ArrivalDate = arrive;
            Price = price;
            Features = features;
            ClientId = 0;
        }

        public string Info()
        {
            return $"Ticket #{Id}: {StartingStation} → {EndStation}, Departure: {DepartureDate}, Arrival: {ArrivalDate}, Price: {Price}, Features: {Features}";
        }
    }

}

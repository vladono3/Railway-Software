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
        public string ClientName { get; set; } // To store client's full name
        public int TrainId { get; set; }  // Train assigned to this ticket
        public TicketFeatures Features { get; set; }
        public bool IsTemplate { get; set; } // Flag to identify if this is a template ticket

        // Constructor for template tickets
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
            ClientName = "";
            TrainId = 0;
            IsTemplate = true;
        }

        // Constructor for purchased tickets (includes client details)
        public Ticket(int id, string start, string end, DateTime depart, DateTime arrive, int price,
                      TicketFeatures features, int clientId, string clientName, int trainId)
            : this(id, start, end, depart, arrive, price, features)
        {
            ClientId = clientId;
            ClientName = clientName;
            TrainId = trainId;
            IsTemplate = false;
        }

        // To clone a template ticket for a purchase
        public Ticket Clone()
        {
            return new Ticket(
                0, // New ID will be assigned
                this.StartingStation,
                this.EndStation,
                this.DepartureDate,
                this.ArrivalDate,
                this.Price,
                this.Features
            );
        }

        public string Info()
        {
            string trainInfo = TrainId > 0 ? $", Train: #{TrainId}" : ", No Train Assigned";
            string clientInfo = !string.IsNullOrEmpty(ClientName) ? $", Client: {ClientName}" : "";

            return $"Ticket #{Id}: {StartingStation} → {EndStation}, Departure: {DepartureDate}, " +
                   $"Arrival: {ArrivalDate}, Price: {Price}, Features: {Features}{trainInfo}{clientInfo}";
        }
    }
}
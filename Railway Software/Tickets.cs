using System;

namespace Railway_Software
{
    class Tickets
    {
        int id;
        string starting_station;
        string end_station;
        int client_id;
        DateTime departure_date;
        DateTime arrival_date;
        int[] connecting_routes;
        int price;

        public string ReturnTicket
        {
            get { return $"Ticket: {starting_station} to {end_station} Departures at -> {departure_date}; Arrives at -> {arrival_date}. Price -> {price} "; }
            set { }
        }

        public Tickets()
        {
            starting_station = end_station = string.Empty;
            departure_date = arrival_date = DateTime.MinValue;
            price = 0;
        }

        public Tickets(string _starting_station, string _end_station, DateTime _departure_date, DateTime _arrival_date, int _price)
        {
            starting_station = _starting_station;
            end_station = _end_station;
            departure_date = _departure_date;
            arrival_date = _arrival_date;
            client_id = 0;
            price = _price;
        }
    }
}

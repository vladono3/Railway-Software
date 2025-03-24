using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModelLibrary.Enums;

namespace ModelLibrary
{
    public class TicketsAdministration
    {
        private static string filePath = "tickets.txt";
        private static List<Ticket> tickets = new List<Ticket>();
        private static int nextTicketId = 1;

        static TicketsAdministration()
        {
            LoadTicketsFromFile(); // Load tickets when the class is initialized
        }

        public static void AddTicket(Ticket ticket)
        {
            ticket.Id = nextTicketId++;
            tickets.Add(ticket);
            SaveTicketsToFile(); 
            Console.WriteLine("Ticket added successfully!");
        }

        public static bool BuyTicket(int ticketId, int clientId)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == ticketId && t.ClientId == 0);
            if (ticket != null)
            {
                ticket.ClientId = clientId;
                SaveTicketsToFile();
                return true;
            }
            return false;
        }

        public static Ticket[] GetTickets()
        {
            return tickets.Where(t => t.ClientId == 0).ToArray(); // Available tickets
        }

        public static Ticket[] GetTicketsByClientId(int clientId)
        {
            return tickets.Where(t => t.ClientId == clientId).ToArray(); // Tickets purchased by a client
        }

        private static void SaveTicketsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var ticket in tickets)
                {
                    writer.WriteLine($"{ticket.Id},{ticket.StartingStation},{ticket.EndStation},{ticket.DepartureDate},{ticket.ArrivalDate},{ticket.Price},{ticket.ClientId},{(int)ticket.Features}");
                }
            }
        }

        private static void LoadTicketsFromFile()
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length == 8)
                {
                    try
                    {
                        int id = int.Parse(parts[0]);
                        string startingStation = parts[1];
                        string endStation = parts[2];
                        DateTime departureDate = DateTime.Parse(parts[3]);
                        DateTime arrivalDate = DateTime.Parse(parts[4]);
                        int price = int.Parse(parts[5]);
                        int clientId = int.Parse(parts[6]);
                        TicketFeatures features = (TicketFeatures)Enum.ToObject(typeof(TicketFeatures), int.Parse(parts[7]));

                        Ticket ticket = new Ticket(id, startingStation, endStation, departureDate, arrivalDate, price, features);
                        ticket.ClientId = clientId;
                        tickets.Add(ticket);

                        // Update nextTicketId to the highest ID in the file
                        if (id >= nextTicketId)
                            nextTicketId = id + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading ticket: {ex.Message}");
                    }
                }
            }
        }
    }
}

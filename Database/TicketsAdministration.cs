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
        private static List<Ticket> templateTickets = new List<Ticket>(); // Ticket templates
        private static int nextTicketId = 1;

        static TicketsAdministration()
        {
            LoadTicketsFromFile(); // Load tickets when the class is initialized
        }

        // Add a new ticket template
        public static void AddTicket(Ticket ticket)
        {
            ticket.Id = nextTicketId++;
            ticket.IsTemplate = true;
            templateTickets.Add(ticket);
            SaveTicketsToFile();
            Console.WriteLine("Ticket template added successfully!");
        }

        // For backward compatibility, maintain a GetTickets method that returns templates
        public static Ticket[] GetTickets()
        {
            return GetTicketTemplates();
        }

        // Buy a ticket based on a template
        public static bool BuyTicket(int templateTicketId, int clientId, int trainId, string clientName)
        {
            var templateTicket = templateTickets.FirstOrDefault(t => t.Id == templateTicketId);
            if (templateTicket != null)
            {
                // Create a new ticket based on the template
                Ticket purchasedTicket = new Ticket(
                    nextTicketId++,
                    templateTicket.StartingStation,
                    templateTicket.EndStation,
                    templateTicket.DepartureDate,
                    templateTicket.ArrivalDate,
                    templateTicket.Price,
                    templateTicket.Features,
                    clientId,
                    clientName,
                    trainId
                );

                tickets.Add(purchasedTicket);
                SaveTicketsToFile();
                return true;
            }
            return false;
        }

        // Assign a train to a purchased ticket
        public static bool AssignTrainToTicket(int ticketId, int trainId)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == ticketId);
            if (ticket != null)
            {
                ticket.TrainId = trainId;
                SaveTicketsToFile();
                return true;
            }
            return false;
        }

        // Get available ticket templates
        public static Ticket[] GetTicketTemplates()
        {
            return templateTickets.ToArray();
        }

        // Get all purchased tickets
        public static Ticket[] GetPurchasedTickets()
        {
            return tickets.ToArray();
        }

        // Get tickets purchased by a specific client
        public static Ticket[] GetTicketsByClientId(int clientId)
        {
            return tickets.Where(t => t.ClientId == clientId).ToArray();
        }

        private static void SaveTicketsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Save template tickets
                foreach (var ticket in templateTickets)
                {
                    writer.WriteLine($"TEMPLATE,{ticket.Id},{ticket.StartingStation},{ticket.EndStation},{ticket.DepartureDate},{ticket.ArrivalDate},{ticket.Price},{(int)ticket.Features}");
                }

                // Save purchased tickets
                foreach (var ticket in tickets)
                {
                    writer.WriteLine($"PURCHASED,{ticket.Id},{ticket.StartingStation},{ticket.EndStation},{ticket.DepartureDate},{ticket.ArrivalDate},{ticket.Price},{ticket.ClientId},{ticket.ClientName},{ticket.TrainId},{(int)ticket.Features}");
                }
            }
        }

        private static void LoadTicketsFromFile()
        {
            templateTickets.Clear();
            tickets.Clear();

            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts[0] == "TEMPLATE" && parts.Length >= 8)
                {
                    try
                    {
                        int id = int.Parse(parts[1]);
                        string startingStation = parts[2];
                        string endStation = parts[3];
                        DateTime departureDate = DateTime.Parse(parts[4]);
                        DateTime arrivalDate = DateTime.Parse(parts[5]);
                        int price = int.Parse(parts[6]);
                        TicketFeatures features = (TicketFeatures)Enum.ToObject(typeof(TicketFeatures), int.Parse(parts[7]));

                        Ticket ticket = new Ticket(id, startingStation, endStation, departureDate, arrivalDate, price, features);
                        ticket.IsTemplate = true;
                        templateTickets.Add(ticket);

                        // Update nextTicketId to the highest ID in the file
                        if (id >= nextTicketId)
                            nextTicketId = id + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading ticket template: {ex.Message}");
                    }
                }
                else if (parts[0] == "PURCHASED" && parts.Length >= 11)
                {
                    try
                    {
                        int id = int.Parse(parts[1]);
                        string startingStation = parts[2];
                        string endStation = parts[3];
                        DateTime departureDate = DateTime.Parse(parts[4]);
                        DateTime arrivalDate = DateTime.Parse(parts[5]);
                        int price = int.Parse(parts[6]);
                        int clientId = int.Parse(parts[7]);
                        string clientName = parts[8];
                        int trainId = int.Parse(parts[9]);
                        TicketFeatures features = (TicketFeatures)Enum.ToObject(typeof(TicketFeatures), int.Parse(parts[10]));

                        Ticket ticket = new Ticket(id, startingStation, endStation, departureDate, arrivalDate, price, features, clientId, clientName, trainId);
                        ticket.IsTemplate = false;
                        tickets.Add(ticket);

                        // Update nextTicketId to the highest ID in the file
                        if (id >= nextTicketId)
                            nextTicketId = id + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading purchased ticket: {ex.Message}");
                    }
                }
            }
        }
    }
}
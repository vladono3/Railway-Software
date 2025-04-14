using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using ModelLibrary;
using ModelLibrary.Enums;
using Database;
namespace Railway_Software
{
    class Program
    {
        static List<Ticket> tickets = new List<Ticket>();
        static void Main(string[] args)
        {
            int nrClients = 0;
            string fileName = ConfigurationManager.AppSettings["clients"];
            ClientsAdministration adminClients = new ClientsAdministration(fileName);

            Client newClient = new Client();
            string option;

            do
            {
                Console.WriteLine("C. Read client info from keyboard");
                Console.WriteLine("I. Show last client info saved");
                Console.WriteLine("A. Print clients from file");
                Console.WriteLine("S. Save client in array of objects");
                Console.WriteLine("T. Create a ticket");
                Console.WriteLine("V. Show available tickets");
                Console.WriteLine("B. Buy a ticket");
                Console.WriteLine("M. Show my tickets");
                Console.WriteLine("X. Close program");

                Console.WriteLine("Choose an option");
                option = Console.ReadLine();

                switch (option.ToUpper())
                {
                    case "C":
                        newClient = ReadClientInfoKeyboard();
                        break;
                    case "I":
                        PrintClient(newClient);
                        break;
                    case "A":
                        Client[] clients = adminClients.GetClients(out nrClients);
                        PrintClients(clients, nrClients);
                        break;
                    case "S":
                        int idClient = ++nrClients;
                        newClient.id = idClient;
                        adminClients.AddClient(newClient);
                        break;
                    case "T":
                        CreateTicket();
                        break;
                    case "V":
                        ShowAvailableTickets();
                        break;
                    case "B":
                        BuyTicket();
                        break;
                    case "M":
                        ShowPurchasedTickets();
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }
            } while (option.ToUpper() != "X");

            Console.ReadKey();
        }

        public static Client ReadClientInfoKeyboard()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Last name:");
            string last_name = Console.ReadLine();

            Console.WriteLine("Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Client client = new Client(name, last_name, age);
            Console.WriteLine("Choose account type:");
            Console.WriteLine("1 - Adult \n2 - Student \n3 - Children \n4 - Retired");

            int type_option = Convert.ToInt32(Console.ReadLine());
            client.accountType = (AccountType)type_option;

            return client;
        }

        public static void PrintClient(Client client)
        {
            string infoClient = string.Format("Client with id #{0} and the name: {1} {2}, age: {3}, account type: {4}",
               client.id,
               client.name ?? " UNKNOWN ",
               client.last_name ?? " UNKNOWN ",
               client.age,
               client.accountType);

            Console.WriteLine(infoClient);
        }

        public static void PrintClients(Client[] clients, int nrClients)
        {
            Console.WriteLine("Clients are:");
            for (int contor = 0; contor < nrClients; contor++)
            {
                Console.WriteLine(clients[contor].Info());
            }
        }

        public static void CreateTicket()
        {
            Console.WriteLine("Enter departure station:");
            string departure = Console.ReadLine();

            Console.WriteLine("Enter destination station:");
            string destination = Console.ReadLine();

            Console.WriteLine("Enter departure date (yyyy-MM-dd HH:mm):");
            DateTime departureDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter arrival date (yyyy-MM-dd HH:mm):");
            DateTime arrivalDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter price:");
            int price = Convert.ToInt32(Console.ReadLine());

            TicketFeatures features = TicketFeatures.None;
            Console.WriteLine("Choose ticket features (separate with commas):");
            Console.WriteLine("1 - WiFi");
            Console.WriteLine("2 - Meal Included");
            Console.WriteLine("3 - First Class");
            Console.WriteLine("4 - Sleeper Car");

            string[] selectedOptions = Console.ReadLine().Split(',');
            foreach (var option in selectedOptions)
            {
                switch (option.Trim())
                {
                    case "1":
                        features |= TicketFeatures.WiFi;
                        break;
                    case "2":
                        features |= TicketFeatures.MealIncluded;
                        break;
                    case "3":
                        features |= TicketFeatures.FirstClass;
                        break;
                    case "4":
                        features |= TicketFeatures.SleeperCar;
                        break;
                }
            }

            Ticket ticket = new Ticket(0, departure, destination, departureDate, arrivalDate, price, features);
            TicketsAdministration.AddTicket(ticket);
        }


        public static void ShowAvailableTickets()
        {
            Ticket[] availableTickets = TicketsAdministration.GetTicketTemplates();

            if (availableTickets.Length == 0)
            {
                Console.WriteLine("No tickets available.");
                return;
            }

            Console.WriteLine("Available Tickets:");

            foreach (var ticket in availableTickets)
            {
                Console.WriteLine(ticket.Info());
            }
        }


        public static void BuyTicket()
        {
            Console.WriteLine("Enter the ticket ID you want to buy:");
            int ticketId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your client ID:");
            int clientId = Convert.ToInt32(Console.ReadLine());

            bool success = TicketsAdministration.BuyTicket(ticketId, clientId, 1, "Onofrie Vlad");
            Console.WriteLine(success ? "Ticket purchased successfully!" : "Invalid ticket ID or ticket already sold.");
        }

        public static void ShowPurchasedTickets()
        {
            Console.WriteLine("Enter your client ID:");
            int clientId = Convert.ToInt32(Console.ReadLine());

            Ticket[] clientTickets = TicketsAdministration.GetTicketsByClientId(clientId);

            if (clientTickets.Length == 0)
            {
                Console.WriteLine("You have not purchased any tickets.");
                return;
            }

            Console.WriteLine($"Tickets bought by Client #{clientId}:");
            foreach (var ticket in clientTickets)
            {
                Console.WriteLine(ticket.Info());
            }
        }

       
    }
}
using System;
using System.Configuration;
using System.Dynamic;

using ModelLibrary;
using ModelLibrary.Enum;
using Database;

namespace Railway_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            int nrClients = 0;
            //Open clients database
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

            Console.WriteLine("Choose account type:");
            Console.WriteLine("1 - Adult \n" +
            "2 - Student \n" +
            "3 - Children \n" +
            "4 - Retired \n");
            int type_option = Convert.ToInt32(Console.ReadLine());

            Client client = new Client(name, last_name, age);

            client.accountType = (AccountType)type_option;
            return client;
        }

   public static void PrintClient(Client client)
        {
            string infoStudent = string.Format("Client with id #{0} and the name: {1} {2} age: {3} and account type: {4}",
               client.id,
               client.name ?? " UNKNOWN ",
               client.last_name ?? " UNKNOWN ",
               client.age,
               client.accountType);

            Console.WriteLine(infoStudent);
        }

        public static void PrintClients(Client[] clients, int nrClients)
        {
            Console.WriteLine("Clients are:");
            for (int contor = 0; contor < nrClients; contor++)
            {
                string infoClient = clients[contor].Info();
                Console.WriteLine(infoClient);
            }
        }
    }
}
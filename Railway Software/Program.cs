using System;
using System.Configuration;
using System.Dynamic;
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
                

            Client c1 = new Client("Vlad", "Onofrei", 20);

            //Client add in database
            int idStudent = ++nrClients;
            c1.id = idStudent;
            adminClients.AddStudent(c1);

            //Clients read
            Client[] clients = adminClients.GetClients(out nrClients);
            PrintClients(clients, nrClients);
            

            Tickets t1 = new Tickets("Suceava", "Bucuresti", new DateTime(2025, 02, 25, 10, 30, 0), new DateTime(2025, 02, 25, 13, 45, 0), 230);
            Console.WriteLine(t1.ReturnTicket);


        }


        public static void PrintClient(Client client)
        {
            string infoStudent = string.Format("Client with id #{0} and the name: {1} {2}",
                    client.id,
                    client.name ?? " UNKNOWN ",
                    client.last_name ?? " UNKNOWN ");

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

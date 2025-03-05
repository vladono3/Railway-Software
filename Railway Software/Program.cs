using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Railway_Software.Client;
using static Railway_Software.Tickets;
namespace Railway_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("Vlad", "Onofrei", 20);
            Console.WriteLine(c1.ReturnClient);

            Tickets t1 = new Tickets("Suceava", "Bucuresti", new DateTime(2025, 02, 25, 10, 30, 0), new DateTime(2025, 02, 25, 13, 45, 0), 230);
            Console.WriteLine(t1.ReturnTicket);
        }
    }
}

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

            Tickets t1 = new Tickets("Suceava", "Bucuresti", 1741283548, 1741161001, 230);
            Console.WriteLine(t1.ReturnTicket);
        }
    }
}

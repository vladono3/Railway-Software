using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Railway_Software.Client;
using static Railway_Software.Employee;
namespace Railway_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("Vlad", "Onofrei", 20);
            c1.PrintClient();

            Employee e1 = new Employee("Ruth", "Candi", 20);
            e1.PrintClient();
        }
    }
}

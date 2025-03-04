using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Railway_Software
{
    class Employee
    {
        int id;
        string name;
        string last_name;
        int age;

        public void PrintClient()
        {
            Console.WriteLine($"Employee: {name} {last_name} age: {age}");
        }

        public Employee()
        {
            name = last_name = string.Empty;
            age = 0;
        }

        public Employee(string _name, string _last_name, int _age)
        {
            name = _name;
            last_name = _last_name;
            age = _age;
        }
    }
}

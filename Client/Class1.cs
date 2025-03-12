using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Railway_Software
{
    class Client
    {
        int id;
        string name;
        string last_name;
        int age;

        public string GetFullName
        {
            get { return name + " " + last_name; }
            set { }
        }

        public string ReturnClient
        {
            get { return $"Client: {name} {last_name} age: {age}"; }
            set { }
        }

        public Client()
        {
            name = last_name = string.Empty;
            age = 0;
        }

        public Client(string _name, string _last_name, int _age)
        {
            name = _name;
            last_name = _last_name;
            age = _age;
        }
    }
}

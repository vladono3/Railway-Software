using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Railway_Software
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID = 0;
        private const int NAME = 1;
        private const int LAST_NAME = 2;

        public int id;
        public string name;
        public string last_name;
        public int age;

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

        public string Info()
        {
            string info = $"Id:{id} Name:{name ?? " UNKNOWN "} Last Name: {last_name ?? " UNKNOWN "}";

            return info;
        }

        public Client()
        {
            name = last_name = string.Empty;
            age = 0;
        }

        public string FileStringConversion()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                id.ToString(),
                (name ?? " UNKNOWN "),
                (last_name ?? " UNKNOWN "));

            return obiectStudentPentruFisier;
        }

        public Client(string fileLine)
        {
            var dateFisier = fileLine.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.id = Convert.ToInt32(dateFisier[ID]);
            this.name = dateFisier[NAME];
            this.last_name = dateFisier[LAST_NAME];
        }

        public Client(string _name, string _last_name, int _age)
        {
            name = _name;
            last_name = _last_name;
            age = _age;
        }
    }
}

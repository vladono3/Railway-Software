using ModelLibrary.Enums;
using System;

namespace ModelLibrary
{
    public class Client
    {
        private const char FILE_SEPARATOR = ';';
        private const int ID = 0;
        private const int NAME = 1;
        private const int LAST_NAME = 2;
        private const int AGE = 3;
        private const int ACCOUNT_TYPE = 4;


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

        public AccountType accountType { get; set; }

        public string Info()
        {
            string info = $"Id:{id} Name:{name ?? " UNKNOWN "} Last Name: {last_name ?? " UNKNOWN "} Age: {age}, Account Type: {accountType}";

            return info;
        }

        public Client()
        {
            name = last_name = string.Empty;
            age = 0;
        }

        public string FileStringConversion()
        {
            string objectClientFile = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                FILE_SEPARATOR,
                id.ToString(),
                (name ?? " UNKNOWN "),
                (last_name ?? " UNKNOWN "),
                age.ToString(),
                accountType);
            return objectClientFile;
        }

        public Client(string fileLine)
        {
            var fileData = fileLine.Split(FILE_SEPARATOR);

            this.id = Convert.ToInt32(fileData[ID]);
            this.name = fileData[NAME];
            this.last_name = fileData[LAST_NAME];
            this.age = Convert.ToInt32(fileData[AGE]);
            this.accountType = (AccountType)Enum.Parse(typeof(AccountType), fileData[ACCOUNT_TYPE]);
        }

        public Client(string _name, string _last_name, int _age)
        {
            name = _name;
            last_name = _last_name;
            age = _age;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLibrary;

namespace Database
{
    public class ClientsAdministration
    {
        private const int MAX_CLIENTS = 50;
        private string fileName;

        public ClientsAdministration(string fileName)
        {
            this.fileName = fileName;
            Stream streamFisierText = File.Open(fileName, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Client client)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(fileName, true))
            {
                streamWriterFisierText.WriteLine(client.FileStringConversion());
            }
        }

        public Client[] GetClients(out int nrClients)
        {
            Client[] studenti = new Client[MAX_CLIENTS];
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string linieFisier;
                nrClients = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    studenti[nrClients++] = new Client(linieFisier);
                }
            }

            return studenti;
        }
    }
}

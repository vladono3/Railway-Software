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
            Console.WriteLine(client.accountType);
            using (StreamWriter streamWriterFisierText = new StreamWriter(fileName, true))
            {
                streamWriterFisierText.WriteLine(client.FileStringConversion());
            }
        }

        public Client[] GetClients(out int nrClients)
        {
            // Initialize the array to store up to MAX_CLIENTS
            Client[] studenti = new Client[MAX_CLIENTS];
            nrClients = 0;
            try
            {
                // Open the file to read the clients
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string linieFisier;

                    // Read each line from the file
                    while ((linieFisier = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(linieFisier))
                        {
                            // Add the client if there's space available in the array
                            if (nrClients < MAX_CLIENTS)
                            {
                                studenti[nrClients++] = new Client(linieFisier);
                            }
                            else
                            {
                                // If MAX_CLIENTS is reached, break the loop
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading client data: {ex.Message}");
            }

            // Return only the initialized portion of the array (non-null clients)
            return studenti.Take(nrClients).ToArray();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModelLibrary
{
    public class TrainAdministration
    {
        private static string filePath = "trains.txt";
        private List<Train> trains = new List<Train>();
        private int nextTrainId = 1;

        public TrainAdministration()
        {
            LoadTrainsFromFile(); // Load trains when the class is initialized
        }

        public void AddTrain(Train train)
        {
            train.Id = nextTrainId++;
            trains.Add(train);
            SaveTrainsToFile();
            Console.WriteLine("Train added successfully!");
        }

        public Train[] GetTrains()
        {
            return trains.ToArray();
        }

        private void SaveTrainsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var train in trains)
                {
                    writer.WriteLine($"{train.Id},{train.Name},{train.Seats},{train.Wagons},{(int)train.FuelType}");
                }
            }
        }

        private void LoadTrainsFromFile()
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length == 5)
                {
                    try
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        int seats = int.Parse(parts[2]);
                        int wagons = int.Parse(parts[3]);
                        FuelType fuelType = (FuelType)Enum.ToObject(typeof(FuelType), int.Parse(parts[4]));

                        Train train = new Train(id, name, seats, wagons, fuelType);
                        trains.Add(train);

                        // Update nextTrainId to the highest ID in the file
                        if (id >= nextTrainId)
                            nextTrainId = id + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading train: {ex.Message}");
                    }
                }
            }
        }
    }
}
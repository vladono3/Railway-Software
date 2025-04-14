using System;

namespace ModelLibrary
{
    public enum FuelType
    {
        Diesel = 1,
        Gasoline = 2
    }

    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int Wagons { get; set; }
        public FuelType FuelType { get; set; }

        public Train(int id, string name, int seats, int wagons, FuelType fuelType)
        {
            Id = id;
            Name = name;
            Seats = seats;
            Wagons = wagons;
            FuelType = fuelType;
        }

        public string Info()
        {
            return $"Train #{Id}: {Name}, Seats: {Seats}, Wagons: {Wagons}, Fuel: {FuelType}";
        }
    }
}
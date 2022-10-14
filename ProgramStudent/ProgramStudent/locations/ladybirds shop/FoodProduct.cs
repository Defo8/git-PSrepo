using System;

namespace ProgramStudent
{
    class FoodProduct : IProduct
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime ValidDate { get; set; }
        public int FoodValue { get; }
        public int Amount { get; set; }
        public double Mass { get; set; }

        public FoodProduct(string name, double cost, DateTime date, int value, double mass = 1, int amount = 1)
        {
            Name = name;
            Cost = cost;
            ValidDate = date;
            FoodValue = value;
            Mass = mass;
            Amount = amount;

        }
    }
}

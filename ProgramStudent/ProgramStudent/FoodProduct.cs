using System;

namespace ProgramStudent
{
    class FoodProduct : IProduct
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime ValidDate { get; set; }
        public int FoodValue { get; set; }

        public FoodProduct(string name, double cost, DateTime date, int value)
        {
            Name = name;
            Cost = cost;
            ValidDate = date;
            FoodValue = value;
        }
    }
}

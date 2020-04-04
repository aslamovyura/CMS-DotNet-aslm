using System;
namespace SimpleStore
{
    public class CatchweightProduct : Product
    {
        public double Weight { get; set; }

        public CatchweightProduct() { }

        public CatchweightProduct(string name, double price, int code, double weight)
            : base(name, price, code) => Weight = weight;

        public CatchweightProduct(string name, double price, int code, string manufacturer, double weight)
            : base(name, price, code, manufacturer) => Weight = weight;

        public override void Print()
        {
            Console.WriteLine($"Product: {Name},  price : {Price}$ ({Weight} kg),  manufacturer: {Manufacturer}");
        }
    }
}

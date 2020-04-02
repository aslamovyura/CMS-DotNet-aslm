using System;

namespace SimpleStore
{
    public class Milk : CatchweightProduct
    {
        public override string Name => "Milk";
        public double Volume { get; set; } = 1;
        public double FatContent { get; set; } = 7.5;
        

        public Milk() {}
        public Milk(double price, int code, string manufacturer, double volume, double fatContent)
            : base("Milk", price, code, manufacturer, 0)
        {
            Volume = volume;
            FatContent = fatContent;
        }

        public override void Print()
        {
            Console.WriteLine($"Product: {Name}, fat content: {FatContent}, " +
                              $"  price : {Price}$ ({Volume} l )," +
                              $"  manufacturer: {Manufacturer}");
        }
    }

}

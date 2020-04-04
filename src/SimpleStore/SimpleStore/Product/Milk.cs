using System;

namespace SimpleStore
{
    public class Milk : CatchweightProduct
    {
        /// <summary>
        /// Milk name.
        /// </summary>
        public override string Name => "Milk";

        /// <summary>
        /// Volume of milk pack, [liter].
        /// </summary>
        public double Volume { get; set; } = 1;

        /// <summary>
        /// Milk fat content, [%].
        /// </summary>
        public double FatContent { get; set; } = 7.5;
        
        public Milk() {}

        /// <summary>
        /// Constructor of milk product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="volume">Pack volume, lit.</param>
        /// <param name="fatContent">Fat content, %.</param>
        public Milk(double price, int code, string manufacturer, double volume, double fatContent)
            : base("Milk", price, code, manufacturer, 0)
        {
            Volume = volume;
            FatContent = fatContent;
        }

        public override void Print()
        {
            Console.WriteLine($"Product: {Name}, fat content: {FatContent},  price : {Price}$ ({Volume} l ),  manufacturer: {Manufacturer}");
        }
    }
}

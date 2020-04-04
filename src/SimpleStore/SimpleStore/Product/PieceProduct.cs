using System;
namespace SimpleStore
{
    public class PieceProduct : Product
    {
        /// <summary>
        /// Number of units in pack.
        /// </summary>
        public int Number { get; set; } = 1;

        public PieceProduct() { }

        /// <summary>
        /// Constructor of piece product.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        public PieceProduct(string name, double price, int code)
            : base(name, price, code) { }

        /// <summary>
        /// Constructor of piece product.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        public PieceProduct(string name, double price, int code, string manufacturer)
            : base(name, price, code, manufacturer){ }

        /// <summary>
        /// Constructor of piece product.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="number">Number of units in pack.</param>
        public PieceProduct(string name, double price, int code, int number)
            : base(name, price, code) => Number = number;

        /// <summary>
        /// Constructor of piece product.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number of units in pack.</param>
        public PieceProduct(string name, double price, int code, string manufacturer, int number)
            : base(name, price, code, manufacturer) => Number = number;

        /// <summary>
        /// Print product info to console.
        /// </summary>
        public override void Print()
        {
            Console.WriteLine($"Product: {Name}, price : {Price}$ ({Number} units)," +
                              $"  manufacturer: {Manufacturer}");
        }
    }
}

using System;
namespace SimpleStore
{
    public class Bread : PieceProduct
    {
        /// <summary>
        /// Bread name.
        /// </summary>
        public override string Name => "Bread";

        public Bread() { }

        /// <summary>
        /// Constructor of bread product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        public Bread(double price, int code, string manufacturer)
            : base("Bread", price, code, manufacturer) { }

        /// <summary>
        /// Constructor of bread product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number units for the Price.</param>
        public Bread(double price, int code, string manufacturer, int number)
            : base("Bread", price, code, manufacturer, number) { }
    }
}

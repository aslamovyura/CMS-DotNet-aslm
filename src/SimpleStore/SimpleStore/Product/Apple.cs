using System;
namespace SimpleStore
{
    public class Apple : CatchweightProduct
    {
        /// <summary>
        /// Apple name.
        /// </summary>
        public override string Name => "Apple";       

        public Apple() {}

        /// <summary>
        /// Constructor of apple product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        public Apple(double price, int code, string manufacturer)
            : base("Apple", price, code, manufacturer, 0) { }
    }
}

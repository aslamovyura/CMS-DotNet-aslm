using System;
namespace SimpleStore
{
    public class Sugar : CatchweightProduct
    {
        /// <summary>
        /// Product name.
        /// </summary>
        public override string Name => "Sugar";       

        public Sugar() {}

        /// <summary>
        /// Constructor of sugar product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        public Sugar(double price, int code, string manufacturer)
            : base("Sugar", price, code, manufacturer, 0) { }
    }
}

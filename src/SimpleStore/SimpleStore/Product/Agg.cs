using System;
namespace SimpleStore
{
    public class Agg : PieceProduct
    {
        /// <summary>
        /// Agg name.
        /// </summary>
        public override string Name => "Agg";

        /// <summary>
        /// Average size of single agg.
        /// </summary>
        public Size Size { get; set; } = Size.Medium;

        /// <summary>
        /// Agg color.
        /// </summary>
        public Color Color { get; set; } = Color.White;

        public Agg() { }

        /// <summary>
        /// Constructor of agg product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number of aggs in pack.</param>
        public Agg(double price, int code, string manufacturer, int number)
            : base("Agg", price, code, manufacturer, number) { }

        /// <summary>
        /// Constructor of agg product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number of aggs in pack.</param>
        /// <param name="color">Agg color.</param>
        public Agg(double price, int code, string manufacturer, int number, Color color)
            : base("Agg", price, code, manufacturer, number) => Color = color;

        /// <summary>
        /// Constructor of agg product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number of aggs in pack.</param>
        /// <param name="size">Agg size.</param>
        public Agg(double price, int code, string manufacturer, int number, Size size)
            : base("Agg", price, code, manufacturer, number) => Size = size;

        /// <summary>
        /// Constructor of agg product.
        /// </summary>
        /// <param name="price">Price, $.</param>
        /// <param name="code">Hash code.</param>
        /// <param name="manufacturer">Manufacturer.</param>
        /// <param name="number">Number of aggs in pack.</param>
        /// <param name="color">Agg color.</param>
        /// <param name="size">Agg size.</param>
        public Agg(double price, int code, string manufacturer, int number, Color color, Size size)
            : base("Agg", price, code, manufacturer, number)
        {
            Color = color;
            Size = size;
        }
    }

    /// <summary>
    /// Agg color.
    /// </summary>
    public enum Color
    {
        Red,
        Green,
        Yellow,
        Blue,
        Grey,
        Black,
        White
    }

    /// <summary>
    /// Agg size.
    /// </summary>
    public enum Size
    {
        Small,
        Medium,
        Large
    }
}
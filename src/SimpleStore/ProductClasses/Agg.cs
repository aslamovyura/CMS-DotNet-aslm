using System;
namespace SimpleStore
{
    public class Agg : PieceProduct
    {
        public override string Name => "Agg";
        public Size Size { get; set; } = Size.Medium;
        public Color Color { get; set; } = Color.White;

        public Agg() { }

        public Agg(double price, int code, string manufacturer, int number)
            : base("Agg", price, code, manufacturer, number) { }

        public Agg(double price, int code, string manufacturer, int number, Color color)
            : base("Agg", price, code, manufacturer, number) => Color = color;

        public Agg(double price, int code, string manufacturer, int number, Size size)
            : base("Agg", price, code, manufacturer, number) => Size = size;

        public Agg(double price, int code, string manufacturer, int number,
                   Color color, Size size)
            : base("Agg", price, code, manufacturer, number)
        {
            Color = color;
            Size = size;
        }

    }


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

    public enum Size
    {
        Small,
        Medium,
        Large
    }

}

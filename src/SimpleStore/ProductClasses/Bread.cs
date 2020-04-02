using System;
namespace SimpleStore
{
    public class Bread : PieceProduct
    {
        public override string Name => "Bread";

        public Bread() { }

        public Bread(double price, int code, string manufacturer)
            : base("Bread", price, code, manufacturer) { }

        public Bread(double price, int code, string manufacturer, int number)
            : base("Bread", price, code, manufacturer, number) { }
    }
}

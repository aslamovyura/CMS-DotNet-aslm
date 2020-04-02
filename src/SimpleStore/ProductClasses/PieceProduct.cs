using System;
namespace SimpleStore
{
    public class PieceProduct : Product
    {
        public int Number { get; set; } = 1;

        public PieceProduct() { }

        public PieceProduct(string name, double price, int code)
            : base(name, price, code) { }

        public PieceProduct(string name, double price, int code,
                            string manufacturer)
            : base(name, price, code, manufacturer){ }

        public PieceProduct(string name, double price, int code,
                                  int number)
            : base(name, price, code) => Number = number;

        public PieceProduct(string name, double price, int code,
                                  string manufacturer, int number)
            : base(name, price, code, manufacturer) => Number = number;


        public override void Print()
        {
            Console.WriteLine($"Product: {Name}, price : {Price}$ ({Number} units)," +
                              $"  manufacturer: {Manufacturer}");
        }
    }
}

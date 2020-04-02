using System;

namespace SimpleStore
{
    public class Apple : CatchweightProduct
    {
        public override string Name => "Apple";       

        public Apple() {}
        public Apple(double price, int code, string manufacturer)
            : base("Apple", price, code, manufacturer, 0) { }

    }

}

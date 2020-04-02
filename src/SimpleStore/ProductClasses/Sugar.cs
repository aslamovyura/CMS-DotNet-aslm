using System;

namespace SimpleStore
{
    public class Sugar : CatchweightProduct
    {
        public override string Name => "Sugar";       

        public Sugar() {}
        public Sugar(double price, int code, string manufacturer)
            : base("Sugar", price, code, manufacturer, 0) { }

    }

}

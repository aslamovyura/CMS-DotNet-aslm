using System;
namespace SimpleStore
{
    public class Product
    {
        /// <summary>
        /// Price.
        /// </summary>
        private double _price = 0;

        /// <summary>
        /// Hash code.
        /// </summary>
        private int _code = 0;

        /// <summary>
        /// Product name
        /// </summary>
        public virtual string Name { get; set; } = "Empty";

        /// <summary>
        /// Product price, $.
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                    _price = value;
                else if (value == 0)
                {
                    Console.WriteLine("Price connot be equal to 0!");
                    _price = 0;
                }
                else
                {
                    Console.WriteLine("Price connot be negative!");
                    _price = 0;
                }
            }
        }

        /// <summary>
        /// Product hash code.
        /// </summary>
        public int Code
        {
            get => _code;
            set
            {
                if (value > 0)
                    _code = value;
                else if (value == 0)
                {
                    Console.WriteLine("Hash code connot be equal to 0!");
                    _code = 0;
                }
                else
                {
                    Console.WriteLine("Hash code connot be negative!");
                    _code = 0;
                }
            }
        }

        /// <summary>
        /// Product manufacturer
        /// </summary>
        public string Manufacturer { get; set; } = "Unknown";

        /// <summary>
        /// Constructor of the Product class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Constructor of the Product class.
        /// </summary>
        /// <param name="name">name </param>
        /// <param name="price">price, $</param>
        /// <param name="code">hash code</param>
        public Product(string name, double price, int code)
        {
            Name = name;
            Price = price;
            Code = code;
            Manufacturer = "Unknown";
        }

        /// <summary>
        /// Constructor of the Product class.
        /// </summary>
        /// <param name="name">name </param>
        /// <param name="price">price, $</param>
        /// <param name="code">hash code</param>
        /// <param name="manufacturer">manufacturer</param>
        public Product (string name, double price, int code,
                        string manufacturer)
        {
            Name = name;
            Price = price;
            Code = code;
            Manufacturer = manufacturer;
        }

        /// <summary>
        /// Return the price of the product, $.
        /// </summary>
        /// <returns></returns>
        public double GetPrice() => Price;

        /// <summary>
        /// Return hash code of the product.
        /// </summary>
        /// <returns></returns>
        public int GetCode() => Code;

        /// <summary>
        /// Print product info to console.
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine($"Product: {Name},  price: {Price},  manufacturer: {Manufacturer}");
        }

        /// <summary>
        /// Convert product parameters to string.
        /// </summary>
        /// <returns>String info.</returns>
        public override string ToString()
        {
            return $"Product: {Name},  price: {Price},  manufacturer: {Manufacturer}";
        }
    }
}

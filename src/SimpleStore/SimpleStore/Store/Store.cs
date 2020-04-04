using System;
using System.Collections;
namespace SimpleStore
{
    public class Store
    {
        /// <summary>
        /// Products storage.
        /// </summary>
        private ArrayList Storage { get; set; } = new ArrayList();

        /// <summary>
        /// Constuctor of store.
        /// </summary>
        public Store() { }

        /// <summary>
        /// Add new product to the storage.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="number">Number of products.</param>
        public void AddProduct(Product product, int number)
        {
            StorageUnit newUnit = new StorageUnit(product, number);
            Storage.Add(newUnit);
        }

        /// <summary>
        /// Calculate total price of all someProducts in the store.
        /// </summary>
        /// <param name="someProduct"></param>
        /// <returns>Total price, $.</returns>
        public double GetTotalPrice(StorageUnit someProduct)
        {
            if (someProduct != null)
                return someProduct.Product.Price * someProduct.Number;
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Calculate total price of all products in the store.
        /// </summary>
        /// <returns>Total price, $.</returns>
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (StorageUnit unit in Storage)
                totalPrice += GetTotalPrice(unit);
            return totalPrice;
        }

        /// <summary>
        /// Check is storage is empty.
        /// </summary>
        /// <returns>Boolean status.</returns>
        public bool IsEmpty() => Storage.Count>0 ? false : true;

        /// <summary>
        /// Print to console info about all products in the store.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"**************** Store ****************");
            Console.WriteLine($"|   Product  |   Price,$   |   Number  |");
            Console.WriteLine($"|--------------------------------------|");

            foreach (StorageUnit unit in Storage)
                Console.WriteLine("|{0,12}|{1,12}|{2,12}|", unit.Product.Name, unit.Product.Price, unit.Number);

            Console.WriteLine($"|--------------------------------------|");
            double totalPrice = GetTotalPrice();
            Console.WriteLine($"  Total Price: {totalPrice} $\n");
        }
    }
}

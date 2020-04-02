using System;
using System.Collections;

namespace SimpleStore.StoreClasses
{
    public class Store
    {

        private ArrayList Storage { get; set; } = new ArrayList();

        public Store() { }

        public void AddProduct(Product product, int number)
        {
            StorageUnit newUnit = new StorageUnit(product, number);
            Storage.Add(newUnit);
        }


        public double GetTotalPrice(StorageUnit unit)
        {
            if (unit != null)
                return unit.Product.Price * unit.Number;
            else
                throw new ArgumentNullException();
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (StorageUnit unit in Storage)
                totalPrice += GetTotalPrice(unit);
            return totalPrice;
        }

        public bool IsEmpty() => Storage.Count>0 ? false : true;


        public void Print()
        {
            Console.WriteLine($"**************** Store ****************");
            Console.WriteLine($"|   Product  |   Price,$   |   Number  |");
            Console.WriteLine($"|--------------------------------------|");
            foreach (StorageUnit unit in Storage)
            {
                Console.WriteLine("|{0,12}|{1,12}|{2,12}|",
                                  unit.Product.Name, unit.Product.Price, unit.Number);
                                  
            }
            Console.WriteLine($"|--------------------------------------|");
            double totalPrice = GetTotalPrice();
            Console.WriteLine($"  Total Price: {totalPrice} $\n");
        }
    }
}

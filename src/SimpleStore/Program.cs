using System;
using SimpleStore.StoreClasses;

namespace SimpleStore
{
    class Program
    {
        static void Main(string[] args)
        {

            Store myStore = new Store();

            // Add aggs to store
            int aggCode = HashCode.Combine(1, 2, 3, 4, 2, 3, 4, 5);
            Agg myAgg = new Agg(5, aggCode, "Agg Corp.", 10, Color.Grey);
            myStore.AddProduct(myAgg, 20);

            // Add apples to store
            int appleCode = HashCode.Combine(2, 2, 3, 4, 2, 3, 4, 5);
            Apple myApple = new Apple(3.5, appleCode, "Apple Inc.");
            myStore.AddProduct(myApple, 100);

            // Add bread to store
            int breadCode = HashCode.Combine(2, 2, 5, 4, 4, 3, 4, 5);
            Bread myBread = new Bread(6, breadCode, "Tom's Bakery");
            myStore.AddProduct(myBread, 35);

            // Add sugar to store
            int sugarCode = HashCode.Combine(2, 2, 3, 4, 2, 9, 8, 5);
            Sugar mySugar = new Sugar(2.5, sugarCode, "BelSugar");
            myStore.AddProduct(mySugar, 55);

            // Add sugar to store
            int milkCode = HashCode.Combine(9, 2, 1, 4, 2, 3, 4, 3);
            Milk myMilk = new Milk(2.5, milkCode, "BestMilk Inc.", 1.0, 12.5);
            myStore.AddProduct(myMilk, 67);

            // Show all product in the store
            myStore.Print();


        }
    }
}

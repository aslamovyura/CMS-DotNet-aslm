using System;
namespace StoreCashBoxes
{
    /// <summary>
    /// Customer in the store.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of goods in customer basket.
        /// </summary>
        public int Basket { get; private set; } = 0;

        /// <summary>
        /// Default constructor of Customer.
        /// </summary>
        public Customer() => PutGoodsToBasket();

        /// <summary>
        /// Put random number of goods to the customer basket.
        /// </summary>
        public void PutGoodsToBasket()
        {
            Random random = new Random();
            Basket = random.Next(0, 10);
        }

        /// <summary>
        /// Check if customer basket is empty.
        /// </summary>
        /// <returns>True, if basket is empty.</returns>
        public bool IsEmpty() => (Basket == 0) ? true : false;
    }
}
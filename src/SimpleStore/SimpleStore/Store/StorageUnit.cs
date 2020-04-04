using System;
namespace SimpleStore
{
    /// <summary>
    /// Define a unit in the SimpleStore storage.
    /// </summary>
    public class StorageUnit : IComparable
    {
        /// <summary>
        /// Product unit.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Number of products of the same class.
        /// </summary>
        public int Number { get; set; } = 0;

        /// <summary>
        /// Constructor of the storage unit.
        /// </summary>
        /// <param name="product">Product to store.</param>
        /// <param name="number">Number of products.</param>
        public StorageUnit(Product product, int number)
        {
            Product = product;
            Number = number;
        }

        /// <summary>
        /// Define comparison of the products in storage by their number.
        /// </summary>
        /// <param name="obj">Product</param>
        /// <returns>Integer value.</returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj is StorageUnit temp)
            {
                if (this.Number > temp.Number)
                    return 1;
                else if (this.Number < temp.Number)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Object is not a StoreUnit!");
        }
    }
}

using System;

namespace SimpleStore.StoreClasses
{
    public class StorageUnit : IComparable
    {
        public Product Product { get; set; }
        public int Number { get; set; } = 0;

        public StorageUnit(Product product, int number)
        {
            Product = product;
            Number = number;
        }

        int IComparable.CompareTo(object obj)
        {
            StorageUnit temp = obj as StorageUnit;

            if (temp != null)
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

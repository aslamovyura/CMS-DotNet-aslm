using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StoreCashBoxes
{
    /// <summary>
    /// Class to simulate real store, where customers are entering, buying the goods
    /// and being managed in the cash boxes.
    /// </summary>
    public class Store
    {
        // Thread for customers management.
        private Thread _thread;

        // Thread locker object.
        private object _locker = new object();

        // Customers generator.
        private CustomerGenerator _customerGenerator;

        /// <summary>
        /// An average time interval (ms) to generate new customer.
        /// </summary>
        public int CustomerGenerationTimeInterval { get; private set; } = 5000;

        /// <summary>
        /// The number (<30) of regular cash boxes to manage customers with >3 good units.
        /// </summary>
        public int CashBoxesNumber { get; private set; } = 10;

        /// <summary>
        /// The number  (<5) of fast cash boxes to manage customers with <=3 good units.
        /// </summary>
        public int FastCashBoxesNumber { get; private set; } = 1;

        /// <summary>
        /// Customers in the store.
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();

        /// <summary>
        /// Cash boxes in the store to manage customers with >3 good units.
        /// </summary>
        public List<CashBox> CashBoxes { get; set; } = new List<CashBox>();

        /// <summary>
        /// Fast cash boxes in the store to manage customers with <=3 good units.
        /// </summary>
        public List<FastCashBox> FastCashBoxes { get; set; } = new List<FastCashBox>();

        /// <summary>
        /// Default store constructor.
        /// </summary>
        public Store()
        {
            _customerGenerator = new CustomerGenerator(_locker)
            {
                GenerationTimeInterval = CustomerGenerationTimeInterval
            };
        }

        /// <summary>
        /// Store constructor.
        /// </summary>
        /// <param name="cashBoxesNumber">The number of cash boxes in the store.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Store(int cashBoxesNumber)
        {
            if (cashBoxesNumber <= 0 || cashBoxesNumber >= 30)
                throw new ArgumentOutOfRangeException("Invalid cash boxes number!");

            CashBoxesNumber = cashBoxesNumber;
            _customerGenerator = new CustomerGenerator(_locker)
            {
                GenerationTimeInterval = CustomerGenerationTimeInterval
            };
        }

        /// <summary>
        /// Store constructor.
        /// </summary>
        /// <param name="cashBoxesNumber">The number of cash boxes in the store.</param>
        /// <param name="fastCashBoxesNumber">The number of fast cash boxes.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Store(int cashBoxesNumber, int fastCashBoxesNumber)
        {
            if (cashBoxesNumber <= 0 || cashBoxesNumber >= 30)
                throw new ArgumentOutOfRangeException("Invalid cash boxes number!");

            if (fastCashBoxesNumber < 0 || fastCashBoxesNumber >= 5)
                throw new ArgumentOutOfRangeException("Invalid fast cash boxes number!");

            CashBoxesNumber = cashBoxesNumber;
            FastCashBoxesNumber = fastCashBoxesNumber;
            _customerGenerator = new CustomerGenerator(_locker)
            {
                GenerationTimeInterval = CustomerGenerationTimeInterval
            };
        }

        /// <summary>
        /// Store constructor.
        /// </summary>
        /// <param name="cashBoxesNumber">The number of cash boxes in the store.</param>
        /// <param name="fastCashBoxesNumber">The number of fast cash boxes.</param>
        /// <param name="customerGenerationTimeInterval">Interval to generate new customer in the store.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Store(int cashBoxesNumber, int fastCashBoxesNumber, int customerGenerationTimeInterval)
        {
            if (cashBoxesNumber <= 0 || cashBoxesNumber >= 30)
                throw new ArgumentOutOfRangeException("Invalid cash boxes number!");

            if (fastCashBoxesNumber < 0 || fastCashBoxesNumber >= 5)
                throw new ArgumentOutOfRangeException("Invalid fast cash boxes number!");

            if (customerGenerationTimeInterval < 0 && customerGenerationTimeInterval != Timeout.Infinite)
                throw new ArgumentOutOfRangeException("Invalid customer generation time interval!");

            CashBoxesNumber = cashBoxesNumber;
            FastCashBoxesNumber = fastCashBoxesNumber;
            CustomerGenerationTimeInterval = customerGenerationTimeInterval;

            _customerGenerator = new CustomerGenerator(_locker)
            {
                GenerationTimeInterval = CustomerGenerationTimeInterval
            };
        }

        /// <summary>
        /// Set the interval (ms) for generation customers in the store.
        /// </summary>
        /// <param name="timeInterval">Time interval (ms) for customers generation.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCustomerGenerationTimeInterval(int timeInterval)
        {
            if (timeInterval > 0 || timeInterval == Timeout.Infinite)
                CustomerGenerationTimeInterval = timeInterval;
            else
                throw new ArgumentOutOfRangeException();

            _customerGenerator.GenerationTimeInterval = CustomerGenerationTimeInterval;
        }

        /// <summary>
        /// Open store for customers.
        /// </summary>
        public void Open()
        {
            Console.WriteLine("\nStore is open.\n");
            OpenCashBoxes();

            _customerGenerator.Reset();
            _customerGenerator.GenerationTimeInterval = CustomerGenerationTimeInterval;
            _customerGenerator.Start(Customers);

            _thread = new Thread(DictributeCustomersInQueues);
            _thread.Start(Customers);
        }

        /// <summary>
        /// Close store for customers.
        /// </summary>
        public void Close()
        {
            _customerGenerator.Stop();
            Console.WriteLine($"\nStore is closing... Wait for all customers to leave the store!\n");

            // Wait for the customers to leave the store.
            while (IsAnyCustomerInStore())
            {
                Thread.Sleep(1000); 
            }

            CloseCashBoxes();
            Console.WriteLine("Store is closed!");
        }

        // Create the number of cash boxes.
        private void OpenCashBoxes()
        {
            for (int i=0; i< CashBoxesNumber; i++)
            {
                CashBoxes.Add(new CashBox() { Name = $"Cash box #{i}"});
            }

            for (int j = 0; j < FastCashBoxesNumber; j++)
            {
                FastCashBoxes.Add(new FastCashBox() { Name = $"Fast cash box #{j}" });
            }
        }

        // Close all cash boxes in the store.
        private void CloseCashBoxes()
        {
            CashBoxes.Clear();
            FastCashBoxes.Clear();
        }

        /// <summary>
        /// Check if there are some customers in the store.
        /// </summary>
        /// <returns>True, if any customer is in the store.</returns>
        public bool IsAnyCustomerInStore()
        {
            bool isAnyNotInQueue = Customers.Count > 0;
            bool isAnyInQueue = Convert.ToBoolean(CashBoxes.Any(c => c.IsEmpty() == false));
            bool isAnyInFastQueue = Convert.ToBoolean(FastCashBoxes.Any(c => c.IsEmpty() == false));
            return isAnyInQueue || isAnyInFastQueue || isAnyNotInQueue;
        }

        /// <summary>
        /// Distribute customers in the store at the cash boxes in a random order.
        /// </summary>
        /// <param name="obj">List of customers.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public void DictributeCustomersInQueues(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (!(obj is List<Customer> customers))
                throw new InvalidCastException("Object should be a List of Customers!");

            Random random = new Random();

            while (true)
            {
                lock (_locker)
                {
                    // Push new single customer to the random cash box.
                    if (customers.Count > 0)
                    {
                        if (FastCashBoxes.Count == 0)
                        {
                            int index = random.Next(0, CashBoxes.Count);
                            CashBoxes[index].AddNewCustomer(customers[0]);
                            customers.RemoveAt(0);
                        }
                        else
                        {
                            if (customers[0].Basket > 3)
                            {
                                int index = random.Next(0, CashBoxes.Count);
                                CashBoxes[index].AddNewCustomer(customers[0]);
                            }
                            else
                            {
                                int index = random.Next(0, FastCashBoxes.Count);
                                FastCashBoxes[index].AddNewCustomer(customers[0]);
                            }
                            customers.RemoveAt(0);
                        }
                    }
                }
                Thread.Sleep(50);
            }
        }
    }
}
using System;
using System.Threading;
using System.Collections.Generic;

namespace StoreCashBoxes
{
    /// <summary>
    /// Store cash box.
    /// </summary>
    public class CashBox
    {
        // Time (ms) to service 1 unit of customer goods.
        protected int _serviceTimePerUnit = 1000;

        // Cash box thread.
        protected Thread _thread;

        /// <summary>
        /// Cash box name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time (ms) to service 1 unit of customer goods.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual int ServiceTimePerUnit
        {
            get => _serviceTimePerUnit;
            set => (_serviceTimePerUnit) = (value > 0 || value == Timeout.Infinite) ? value : throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Queue of customers.
        /// </summary>
        protected Queue<Customer> Queue { get; set;} = new Queue<Customer>();

        /// <summary>
        /// Default constructor of CashBox.
        /// </summary>
        public CashBox()
        {
            Random random = new Random();
            ServiceTimePerUnit = random.Next(ServiceTimePerUnit / 2, ServiceTimePerUnit * 2);
            StartService();
        }

        /// <summary>
        /// Open cash box to manage customers.
        /// </summary>
        protected virtual void StartService()
        {
            _thread = new Thread(Service);
            _thread.Start();
        }

        /// <summary>
        /// Service single customer.
        /// </summary>
        public void Service()
        {
            while (Queue.Count > 0)
            {
                Customer customer = Queue.Peek();
                int serviceTime = customer.Basket * ServiceTimePerUnit;
                Thread.Sleep(serviceTime);

                // Customer leaves store.
                Queue.Dequeue();
                Console.WriteLine($">> {Name} :: {customer.Name} ({customer.Basket} goods) is served in {serviceTime / 1000,2:N} sec! Queue : {Queue.Count}");
            }
        }

        /// <summary>
        /// Add new customer to the queue.
        /// </summary>
        /// <param name="obj">Customer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public void AddNewCustomer(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (!(obj is Customer customer))
                throw new InvalidCastException();

            Queue.Enqueue(customer);
            if (!_thread.IsAlive)
                StartService();
        }

        /// <summary>
        /// Get the number of customers in the queue.
        /// </summary>
        /// <returns>Number of customers.</returns>
        public int GetQueueLength() => Queue.Count;

        /// <summary>
        /// Check if there is some customers in the queue.
        /// </summary>
        /// <returns>True, if there is no customers in the queue.</returns>
        public bool IsEmpty() => Queue.Count == 0 ? true : false;
    }
}
using System;
using System.Threading;
using System.Collections.Generic;

namespace StoreCashBoxes
{
    public class CustomerGenerator
    {
        // Customer counter.
        private int _counter = 0;

        // Thread for customer generation.
        private Thread _thread;

        // Time interval (ms) for customers generation.
        private int _generationTimeInterval = 1000;

        // Generator locker.
        private object _locker = new object();

        /// <summary>
        /// Time interval (ms) for customers generation.
        /// </summary>
        public int GenerationTimeInterval
        {
            get => _generationTimeInterval;
            set => (_generationTimeInterval) = (value > 0 || value == Timeout.Infinite) ? value : throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public CustomerGenerator(object locker)
        {
            _locker = locker ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Get the number of created objects;
        /// </summary>
        /// <returns>Current count.</returns>
        public int GetCounter() => _counter;

        /// <summary>
        /// Start customer generator.
        /// </summary>
        /// <param name="list"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Start(List<Customer> list)
        {
            if (list == null)
                throw new ArgumentNullException();

            Thread.Sleep(50);
            _thread = new Thread(CreateCustomer);
            _thread.Start(list);
        }

        /// <summary>
        /// Stop generator and wait external start.
        /// </summary>
        public void Stop() => GenerationTimeInterval = Timeout.Infinite;

        /// <summary>
        /// Reset generator Counter.
        /// </summary>
        public void Reset() => _counter = 0;

        /// <summary>
        /// New customer creation with particular time interval.
        /// </summary>
        /// <param name="obj">List of customers.</param>
        private void CreateCustomer(object obj)
        {
            if (!(obj is List<Customer> customers))
                throw new ArgumentException();

            Random random = new Random();

            while (true)
            {
                lock (_locker)
                {
                    Customer customer = new Customer() { Name = $"Customer #{_counter++}" };
                    customers.Add(customer);
                    Console.WriteLine($"{customer.Name} enter the store!");
                }

                if (GenerationTimeInterval != Timeout.Infinite)
                    Thread.Sleep(random.Next(GenerationTimeInterval / 2, GenerationTimeInterval * 2));
                else
                    Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
using System;
namespace SimpleCashMachine
{
    /// <summary>
    /// Define a person object with several parameters.
    /// </summary>
    abstract public class Person
    {
        /// <summary>
        /// First name.
        /// </summary>
        public readonly string FirstName = "FirstName";

        /// <summary>
        /// Last name.
        /// </summary>
        public readonly string LastName = "LastName";

        /// <summary>
        /// Person age in years.
        /// </summary>
        public readonly int Age = 0;

        /// <summary>
        /// Person identifier (ID).
        /// </summary>
        public readonly int ID = 0;

        /// <summary>
        /// Default person constructor.
        /// </summary>
        public Person() { }

        /// <summary>
        /// Create persone with several parameters.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="age">Age [years].</param>
        /// <param name="id">Identifier.</param>
        public Person(string firstName, string lastName, int age, int id)
        {
            FirstName = firstName ?? throw new ArgumentNullException();
            LastName = lastName ?? throw new ArgumentNullException();
            Age = (age > 0) ? age : throw new ArgumentOutOfRangeException();
            ID = (id > 0) ? id : throw new ArgumentOutOfRangeException();
        }
    }
}
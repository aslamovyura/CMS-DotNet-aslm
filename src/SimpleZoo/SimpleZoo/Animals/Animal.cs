using System;
using SimpleZoo.Intefaces;

namespace SimpleZoo.Animals
{
    public abstract class Animal
    {
        /// <summary>
        /// Animal name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Animal age in years.
        /// </summary>
        public virtual int Age { get; protected set; }

        /// <summary>
        /// Max animal age.
        /// </summary>
        public virtual int MAX_AGE { get; protected set; } = 25;

        /// <summary>
        /// Animal health in percents from 0 to 100%.
        /// </summary>
        public virtual int Health { get; set; } = 100;

        /// <summary>
        /// Animal identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Meal type for animal.
        /// </summary>
        public virtual MealType MealType { get; }

        /// <summary>
        /// Constructor of animal.
        /// </summary>
        public Animal() { }

        /// <summary>
        /// Constructor of animal.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age in years.</param>
        /// <param name="health">Health in percents.</param>
        /// <param name="id">Identifier.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Animal(string name, int age, int health, Guid id)
        {
            Name = name;
            Age = age;
            Health = health;
            Id = id;
        }

        /// <summary>
        /// Convert animal info to string format.
        /// </summary>
        /// <returns>String animal info.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, age: {Age}, health: {Health}%, id: {Id}";
        }
    }
}

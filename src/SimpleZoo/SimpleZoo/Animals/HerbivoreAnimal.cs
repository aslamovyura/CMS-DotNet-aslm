using System;
using SimpleZoo.Intefaces;

namespace SimpleZoo.Animals
{
    public class HerbivoreAnimal : MamalAnimal
    {
        /// <summary>
        /// Meal type of Herbivore animal is Herbal.
        /// </summary>
        public override MealType MealType => MealType.Herbal;

        /// <summary>
        /// Constructor of Herbivore animal.
        /// </summary>
        public HerbivoreAnimal() { }

        /// <summary>
        /// Constructor of Herbivore animal.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age in years.</param>
        /// <param name="health">Health in percents.</param>
        /// <param name="id">Identifier.</param>
        public HerbivoreAnimal(string name, int age, int health, Guid id)
            : base(name, age, health, id) { }
    }
}
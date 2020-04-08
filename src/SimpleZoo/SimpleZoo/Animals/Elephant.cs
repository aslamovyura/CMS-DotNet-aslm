using System;

namespace SimpleZoo.Animals
{
    public class Elephant : HerbivoreAnimal
    {
        /// <summary>
        /// Animal type, e.g. lion, elephant, etc.
        /// </summary>
        public override string Type => "Alephant";

        /// <summary>
        /// Maximum elephant speed.
        /// </summary>
        public override int MAX_SPEED => 15;

        /// <summary>
        /// Maximum elephant speed.
        /// </summary>
        public override int MAX_AGE => 25;

        /// <summary>
        /// Antelope health.
        /// </summary>
        public override int Health { get; set; } = 100;

        /// <summary>
        /// Constructor of Elephant object.
        /// </summary>
        public Elephant() { }

        /// <summary>
        /// Constructor of Elephant object.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age, years.</param>
        /// <param name="health">Health, %.</param>
        /// <param name="id">Identifier.</param>
        public Elephant(string name, int age, int health, Guid id)
            : base(name, age, health, id) { }
    }
}
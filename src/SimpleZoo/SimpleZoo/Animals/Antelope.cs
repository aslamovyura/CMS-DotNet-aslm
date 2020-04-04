using System;
namespace SimpleZoo.Animals
{
    public class Antelope : HerbivoreAnimal
    {
        /// <summary>
        /// Maximum antelope speed.
        /// </summary>
        public override int MAX_SPEED => 25;

        /// <summary>
        /// Antelope attack power.
        /// </summary>
        public override int Health { get; set; } = 60;

        /// <summary>
        /// Constructor of Antelope object.
        /// </summary>
        public Antelope() { }

        /// <summary>
        /// Constructor of Antelope object.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age, years.</param>
        /// <param name="health">Health, %.</param>
        /// <param name="id">Identifier.</param>
        public Antelope(string name, int age, int health, Guid id)
            : base(name, age, health, id) { }
    }
}

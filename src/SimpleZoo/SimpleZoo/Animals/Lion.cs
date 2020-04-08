using System;

namespace SimpleZoo.Animals
{
    public class Lion : PredatorAnimal<HerbivoreAnimal>
    {
        /// <summary>
        /// Animal type, e.g. lion, elephant, etc.
        /// </summary>
        public override string Type => "Lion";

        /// <summary>
        /// Maximum lion speed.
        /// </summary>
        public override int MAX_SPEED => 65;

        /// <summary>
        /// Maximum lion speed.
        /// </summary>
        public override int MAX_AGE => 15;

        /// <summary>
        /// Lion attack power.
        /// </summary>
        public override int AttackPower => 120;

        /// <summary>
        /// Lion attack power.
        /// </summary>
        public override int Health { get; set; } = 100;

        /// <summary>
        /// Constructor of Lion object.
        /// </summary>
        public Lion() { }

        /// <summary>
        /// Constructor of Lion object.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age, years.</param>
        /// <param name="health">Health, %.</param>
        /// <param name="id">Identifier.</param>
        public Lion (string name, int age, int health, Guid id)
            : base(name, age, health, id, attackPower:120) { }
    }
}
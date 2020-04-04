using System;
using SimpleZoo.Intefaces;
namespace SimpleZoo.Animals
{
    public class HerbivoreAnimal : Animal, IMovable, IFeedable, IHealable
    {
        /// <summary>
        /// Meal type of Herbivore animal is Herbal.
        /// </summary>
        public override MealType MealType => MealType.Herbal;

        /// <summary>
        /// Level of predator's hunger.
        /// </summary>
        public int Hunger { get; set; } = 0;

        /// <summary>
        /// Threshold level of hunger.
        /// </summary>
        const int HUNGRY_THRESH = 50;

        /// <summary>
        /// Current speed.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Maximum speed.
        /// </summary>
        public virtual int MAX_SPEED { get; }

        /// <summary>
        /// Threshold level for death state.
        /// </summary>
        public const int DEATH_THRESH = 0;

        /// <summary>
        /// Threshold level for healthy state.
        /// </summary>
        public const int HEALTHY_THRESH = 75;

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

        /// <summary>
        /// Check if herbivore animal is moving.
        /// </summary>
        /// <returns>True if object is moving.</returns>
        public bool IsMoving() => Speed > 0 ? true : false;

        /// <summary>
        /// Try to heal object, if health level is not too low.
        /// </summary>
        public void TryHeal()
        {
            if (Health < DEATH_THRESH)
            {
                Console.WriteLine($"Sorry! Impossible to heal {Name}...");
                if (!IsHealingSuccessful())
                {
                    Console.WriteLine("Ups...");
                    Kill();
                }
                return;
            }

            if (Health > HEALTHY_THRESH)
            {
                Console.WriteLine($"No need to heal {Name}, it's pretty healthy!");
                return;
            }

            if (IsHealingSuccessful())
            {
                Health = 100;
                Console.WriteLine($"Excellent! {Name} completely healed!");
            }
            else
                Console.WriteLine($"Ups... {Name} could not be healed... Let's try later!");
        }

        /// <summary>
        /// Check if object is healthy.
        /// </summary>
        /// <returns>True if object is healthy.</returns>
        public bool IsHealthy() => Health > HEALTHY_THRESH ? true : false;

        /// <summary>
        /// Check if object is dead.
        /// </summary>
        /// <returns>True if object is dead.</returns>
        public bool IsDead() => Health <= DEATH_THRESH ? true : false;

        /// <summary>
        /// Kill object.
        /// </summary>
        public void Kill()
        {
            Health = 0;
            Console.WriteLine($"{Name} is dead...");
        }

        /// <summary>
        /// Check if healing was successful.
        /// </summary>
        /// <returns>True, if healing was successful.</returns>
        private bool IsHealingSuccessful()
        {
            int maxProbability = (int)decimal.Round((1 - Age / MAX_AGE) * 100);
            int minProbability = 0;

            var rand = new Random();
            int threshold = 25;

            return rand.Next(minProbability, maxProbability) > threshold;
        }

        /// <summary>
        /// Feed object with some meal.
        /// </summary>
        public void Feed(MealType meal)
        {
            if (!isHungry())
            {
                Console.WriteLine($"No need to feed. {Name} is still full!");
                return;
            }

            if (meal == MealType)
            {
                Hunger = 0;
                Console.WriteLine($"Excellent! {Name} is fully fed up!");
            }
            else
            {
                Console.WriteLine($"Impossible to feed {Name} with {meal}!");
            }
        }

        /// <summary>
        /// Check if object is hungry.
        /// </summary>
        /// <returns>Return true if object is hungry</returns>
        public bool isHungry() => Hunger > HUNGRY_THRESH ? true : false;

        // ***************** IMovable ********************** //

        /// <summary>
        /// Move object with const speed.
        /// </summary>
        /// <param name="speed">Object speed</param>
        public void Move(int speed)
        {
            if (speed < 0)
                throw new ArgumentException();

            Speed = speed > MAX_SPEED ? speed : MAX_SPEED;
        }

        /// <summary>
        /// Accelerate object with delta.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            Speed += delta;
        }

        /// <summary>
        /// Accelerate object with delta.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void SpeedUp(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            Speed += delta;
            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;
        }

        /// <summary>
        /// Slow down object with delta.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void SlowDown(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            if (delta < Speed)
                Speed -= delta;
            else
                Stop();
        }

        /// <summary>
        /// Stop object immediately.
        /// </summary>
        public void Stop()
        {
            Speed = 0;
        }
    }
}

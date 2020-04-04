using System;
using SimpleZoo.Intefaces;
namespace SimpleZoo.Animals
{
    public class PredatorAnimal<T> : Animal, IFeedable, IHealable, IHuntable<HerbivoreAnimal>, IMovable
        where T : HerbivoreAnimal
    {
        /// <summary>
        /// Meal type of Predator animal is Meat.
        /// </summary>
        public override MealType MealType => MealType.Meat;

        /// <summary>
        /// Level of predator's hunger.
        /// </summary>
        public int Hunger { get; set; } = 0;

        /// <summary>
        /// Threshold level of hunger.
        /// </summary>
        const int HUNGRY_THRESH = 50;

        /// <summary>
        /// Predator attack power.
        /// </summary>
        public virtual int AttackPower { get; }

        /// <summary>
        /// Animal current speed, km/h.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Animal maximum speed.
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
        /// Constructor of predator animal.
        /// </summary>
        public PredatorAnimal() { }

        /// <summary>
        /// Constructor of predator animal.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age in years.</param>
        /// <param name="health">Health in percents.</param>
        /// <param name="id">Identifier.</param>
        public PredatorAnimal(string name, int age, int health, Guid id)
            : base(name, age, health, id) { }


        /// <summary>
        /// Check if object is moving.
        /// </summary>
        /// <returns>True if object is moving.</returns>
        public bool IsMoving() => Speed > 0 ? true : false;

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

        /// <summary>
        /// Hunt.
        /// </summary>
        /// <typeparam name="T">Victim class.</typeparam>
        /// <param name="victim">Victim.</param>
        public void Hunt(HerbivoreAnimal victim)
        {
            Move(MAX_SPEED);
            victim.Move(victim.MAX_SPEED);

            CatchUp(victim);
            if (victim.IsMoving())
            {
                Console.WriteLine("The hunt is failed!");
                return;
            }

            Hit(victim);
            if (victim.IsDead())
                Feed(MealType.Meat);
            else
            {
                Console.WriteLine("The hunt is failed!");
                return;
            }
        }

        /// <summary>
        /// Try to catch up victim.
        /// </summary>
        /// <param name="victim">Victim.</param>
        public void CatchUp(HerbivoreAnimal victim)
        {
            Random rand = new Random();
            int victimIsCatched = rand.Next(0, 2);
            if (victimIsCatched == 1)
            {
                victim.Stop();
                Stop();
                Console.WriteLine($"{victim.Name} was catched up!");
            }
            else
                Console.WriteLine($"Oh nooo! {victim.Name} ran away!");
        }

        /// <summary>
        /// Hit victim to kill.
        /// </summary>
        /// <param name="victim">Victime.</param>
        public void Hit(HerbivoreAnimal victim)
        {
            if ((victim.Health - AttackPower) < 0)
                victim.Kill();
            else
                Console.WriteLine("");
        }

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
    }
}

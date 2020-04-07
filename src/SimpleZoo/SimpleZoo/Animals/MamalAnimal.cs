using System;
using SimpleZoo.Intefaces;

namespace SimpleZoo.Animals
{
    public class MamalAnimal : Animal, IHealable, IMovable, IFeedable
    {
        /// <summary>
        /// Animal age [years].
        /// </summary>
        private int _age = 0;

        /// <summary>
        /// Amimal health [%].
        /// </summary>
        private int _health = 0;

        /// <summary>
        /// Amimal hunger [%].
        /// </summary>
        private int _hunger = 0;

        /// <summary>
        /// Animal type, e.g. lion, elephant, etc.
        /// </summary>
        public virtual string Type { get; } = "Mamal animal";

        /// <summary>
        /// Mamal animal age [years].
        /// </summary>
        public override int Age
        {
            get => _age;
            protected set
            {
                if (value > 0 && value <= MAX_AGE)
                    _age = value;
                else
                    throw new ArgumentException("Health should be in range from 0 to MAX_RANGE!");
            }
        }

        /// <summary>
        /// Animal age [years].
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override int Health
        {
            get => _health;
            set
            {
                if (value >= 0 && value <= 100)
                    _health = value;
                else
                    throw new ArgumentOutOfRangeException("Health should be in range from 0 to 100!");
            }
        }

        /// <summary>
        /// Threshold level for death state.
        /// </summary>
        protected const int DEATH_THRESH = 0;

        /// <summary>
        /// Threshold level for healthy state.
        /// </summary>
        protected const int HEALTHY_THRESH = 75;

        /// <summary>
        /// Meal type of mamal animal is Herbal.
        /// </summary>
        public override MealType MealType => MealType.Universal;

        /// <summary>
        /// Level of mamal hunger from 0 to 100%.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int Hunger
        {
            get => _hunger;
            set
            {
                if (value >= 0 && value <= 100)
                    _hunger = value;
                else
                    throw new ArgumentException("Health should be in range from 0 to 100!");
            }
        }

        /// <summary>
        /// Threshold level of hunger.
        /// </summary>
        protected const int HUNGRY_THRESH = 50;

        /// <summary>
        /// Current speed.
        /// </summary>
        public int CurrentSpeed { get; set; }

        /// <summary>
        /// Maximum speed.
        /// </summary>
        public virtual int MAX_SPEED { get; } = 50;

        /// <summary>
        /// Constructor of Herbivore animal.
        /// </summary>
        public MamalAnimal() { RegisterEvents(); }

        /// <summary>
        /// Constructor of Mamal animal.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="age">Age in years.</param>
        /// <param name="health">Health in percents.</param>
        /// <param name="id">Identifier.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public MamalAnimal(string name, int age, int health, Guid id)
            : base(name, age, health, id)
        {
            if (age < 0 || age > MAX_AGE)
                throw new ArgumentOutOfRangeException();

            if (name == null)
                throw new ArgumentNullException();

            RegisterEvents();
        }

        /// <summary>
        /// Convert mamal animal info to string format.
        /// </summary>
        /// <returns>String animal info.</returns>
        public override string ToString() => $"Name: {Name}\t type: {Type}\t age: {Age}\t\t health: {Health}%\t hunger: {Hunger}%.";

        // ****************** Events ************************ //

        public delegate void AnimalHandler(string msg);

        // Mamal animal possible events (on state)
        protected event AnimalHandler Dead;
        protected event AnimalHandler Healthy;
        protected event AnimalHandler Unhealthy;
        protected event AnimalHandler Hungry;
        protected event AnimalHandler Full;
        protected event AnimalHandler Staying;
        protected event AnimalHandler Moving;

        // Implementation of mamal animal events
        public virtual void OnDying(string msg) => Dead?.Invoke(msg);
        public virtual void OnHealthy(string msg) => Healthy?.Invoke(msg);
        public virtual void OnUnhealthy(string msg) => Unhealthy?.Invoke(msg);
        public virtual void OnHungry(string msg) => Hungry?.Invoke(msg);
        public virtual void OnFull(string msg) => Full?.Invoke(msg);
        public virtual void OnStaying(string msg) => Staying?.Invoke(msg);
        public virtual void OnMoving(string msg) => Moving?.Invoke(msg);

        /// <summary>
        /// Tune-up the event of Mamal Animal.
        /// </summary>
        protected virtual void RegisterEvents()
        {
            Dead += (msg) => Console.WriteLine(msg);
            Healthy += (msg) => Console.WriteLine(msg);
            Unhealthy += (msg) => Console.WriteLine(msg);
            Hungry += (msg) => Console.WriteLine(msg);
            Full += (msg) => Console.WriteLine(msg);
            Staying += (msg) => Console.WriteLine(msg);
            Moving += (msg) => Console.WriteLine(msg);
        }

        // ***************** IHealable ********************** //

        /// <summary>
        /// Try to heal Mamal analimal, if health level is not too low.
        /// </summary>
        public void TryHeal()
        {
            if (Health < DEATH_THRESH)
            {
                OnDying($"Sorry! Impossible to heal {Name}...");
                if (!IsHealingSuccessful())
                {
                    Console.WriteLine("Ups...");
                    Kill();
                }
                return;
            }

            if (Health > HEALTHY_THRESH)
            {
                OnHealthy($"No need to heal {Name}, it's pretty healthy!");
                return;
            }

            if (IsHealingSuccessful())
            {
                Health = 100;
                OnHealthy($"Excellent! {Name} completely healed!");
            }
            else
                OnUnhealthy($"Ups... {Name} could not be healed... Let's try later!");
        }

        /// <summary>
        /// Check if healing of Mamal animal was successful.
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
        /// Check if Mamal animal is healthy.
        /// </summary>
        /// <returns>True if object is healthy.</returns>
        public bool IsHealthy() => Health > HEALTHY_THRESH ? true : false;

        /// <summary>
        /// Check if Mamal animal is dead.
        /// </summary>
        /// <returns>True if object is dead.</returns>
        public bool IsDead() => Health <= DEATH_THRESH ? true : false;

        /// <summary>
        /// Kill Mamal animal.
        /// </summary>
        public void Kill()
        {
            Health = 0;
            OnDying($"{Name} is dead...");
        }

        // ***************** IFeedable ********************** //

        /// <summary>
        /// Feed Mamal animal with some meal.
        /// </summary>
        public void Feed(MealType meal)
        {
            if (!IsHungry())
            {
                OnFull($"No need to feed. {Name} is still full!");
                return;
            }

            if (meal == MealType)
            {
                Hunger = 0;
                OnFull($"Excellent! {Name} is fully fed up!");
            }
            else
                OnHungry($"Impossible to feed {Name} with {meal}!");
        }

        /// <summary>
        /// Check if Mamal animal is hungry.
        /// </summary>
        /// <returns>Return true if object is hungry</returns>
        public bool IsHungry() => Hunger > HUNGRY_THRESH ? true : false;

        // ***************** IMovable ********************** //

        /// <summary>
        /// Check if Mamal animal is moving.
        /// </summary>
        /// <returns>True if object is moving.</returns>
        public bool IsMoving() => CurrentSpeed > 0 ? true : false;

        /// <summary>
        /// Move mamal animal with const speed.
        /// </summary>
        /// <param name="speed">Object speed</param>
        /// <exception cref="ArgumentException"></exception>
        public void Move(int speed)
        {
            if (speed < 0)
                throw new ArgumentException();

            CurrentSpeed = speed > MAX_SPEED ? speed : MAX_SPEED;
            OnMoving($"{Name} is moving with {CurrentSpeed} km/h speed!");
        }

        /// <summary>
        /// Accelerate mamal animal with delta.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            CurrentSpeed += delta;
            OnMoving($"{Name} is accelerating.");
        }

        /// <summary>
        /// Accelerate mamal animal with delta speed.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void SpeedUp(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            CurrentSpeed += delta;
            if (CurrentSpeed > MAX_SPEED)
                CurrentSpeed = MAX_SPEED;
        }

        /// <summary>
        /// Slow down mamal animal with delta speed.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void SlowDown(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            if (delta < CurrentSpeed)
                CurrentSpeed -= delta;
            else
                Stop();
        }

        /// <summary>
        /// Stop mamal animal immediately.
        /// </summary>
        public void Stop()
        {
            CurrentSpeed = 0;
            OnStaying($"{Name} is stopped.");
        }
    }
}
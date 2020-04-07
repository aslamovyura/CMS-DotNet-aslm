using System;
using SimpleZoo.Intefaces;

namespace SimpleZoo.Animals
{
    public class PredatorAnimal<T> : MamalAnimal, IHuntable<HerbivoreAnimal>
        where T : HerbivoreAnimal
    {
        /// <summary>
        /// Predator Attack Power.
        /// </summary>
        protected int _attackPower = 120;

        /// <summary>
        /// Meal type of Predator animal is Meat.
        /// </summary>
        public override MealType MealType => MealType.Meat;

        /// <summary>
        /// Predator attack power.
        /// </summary>
        public virtual int AttackPower { get => _attackPower; }

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
        /// <param name="attackPower">Attack power.</param>
        /// <exception cref="ArgumentException"></exception>
        public PredatorAnimal(string name, int age, int health, Guid id, int attackPower)
            : base(name, age, health, id)
        {
            if (attackPower > 0)
                _attackPower = attackPower;
            else
                throw new ArgumentException();
        }

        // ****************** Events ************************ //

        /// <summary>
        /// Hunting event.
        /// </summary>
        protected event AnimalHandler Hunting;

        /// <summary>
        /// Descride the "hunting" state of predator.
        /// </summary>
        /// <param name="msg"></param>
        public void OnHunting(string msg) => Hunting?.Invoke(msg);

        /// <summary>
        /// Tune-up events described the state of predator.
        /// </summary>
        protected override void RegisterEvents()
        {
            base.RegisterEvents();
            Hunting += (msg) => Console.WriteLine(msg);
        }

        // ***************** IFeedable ********************** //

        /// <summary>
        /// Feed Predator animal with Herbivore animal.
        /// </summary>
        public void Feed(HerbivoreAnimal victim)
        {
            Console.WriteLine($"{Name} begins to eat the {victim.Name}.");
            if (IsHungry())
            {
                Hunger -= victim.Health;
                if (Hunger < 0)
                    Hunger = 0;

                Console.WriteLine($"Excellent! {victim.Name} is eaten!!");

                if (IsHungry())
                    Console.WriteLine($"{ Name} is not full enough... Need another meal...");
                else
                    Console.WriteLine($"Gooood! { Name} is full!");
            }
            else
                Console.WriteLine($"No need to feed. {Name} is still full!");
        }

        // ***************** IHuntable ********************** //

        /// <summary>
        /// Hunt.
        /// </summary>
        /// <typeparam name="T">Victim class.</typeparam>
        /// <param name="victim">Victim.</param>
        public void Hunt(HerbivoreAnimal victim)
        {
            OnHunting($"\n{Name} begins to hunt!\n");

            victim.OnMoving($"{victim.Name} is trying to run away!");

            Move(MAX_SPEED);
            victim.Move(victim.MAX_SPEED);

            CatchUp(victim);
            if (victim.IsMoving())
            {
                OnHunting("The hunt is failed!");
                return;
            }

            TryKill(victim);
            if (victim.IsDead())
                Feed(victim);
            else
                OnHunting("The hunt is failed!");
        }

        /// <summary>
        /// Try to catch up victim.
        /// </summary>
        /// <param name="victim">Victim.</param>
        public void CatchUp(HerbivoreAnimal victim)
        {
            Console.WriteLine($"{Name} is trying to catch up with {victim.Name}.");

            if (CurrentSpeed > victim.CurrentSpeed)
            {
                victim.Stop();
                victim.OnStaying($"{victim.Name} was catched up!");
            }
            else
                Console.WriteLine($"Oh nooo! {victim.Name} ran away!");
            Stop();
        }

        /// <summary>
        /// Hit victim to kill.
        /// </summary>
        /// <param name="victim">Victime.</param>
        public void TryKill(HerbivoreAnimal victim)
        {
            Console.WriteLine($"{Name} is trying to kill {victim.Name}.");
            if ((victim.Health - AttackPower) < 0)
                victim.Kill();
            else
                Console.WriteLine($"Oh nooo! {victim.Name} escaped and ran away.");
        }
    }
}
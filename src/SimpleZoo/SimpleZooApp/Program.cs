using System;
using SimpleZoo.Animals;
using SimpleZoo.Zoo;

namespace SimpleZooApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************** Simple ZOO APP ***************\n");

            Zoo zoo = new Zoo();
            zoo.LoadDefaultAnimalList();
            zoo.OrderAnimalsByName();
            zoo.Show();

            // Order the list of animals by their name.
            zoo.OrderAnimalsByType();
            zoo.Show();

            // Try to heal sick animals.
            zoo.HealUnhealthyAnimals();
            zoo.Show();

            // Try to feed hungry animals.
            zoo.FeedHungryAnimals();
            zoo.Show();

            // To test predator actions ... lion begins to hunt.
            LionHuntAntilope();
        }

        /// <summary>
        /// Demo : lion try to hunt antilope.
        /// </summary>
        static void LionHuntAntilope()
        {
            Console.WriteLine("\n*************** Lion hunt ***************\n");

            Lion lion = new Lion(name: "Simba", age: 4, health: 100, id: Guid.NewGuid()) { Hunger = 80};
            Antelope antelope = new Antelope(name: "Lulu", age: 2, health: 30, id: Guid.NewGuid()) { Hunger = 10 }; ;

            // If lion is too hungry, he may try to hunt antilope.
            if (lion.IsHungry())
                lion.Hunt(antelope);

            lion.IsHungry();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SimpleZoo.Animals;
using SimpleZoo.Intefaces;

namespace SimpleZoo.Zoo
{
    public class Zoo
    {
        /// <summary>
        /// The list of animals in the zoo.
        /// </summary>
        protected List<MamalAnimal> Animals { get; private set; } = new List<MamalAnimal>();

        public Zoo(){ }

        /// <summary>
        /// Load default list of animals in the zoo (lions, antelopes, alephants).
        /// </summary>
        public void LoadDefaultAnimalList()
        {
            Animals.AddRange( new List<Lion>
            {
                new Lion(name: "Simba", age: 2, health: 100, id: Guid.NewGuid()) { Hunger = 20 },
                new Lion(name: "Scar", age: 8, health: 45, id: Guid.NewGuid()) { Hunger = 80 },
                new Lion(name: "Mufase", age: 10, health: 20, id: Guid.NewGuid()) { Hunger = 0 },
                new Lion(name: "Cesar", age: 13, health: 49, id: Guid.NewGuid()) { Hunger = 67 }
            } );

            Animals.AddRange(new List<Antelope>
            {
                new Antelope(name: "Kira", age: 2, health: 100, id: Guid.NewGuid()) { Hunger = 33 },
                new Antelope(name: "Asar", age: 5, health: 45, id: Guid.NewGuid()) { Hunger = 100 },
                new Antelope(name: "Mexar", age: 3, health: 80, id: Guid.NewGuid()) { Hunger = 13 },
                new Antelope(name: "Antioh", age: 4, health: 20, id: Guid.NewGuid()) { Hunger = 56 },
                new Antelope(name: "Papel", age: 9, health: 0, id: Guid.NewGuid()) { Hunger = 0 },
                new Antelope(name: "Reasel", age: 8, health: 33, id: Guid.NewGuid()) { Hunger = 54 },
                new Antelope(name: "Adele", age: 8, health: 33, id: Guid.NewGuid()) { Hunger = 54 }
            });

            Animals.AddRange(new List<Elephant>
            {
                new Elephant(name: "Bobo", age: 15, health: 100, id: Guid.NewGuid()) { Hunger = 33 },
                new Elephant(name: "Pumba", age: 4, health: 45, id: Guid.NewGuid()) { Hunger = 100 }
            });
        }

        /// <summary>
        /// Extimate the number of elements in the zoo.
        /// </summary>
        /// <returns>Int32</returns>
        public int GetNumberOfAnimals() => Animals.Count();

        /// <summary>
        /// Get animal from the zoo.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public MamalAnimal GetAnimal(int index)
        {
            if (index < 0 || index > GetNumberOfAnimals())
                throw new ArgumentOutOfRangeException();
            return Animals[index];
        }

        /// <summary>
        /// Add a certain mamal animal to the zoo.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddAnimal(MamalAnimal animal)
        {
            if (animal is MamalAnimal)
                Animals.Add(animal);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// Remove a certain animal from the zoo.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveAnimal(MamalAnimal animal)
        {
            if (Animals.Contains(animal))
                Animals.Remove(animal);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// Remove animals with a particular name from the zoo.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
         public void RemoveAnimal(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            var animalsToRemove = from a in Animals where (a.Name == name) select a;
            foreach (var a in animalsToRemove)
                Animals.Remove(a);
        }

        /// <summary>
        /// Remove animals with a particular name from the zoo.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveAnimal(int age)
        {
            var animalsToRemove = from a in Animals where (a.Age == age) select a;
            foreach (var a in animalsToRemove)
                Animals.Remove(a);
        }

        /// <summary>
        /// Remove all dead animals from the zoo.
        /// </summary>
        public void RemoveDeadAnimal()
        {
            var animalsToRemove = from a in Animals where (a.IsDead()) select a;
            foreach (var a in animalsToRemove)
                Animals.Remove(a);
        }

        /// <summary>
        /// Try to heal all sick/unhealthy animals in the zoo, except dead animals.
        /// </summary>
        public void HealUnhealthyAnimals()
        {
            Console.WriteLine("\n-------- Healing unhealthy animals -------- \n");

            // Search for unhealthy animals in the zoo to heal.
            var unhealthyAnimals = GetUnhealthyAnimals();

            // Try to heal animals.
            foreach (var a in unhealthyAnimals)
                a.TryHeal();
        }

        /// <summary>
        /// Feed all hungry animals in the zoo.
        /// </summary>
        public void FeedHungryAnimals()
        {
            Console.WriteLine("\n-------- Feeding hungry animals -------- \n");

            // Search for hungry animals in the zoo to feed.
            var hungryAnimals = from a in Animals where a.IsHungry() select a;

            // Feed predator animals.
            var hungryPredatorAnimals = hungryAnimals.Where(a => (a.MealType == MealType.Meat)).Select(a=>a);
            foreach (var a in hungryPredatorAnimals)
                a.Feed(MealType.Meat);

            // Feed herbivore animals.
            var hungryHerbivoreAnimals = hungryAnimals.Where(a => (a.MealType == MealType.Herbal)).Select(a => a);
            foreach (var a in hungryHerbivoreAnimals)
                a.Feed(MealType.Herbal);
        }

        /// <summary>
        /// Show healthy animals in the zoo.
        /// </summary>
        public void ShowHealthyAnimals()
        {
            Console.WriteLine("------- Healthy animals in the Zoo -------\n");
            var healthyAnimals = from a in Animals where a.IsHealthy() select a;

            foreach (var a in Animals)
                Console.WriteLine(a);
        }

        /// <summary>
        /// Show dead animals in the zoo.
        /// </summary>
        public void ShowDeadAnimals()
        {
            Console.WriteLine("------- Dead animals in the Zoo -------\n");
            var healthyAnimals = from a in Animals where a.IsDead() select a;

            foreach (var a in Animals)
                Console.WriteLine(a);
        }

        /// <summary>
        /// Show hungry animals in the zoo.
        /// </summary>
        public void ShowHungryAnimals()
        {
            Console.WriteLine("------- Hungry animals in the Zoo -------\n");
            var healthyAnimals = from a in Animals where a.IsHungry() select a;

            foreach (var a in Animals)
                Console.WriteLine(a);
        }

        /// <summary>
        /// Select Hungry and Unhealthy animals in the zoo.
        /// </summary>
        /// <returns></returns>
        public List<MamalAnimal> GetHungryUnhealthyAnimals()
        {
            var animals = from a in Animals where (!a.IsHealthy() && !a.IsDead() && a.IsHungry()) select a;
            return animals.ToList();
        }

        /// <summary>
        /// Select Hungry and Unhealthy animals in the zoo.
        /// </summary>
        /// <returns></returns>
        public List<MamalAnimal> GetHungryAnimals()
        {
            var animals = from a in Animals where a.IsHungry() select a;
            return animals.ToList();
        }

        /// <summary>
        /// Select Hungry and Unhealthy animals in the zoo.
        /// </summary>
        /// <returns></returns>
        public List<MamalAnimal> GetUnhealthyAnimals()
        {
            var animals = from a in Animals where !a.IsHealthy() select a;
            return animals.ToList();
        }

        /// <summary>
        /// Show all animals in the zoo.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("------- Animals in the Zoo -------\n");
            foreach (var a in Animals)
                Console.WriteLine(a);
            Console.WriteLine();
        }

        /// <summary>
        /// Order animals in the zoo by the name.
        /// </summary>
        public void OrderAnimalsByName()
        {
            var orderedAnimals = from a in Animals
                             orderby a.Name ascending
                             select a;

            Animals = orderedAnimals.ToList();
        }

        /// <summary>
        /// Order animals in the zoo by age.
        /// </summary>
        public void OrderAnimalsByAge()
        {
            var orderedAnimals = from a in Animals
                                 orderby a.Age ascending
                                 select a;

            Animals = orderedAnimals.ToList();
        }

        /// <summary>
        /// Order animals in the zoo by their health.
        /// </summary>
        public void OrderAnimalsByHealth()
        {
            var orderedAnimals = from a in Animals
                                 orderby a.Health ascending
                                 select a;

            Animals = orderedAnimals.ToList();
        }

        /// <summary>
        /// Order animals in the zoo by their hunger.
        /// </summary>
        public void OrderAnimalsByHunger()
        {
            var orderedAnimals = from a in Animals
                                 orderby a.Hunger ascending
                                 select a;

            Animals = orderedAnimals.ToList();
        }

        /// <summary>
        /// Order animals in the zoo by their type..
        /// </summary>
        public void OrderAnimalsByType()
        {
            var orderedAnimals = from a in Animals
                                 orderby a.Type ascending
                                 select a;

            Animals = orderedAnimals.ToList();
        }
    }
}
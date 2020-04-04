using System;
namespace SimpleZoo.Intefaces
{
    public interface IFeedable
    {
        /// <summary>
        /// Oject name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Threshold level of hunger.
        /// </summary>
        const int HUNGRY_THRESH = 50;

        /// <summary>
        /// Level of object's hunger from 0 to 100%.
        /// </summary>
        public int Hunger { get; set; }

        /// <summary>
        /// Prefered type of object's meal.
        /// </summary>
        public MealType MealType { get; }

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

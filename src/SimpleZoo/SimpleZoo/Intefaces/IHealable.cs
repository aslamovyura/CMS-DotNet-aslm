using System;
namespace SimpleZoo.Intefaces
{
    public interface IHealable
    {
        /// <summary>
        /// Object age, years.
        /// </summary>
        int Age { get; }

        /// <summary>
        /// Max object age, years.
        /// </summary>
        int MAX_AGE { get; }

        /// <summary>
        /// Object health.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Threshold level for death state.
        /// </summary>
        const int DEATH_THRESH = 0;

        /// <summary>
        /// Threshold level for healthy state.
        /// </summary>
        const int HEALTHY_THRESH = 75;

        /// <summary>
        /// Try to heal object, if health level is not too low.
        /// </summary>
        public void TryHeal()
        {
            if (Health < DEATH_THRESH)
            {
                Console.WriteLine($"Sorry! Impossible to heal Object...");
                if (!IsHealingSuccessful())
                {
                    Console.WriteLine("Ups...");
                    Kill();
                }
                return;
            }

            if (Health > HEALTHY_THRESH)
            {
                Console.WriteLine($"No need to heal Object, it's pretty healthy!");
                return;
            }

            if (IsHealingSuccessful())
            {
                Health = 100;
                Console.WriteLine($"Excellent! Object completely healed!");
            }
            else
                Console.WriteLine($"Ups... Object could not be healed... Let's try later!");
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
            Console.WriteLine($"Object is dead...");
        }

        /// <summary>
        /// Check if healing was successful.
        /// </summary>
        /// <returns>True, if healing was successful.</returns>
        private bool IsHealingSuccessful()
        {
            int maxProbability = (int)decimal.Round((1 - Age / MAX_AGE)*100);
            int minProbability = 0;

            var rand = new Random();
            int threshold = 25;

            return rand.Next(minProbability, maxProbability) > threshold;
        }
    }
}
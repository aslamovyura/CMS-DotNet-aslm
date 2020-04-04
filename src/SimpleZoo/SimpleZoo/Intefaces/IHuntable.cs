using System;
using SimpleZoo.Animals;
namespace SimpleZoo.Intefaces
{
    public interface IHuntable<T> : IMovable
    {
        /// <summary>
        /// Attack power.
        /// </summary>
        public int AttackPower { get; }

        /// <summary>
        /// Hunt the victim.
        /// </summary>
        /// <typeparam name="T">Victim class.</typeparam>
        /// <param name="victim">Victim.</param>
        public void Hunt(T victim);

        /// <summary>
        /// Try to catch up the victim.
        /// </summary>
        /// <typeparam name="T">Victim class.</typeparam>
        /// <param name="victim">Victim.</param>
        public void CatchUp(T victim);

        /// <summary>
        /// Hit victim.
        /// </summary>
        /// <typeparam name="T">Victim class.</typeparam>
        /// <param name="victim">Victim.</param>
        public void Hit(T victim);
    }
}

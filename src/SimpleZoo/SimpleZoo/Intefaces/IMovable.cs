using System;

namespace SimpleZoo.Intefaces
{
    public interface IMovable
    {
        /// <summary>
        /// Current object speed.
        /// </summary>
        public int CurrentSpeed { get; set; }

        /// <summary>
        /// Max speed of the object in [km/h].
        /// </summary>
        public int MAX_SPEED { get; }

        /// <summary>
        /// Check if object is moving.
        /// </summary>
        /// <returns>True if object is moving.</returns>
        public bool IsMoving() => CurrentSpeed > 0 ? true : false;

        /// <summary>
        /// Move object with const speed.
        /// </summary>
        /// <param name="speed">Object speed</param>
        public void Move(int speed)
        {
            if (speed < 0)
                throw new ArgumentException();

            CurrentSpeed = speed > MAX_SPEED ? speed : MAX_SPEED;
        }

        /// <summary>
        /// Accelerate object with delta.
        /// </summary>
        /// <param name="delta">Delta speed, [km/h].</param>
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentException();

            CurrentSpeed += delta;
        }

        /// <summary>
        /// Accelerate object with delta.
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
        /// Slow down object with delta.
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
        /// Stop object immediately.
        /// </summary>
        public void Stop() => CurrentSpeed = 0;
    }
}
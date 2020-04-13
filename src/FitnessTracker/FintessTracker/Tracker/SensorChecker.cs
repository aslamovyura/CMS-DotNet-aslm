using System;
using System.Collections.Generic;
using FitnessTracker.Sensors;

namespace FitnessTracker.Tracker
{
    /// <summary>
    /// Class for checking the status of the number of sensors.
    /// </summary>
    public class SensorChecker
    {
        // Sensors.
        public List<Sensor> Sensors { get; } = new List<Sensor>();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SensorChecker() { }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SensorChecker(List<Sensor> sensors) => Sensors = sensors;

        public int GetSensorsNumber()
        {
            return Sensors.Count;
        }

        /// <summary>
        /// Add new sensor for tracking.
        /// </summary>
        /// <param name="sensor">New sensor.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddSensor(Sensor sensor)
        {
            if (sensor != null)
                Sensors.Add(sensor);
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Stop checking the status of particular sensor.
        /// </summary>
        /// <param name="sensor">New sensor.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveSensor(int index)
        {
            if (Sensors.Count == 0 || index < 0 || index > Sensors.Count-1)
                throw new IndexOutOfRangeException();
            Sensors.RemoveAt(index);
        }

        /// <summary>
        /// Stop interrogatino all sensors.
        /// </summary>
        public void RemoveAllSensors() => Sensors.Clear();

        /// <summary>
        /// Reset all sensors measured data.
        /// </summary>
        public void Reset() => Sensors.ForEach(a => a.Reset());

        /// <summary>
        /// Check sensors status.
        /// </summary>
        /// <param name="state">State handler.</param>
        public void CheckStatus(object state)
        {
            var time = DateTime.Now.ToString("hh:mm:ss\n");

            Console.Clear();
            Console.WriteLine($"**************************");
            Console.WriteLine($"****** Health check ******");
            Console.WriteLine($"**************************\n");
            Console.WriteLine($"Time : {time}");

            if (Sensors.Count == 0)
            {
                Console.WriteLine("--No data --");
                return;
            }

            foreach (var s in Sensors)
                Console.WriteLine($"{s.Type} : {s.Measure(),2:N}, {s.Units}.");
        }
    }
}
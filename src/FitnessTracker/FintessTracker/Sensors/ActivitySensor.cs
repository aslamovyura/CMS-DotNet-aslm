using System;
namespace FitnessTracker.Sensors
{
    /// <summary>
    /// Sensor to measure human activity (number of steps);
    /// </summary>
    public class ActivitySensor : Sensor, IMeasure
    {
        /// <summary>
        /// Sensor type.
        /// </summary>
        public override SensorType Type { get; } = SensorType.Activity;

        /// <summary>
        /// Measurement units.
        /// </summary>
        public override string Units { get; } = "steps";

        /// <summary>
        /// Defaule constructor.
        /// </summary>
        public ActivitySensor() => Reset();

        /// <summary>
        /// Activity sensor constructor.
        /// </summary>
        /// <param name="initialData">Initial steps number.</param>
        public ActivitySensor(double initialData)
        {
            InitialData = (initialData > 0) ? initialData : throw new ArgumentOutOfRangeException();
            _data = InitialData;
        }

        /// <summary>
        /// Measure new temperature data.
        /// </summary>
        public override double Measure()
        {
            // Imitation of variation of the number of steps between measurements
            // by + [0 ... 4] steps.
            Random generator = new Random();
            _data += generator.Next(0, 5);

            return _data;
        }
    }
}
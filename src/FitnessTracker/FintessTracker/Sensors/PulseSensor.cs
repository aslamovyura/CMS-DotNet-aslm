using System;
namespace FitnessTracker.Sensors
{
    /// <summary>
    /// Sensor to measure pulse.
    /// </summary>
    public class PulseSensor : Sensor, IMeasure
    {
        // Measurement range.
        private const double MIN_PULSE = 30;
        private const double MAX_PULSE = 120;

        /// <summary>
        /// Initial sensor data (after reset).
        /// </summary>
        protected override double InitialData { get; set; } = 60;

        /// <summary>
        /// Sensor type.
        /// </summary>
        public override SensorType Type { get; } = SensorType.Pulse;

        /// <summary>
        /// Measurement units.
        /// </summary>
        public override string Units { get; } = "per min";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PulseSensor() => Reset();

        /// <summary>
        /// Pulse sensor constructor.
        /// </summary>
        /// <param name="initialData">Initial pulse.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public PulseSensor(double initialData)
        {
            InitialData = (initialData > 0) ? initialData : throw new ArgumentOutOfRangeException();
            _data = InitialData;
        }

        /// <summary>
        /// Measure new temperature data.
        /// </summary>
        public override double Measure()
        {
            // Imitation of pulse variation between measurements by +/- 5.
            int delta = 5;
            Random generator = new Random();
            _data += Math.Round(Convert.ToDouble(generator.Next(-delta*10/2, delta*10/2)) / 10, 1);

            if (_data > MAX_PULSE)
                _data = MAX_PULSE;

            if (_data < MIN_PULSE)
                _data = MIN_PULSE;

            return _data;
        }
    }
}
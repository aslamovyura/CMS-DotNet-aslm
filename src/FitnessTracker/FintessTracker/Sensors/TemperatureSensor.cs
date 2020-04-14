using System;
namespace FitnessTracker.Sensors
{
    /// <summary>
    /// Sensor to measure temperature.
    /// </summary>
    public class TemperatureSensor : Sensor, IMeasure
    {
        // Measurement range.
        private const double MIN_TEMP = 36.0;
        private const double MAX_TEMP = 40.0;

        /// <summary>
        /// Initial sensor data (after reset).
        /// </summary>
        protected override double InitialData { get; set; } = 36.6;

        /// <summary>
        /// Sensor type.
        /// </summary>
        public override SensorType Type { get; } = SensorType.Temperature;

        /// <summary>
        /// Measurement units.
        /// </summary>
        public override string Units { get; } = "°C";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TemperatureSensor() => Reset();

        /// <summary>
        /// Temperature sensor constructor.
        /// </summary>
        /// <param name="initialData">Initial temperature.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public TemperatureSensor(double initialData)
        {
            InitialData = (initialData>0)? initialData : throw new ArgumentOutOfRangeException();
            _data = InitialData;
        }

        /// <summary>
        /// Measure new temperature data.
        /// </summary>
        public override double Measure()
        {
            // Imitation of temperature variation between measurements
            // by +/- 0.1.
            Random generator = new Random();
            _data += Math.Round(Convert.ToDouble(generator.Next(-1, 2))/10,1);

            if (_data > MAX_TEMP)
                _data = MAX_TEMP;

            if (_data < MIN_TEMP)
                _data = MIN_TEMP;

            return _data;
        }
    }
}
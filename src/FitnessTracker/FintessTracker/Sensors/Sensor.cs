namespace FitnessTracker.Sensors
{
    /// <summary>
    /// Prototype of all sensors classes.
    /// </summary>
    abstract public class Sensor
    {
        /// <summary>
        /// Last measured data.
        /// </summary>
        protected double _data;

        /// <summary>
        /// Data after reset.
        /// </summary>
        protected virtual double InitialData { get; set; } = 0;

        /// <summary>
        /// Sensor type.
        /// </summary>
        public virtual SensorType Type { get; }

        /// <summary>
        /// Measurement units.
        /// </summary>
        public virtual string Units { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sensor() => Reset();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sensor(double initialData)
        {
            InitialData = initialData;
            _data = InitialData;
        }

        /// <summary>
        /// Get last data from sensor.
        /// </summary>
        /// <returns>Current measured data.</returns>
        public double Get() => _data;

        /// <summary>
        /// Reset last measurements.
        /// </summary>
        public void Reset() => _data = InitialData;

        /// <summary>
        /// Measure data.
        /// </summary>
        public abstract double Measure();

        /// <summary>
        /// Get sensor info as a string.
        /// </summary>
        /// <returns>Sensor info.</returns>
        public override string ToString() => $"Measuring data: {Type}";
    }
}
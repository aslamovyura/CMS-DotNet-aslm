using System;
using System.Threading;
using FitnessTracker.Tracker;
using FitnessTracker.Sensors;

namespace FintessTracker.Tracker
{
    /// <summary>
    /// Fitness/health tracker based on measurement from several sensors.
    /// </summary>
    public class HealthTracker : IDisposable
    {
        // Tracker state
        private bool _isActive = false;

        // Sensors.
        private SensorChecker Sensors = new SensorChecker();

        // Timer to interrogate sensors.
        private Timer StateTimer { get; set; } = null;

        /// <summary>
        /// Time intarval (ms) between sensors interrogating.
        /// </summary>
        public int CheckInteval { get; set; } = 1000; // ms

        /// <summary>
        /// Default tracker constructor.
        /// </summary>
        public HealthTracker()
        {
            Sensors.AddSensor(new TemperatureSensor());
            Sensors.AddSensor(new PulseSensor());
            Sensors.AddSensor(new ActivitySensor());
            Sensors.Reset();
        }

        /// <summary>
        /// Start sensors interrogating & health tracking.
        /// </summary>
        public void Run()
        {
            if (StateTimer == null)
                StateTimer = new Timer(Sensors.CheckStatus,
                                       state: null,
                                       dueTime: CheckInteval,
                                       period: CheckInteval);
            else
                StateTimer.Change(dueTime: CheckInteval,
                                  period: CheckInteval);
            _isActive = true;
        }

        /// <summary>
        /// Stop sensors interrogating & health tracking.
        /// </summary>
        public void Stop()
        {
            if (StateTimer == null)
            {
                Console.WriteLine("\nFitness tracker is not started yet!");
                return;
            }
            StateTimer.Change(Timeout.Infinite, Timeout.Infinite);

            Console.WriteLine("\nFitness tracker is stopped!");
            _isActive = false;
        }

        /// <summary>
        /// Run or stop tracker, depending on previous state.
        /// </summary>
        public void RunOrStop()
        {
            if (_isActive)
                Stop();
            else
                Run();
        }

        /// <summary>
        /// Reser sensors measurement.
        /// </summary>
        public void Reset() => Sensors.Reset();

        /// <summary>
        /// Quit tracker.
        /// </summary>
        public void Quit()
        {
            Stop();
            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// Dispose fitness tracker.
        /// </summary>
        public void Dispose()
        {
            StateTimer.Dispose();
            Sensors = null;
        }
    }
}
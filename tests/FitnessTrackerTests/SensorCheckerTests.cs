using FitnessTracker.Sensors;
using FitnessTracker.Tracker;
using Xunit;

namespace FitnessTrackerTests
{
    public class SensorCheckerTests
    {
        public SensorChecker Checker { get; set; }

        public SensorCheckerTests()
        {
            Checker = new SensorChecker();
        }

        [Fact]
        public void SensorChecker_WhenLoadedGetSensorsList_Renurn_EmptyList()
        {
            // Arrange
            var expected = 0;

            // Act
            var actual = Checker.GetSensorsNumber();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SensorChecker_AddNullSensor_Renurn_Exception()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                Checker.AddSensor(null);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void SensorChecker_AddSensor_Return_IncreaseSensorsBy1()
        {
            // Arrange
            int expected = Checker.GetSensorsNumber() + 1;
            TemperatureSensor sensor = new TemperatureSensor();

            // Act
            Checker.AddSensor(sensor);
            int actual = Checker.GetSensorsNumber();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SensorChecker_RemoveSensorWithNegativeIndex_Return_Exception()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                Checker.RemoveSensor(-1);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void SensorChecker_RemoveSensorFromEmptySensorsList_Return_Exception()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                Checker.RemoveSensor(1);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void SensorChecker_RemoveSensorWithIndexGreaterThenSensorsCount_Return_Exception()
        {
            // Arrange
            bool isException = false;
            TemperatureSensor sensor = new TemperatureSensor();

            // Act
            Checker.AddSensor(sensor);
            int index = Checker.GetSensorsNumber() + 5;

            try
            {
                Checker.RemoveSensor(index);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }
    }
}

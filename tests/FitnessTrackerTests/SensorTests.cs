using Xunit;
using FitnessTracker.Sensors;

namespace FitnessTrackerTests
{
    public class SensorTests
    {
        public TemperatureSensor tSensor { get; set; }
        public PulseSensor pSensor { get; set; }
        public ActivitySensor aSensor { get; set; }

        public SensorTests()
        {
            tSensor = new TemperatureSensor();
            pSensor = new PulseSensor();
            aSensor = new ActivitySensor();
        }

        // ****************** Temperature Tests ****************** //

        [Fact]
        public void TemperatureSensor_WhenLoadedGetInitialData_Return_36_6()
        {
            // Arrange
            double expected = 36.6;

            // Act
            double actual = tSensor.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TemperatureSensor_WhenLoadedGetType_Return_Temperature()
        {
            // Arrange
            var expected = SensorType.Temperature;

            // Act
            var actual = tSensor.Type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TemperatureSensor_Measure_Return_TemperatureGreaterThen36()
        {
            // Arrange
            var threshold = 36.0;

            // Act
            var actual = tSensor.Measure();

            // Assert
            Assert.True(actual >= threshold);
        }

        [Fact]
        public void TemperatureSensor_Measure_Return_TemperatureLowerThen40()
        {
            // Arrange
            var expected = 40.0;

            // Act
            var actual = tSensor.Measure();

            // Assert
            Assert.True(actual <= expected);
        }

        // ********************** Pulse Tests ********************** //

        [Fact]
        public void PuleSensor_WhenLoadedGetInitialData_Return_60()
        {
            // Arrange
            double expected = 60.0;

            // Act
            double actual = pSensor.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PuleSensor_WhenLoadedGetType_Return_Pulse()
        {
            // Arrange
            var expected = SensorType.Pulse;

            // Act
            var actual = pSensor.Type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PuleSensor_Measure_Return_TemperatureGreaterThen30()
        {
            // Arrange
            var threshold = 30.0;

            // Act
            var actual = pSensor.Measure();

            // Assert
            Assert.True(actual >= threshold);
        }

        [Fact]
        public void PuleSensor_Measure_Return_TemperatureLowerThen120()
        {
            // Arrange
            var expected = 120.0;

            // Act
            var actual = pSensor.Measure();

            // Assert
            Assert.True(actual <= expected);
        }

        // ******************** Activity Tests ******************* //

        [Fact]
        public void ActivitySensor_WhenLoadedGetInitialData_Return_0()
        {
            // Arrange
            double expected = 0.0;

            // Act
            double actual = aSensor.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ActivitySensor_WhenLoadedGetType_Return_Activity()
        {
            // Arrange
            var expected = SensorType.Activity;

            // Act
            var actual = aSensor.Type;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ActivitySensor_Measure_Return_TemperatureGreaterThen0()
        {
            // Arrange
            var threshold = 0.0;

            // Act
            var actual = aSensor.Measure();

            // Assert
            Assert.True(actual >= threshold);
        }
    }
}
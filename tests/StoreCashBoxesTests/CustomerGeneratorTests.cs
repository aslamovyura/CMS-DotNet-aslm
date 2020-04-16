using System;
using StoreCashBoxes;
using System.Collections.Generic;
using Xunit;
using System.Threading;

namespace StoreCashBoxesTests
{
    public class CustomerGeneratorTests
    {
        private CustomerGenerator Generator;

        public CustomerGeneratorTests()
        {
            object locker = new object();
            Generator = new CustomerGenerator(locker);
        }

        [Fact]
        public void CustomerGenerator_WhenInitWithNullLocker_Return_ArgumentNullException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                CustomerGenerator generator = new CustomerGenerator(null);
            }
            catch (ArgumentNullException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void CustomerGenerator_WhenStartWithNullCustomerList_Return_Exception()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                Generator.Start(null);
            }
            catch (ArgumentNullException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void CustomerGenerator_WhenCreated_Return_ZeroCounter()
        {
            // Arrange 
            var expected = 0;

            // Act
            var actual = Generator.GetCounter();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CustomerGenerator_WhenReset_Return_ZeroCounter()
        {
            // Arrange 
            var expected = 0;

            // Act
            List<Customer> customers = new List<Customer>();
            Generator.Start(customers);
            Thread.Sleep(Generator.GenerationTimeInterval * 3);

            Generator.Stop();
            Generator.Reset();
            var actual = Generator.GetCounter();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CustomerGenerator_WhenStopped_Return_InfiniteGenerationTimeInterval()
        {
            // Arrange 
            var expected = Timeout.Infinite;

            // Act
            List<Customer> customers = new List<Customer>();
            Generator.Start(customers);
            Thread.Sleep(Generator.GenerationTimeInterval * 3);

            Generator.Stop();
            var actual = Generator.GenerationTimeInterval;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CustomerGenerator_WhenSetNegativeGenerationTimeInterval_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                Generator.GenerationTimeInterval = -10;
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }
    }
}
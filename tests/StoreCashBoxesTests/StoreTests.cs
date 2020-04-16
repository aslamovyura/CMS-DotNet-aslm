using System;
using StoreCashBoxes;
using Xunit;
using System.Threading;
using System.Collections.Generic;

namespace StoreCashBoxesTests
{
    public class StoreTests
    {
        private Store Store;

        public StoreTests()
        {
            Store = new Store();
        }

        [Fact]
        public void Store_WhenCreatedCheckIsAnyCustomerInStore_Return_False()
        {
            // Arrange

            // Act
            bool actual = Store.IsAnyCustomerInStore();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void Store_WhenCreatedGetCustomerGenerationTimeInterval_Return_5000()
        {
            // Arrange
            var expected = 5000;

            // Act
            var actual = Store.CustomerGenerationTimeInterval;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Store_WhenCreatedWithNegativeCashBoxesNumber_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = -5;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithZeroCashBoxesNumber_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 0;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithCashBoxesNumberGreaterThan30_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 35;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithNegativeFastCashBoxesNumber_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 5;
            var fastCashBoxesNumber = -5;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber, fastCashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithZeroFastCashBoxesNumber_Return_OK()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 5;
            var fastCashBoxesNumber = 0;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber, fastCashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.False(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithNumberOfFastCashBoxesGreaterThan5_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 5;
            var fastCashBoxesNumber = 5;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber, fastCashBoxesNumber);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithNegativeCustomerGenerationTimeInterval_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 5;
            var fastCashBoxesNumber = 1;
            var customerGenerationTimeInterval = -10;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber, fastCashBoxesNumber, customerGenerationTimeInterval);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenCreatedWithInfiniteCustomerGenerationTimeInterval_Return_OK()
        {
            // Arrange
            var isException = false;
            var cashBoxesNumber = 5;
            var fastCashBoxesNumber = 1;
            var customerGenerationTimeInterval = Timeout.Infinite;

            // Act
            try
            {
                Store store = new Store(cashBoxesNumber, fastCashBoxesNumber, customerGenerationTimeInterval);
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }

            // Assert
            Assert.False(isException);
        }

        [Fact]
        public void Store_WhenDictributeCustomersInQueuesWithNullArg_Return_ArgumentNullException()
        {
            // Arrange
            var isException = false;

            // Act
            try
            {
                Store.DictributeCustomersInQueues(null);
            }
            catch (ArgumentNullException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenDictributeCustomersInQueuesWithListOnNonCustomersArg_Return_InvalidCastException()
        {
            // Arrange
            var isException = false;

            // Act
            try
            {
                Store.DictributeCustomersInQueues(new List<object>());
            }
            catch (InvalidCastException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Store_WhenClosedAfterOpen_Return_ZeroNumberOfCashBoxes()
        {
            // Arrange
            var expected = 0;

            // Act
            Store.Open();
            Store.Close();
            var actual = Store.CashBoxes.Count;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
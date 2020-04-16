using System;
using StoreCashBoxes;
using Xunit;
using System.Threading;

namespace StoreCashBoxesTests
{
    public class CashBoxTests
    {
        private CashBox CashBox;

        public CashBoxTests()
        {
            CashBox = new CashBox();
        }

        [Fact]
        public void CashBox_WhenCreated_Return_ZeroQueue()
        {
            // Arrange
            var expected = 0;

            // Act
            var actual = CashBox.GetQueueLength();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CashBox_WhenCreatedIsEmpty_Return_True()
        {
            // Arrange

            // Act
            var actual = CashBox.IsEmpty();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void CashBox_WhenSetNegativeServiceTimePerUnit_Return_ArgumentOutOfRangeException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                CashBox.ServiceTimePerUnit = -10;
            }
            catch (ArgumentOutOfRangeException)
            {
                isException = true;
            }
            
            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void CashBox_WhenSetInfiniteServiceTimePerUnit_Return_NoException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                CashBox.ServiceTimePerUnit = Timeout.Infinite;
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.False(isException);
        }

        [Fact]
        public void CashBox_WhenAddNullCustomer_Return_ArgumentNullException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                CashBox.AddNewCustomer(null);
            }
            catch (ArgumentNullException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void CashBox_WhenAddNonCustomerObject_Return_InvalidCastException()
        {
            // Arrange
            bool isException = false;

            // Act
            try
            {
                CashBox.AddNewCustomer(new object());
            }
            catch (InvalidCastException)
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void CashBox_WhenAddNewCustomer_Return_QueueIncreasedBy1()
        {
            // Arrange
            var expected = 1;

            // Act
            CashBox.AddNewCustomer(new Customer());
            var actual = CashBox.GetQueueLength();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
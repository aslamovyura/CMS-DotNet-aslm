using System;
using Xunit;
using SimpleCashMachine;

namespace SimpleCashMachineTests
{
    public class AccountTests
    {
        public Account account;

        public AccountTests()
        {
            account = new Account(id: 106, sum: 250, NotificationType.Sms, adress: "+375447893922");
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData (100, false)]
        [InlineData(200, false)]
        [InlineData(300, true)]
        [InlineData(1000, true)]
        public void Account_WhenTakeMoneyMoreThanExist_Return_Exception(decimal sum, bool isExceptionExpected)
        {
            // Arrange
            bool isExceptionActual = false;

            // Act
            try
            {
                account.TakeMoney(sum);
            }
            catch
            {
                isExceptionActual = true;
            }

            // Assert
            Assert.Equal(isExceptionExpected,isExceptionActual);
        }

        [Theory]
        [InlineData(-503.2, true)]
        [InlineData(-100, true)]
        [InlineData(0, false)]
        [InlineData(100, false)]
        public void Account_WhenTryToTakeNegariveSumOfMoney_Return_Exception(decimal sum, bool isExceptionExpected)
        {
            // Arrange
            bool isExceptionActual = false;

            // Act
            try
            {
                account.TakeMoney(sum);
            }
            catch
            {
                isExceptionActual = true;
            }

            // Assert
            Assert.Equal(isExceptionExpected, isExceptionActual);
        }

        [Fact]
        public void Account_WhenAccountBalanceIsEqualToZero_Return_IsEmptyTrue()
        {
            // Arrange
            account.TakeMoney(account.GetAccountBalance());

            // Act
            bool isEmpty = account.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }
    }
}
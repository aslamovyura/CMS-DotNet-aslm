using System;
using System.Collections.Generic;
using Xunit;
using SimpleCashMachine;

namespace SimpleCashMachineTests
{
    public class BankTests
    {
        public BankServer Bank { get; set; }

        public BankTests()
        {
            Bank = new BankServer();
        }

        [Fact]
        public void BankSerser_WhenNotLoadDefaultClientBase_Return_0Clients()
        {
            // Arrange
            int expectedClientsNumber = 0;

            // Act
            int actualClientsNumber = Bank.GetClientsNumber();

            // Assert
            Assert.Equal(expectedClientsNumber, actualClientsNumber);
        }

        [Fact]
        public void BankServer_WhenLoadDefaultZoo_Return_13Animals()
        {
            // Arrange
            int expectedDefaultClientsNumber = 4;

            // Act
            Bank.LoadDefaultClientBase();
            int actualClientsNumber = Bank.GetClientsNumber();

            // Assert
            Assert.Equal(expectedDefaultClientsNumber, actualClientsNumber);
        }

        [Fact]
        public void BankServer_WhenAddClientIsOk_Increase_ClientsNumberBy1()
        {
            // Arrange
            Client client = new Client(firstName: "George", lastName: "Tudor", age: 41, id: 15435);
            client.CreateNewAccount(id: 106, sum: 194895);
            int startNumber = Bank.GetClientsNumber();

            // Act
            Bank.AddNewClient(client);
            int newNumber = Bank.GetClientsNumber();

            // Assert
            Assert.Equal(startNumber + 1, newNumber);
        }

        [Fact]
        public void BankServer_WhenRemoveClientIsOk_Decrease_ClientsNumberBy1()
        {
            // Arrange
            Bank.LoadDefaultClientBase();
            int startNumber = Bank.GetClientsNumber();

            List<int> keys = Bank.GetClientsIdList();
            Client client = Bank.GetClient(keys[0]);

            // Act
            Bank.RemoveClient(client);
            int newNumber = Bank.GetClientsNumber();

            // Assert
            Assert.Equal(startNumber - 1, newNumber);
        }

        [Fact]
        public void BankServefr_WhenTryToRemoveClientFromEmptyBank_Return_Exception()
        {
            // Arrange
            Client client = new Client(firstName: "George", lastName: "Tudor", age: 41, id: 15435);
            client.CreateNewAccount(id: 106, sum: 194895);
            bool isException = false;

            // Act
            try
            {
                Bank.RemoveClient(client);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void BankServer_WhenTryToRemoveNonexistingClientFromBank_Return_Exception()
        {
            // Arrange
            Bank.LoadDefaultClientBase();
            Client client = new Client(firstName: "George", lastName: "Tudor", age: 41, id: 15435);
            client.CreateNewAccount(id: 106, sum: 194895);
            bool isException = false;

            // Act
            try
            {
                Bank.RemoveClient(client);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void BankServer_WhenInstallConnectionWithNonCashMachine_Return_False()
        {
            // Arrange
            object temp = new object();
            int clientID = 8888;

            // Act
            bool success = Bank.RequestConnection(temp, clientID);

            // Assert
            Assert.False(success);
        }
    }
}
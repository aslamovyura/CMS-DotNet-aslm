using System;
using System.Collections.Generic;
using SimpleCashMachine.Bank;
using System.Linq;

namespace SimpleCashMachine
{
    public class BankServer
    {
        /// <summary>
        /// Bank client database.
        /// </summary>
        private Dictionary<int, Client> _clientBase = new Dictionary<int, Client>();

        /// <summary>
        /// Load default bank client base.
        /// </summary>
        public void LoadDefaultClientBase()
        {
            Client client = new Client(firstName: "Jhon", lastName: "Smith", age: 22, id: 10293);
            client.CreateNewAccount(id: 100, sum: 200);
            client.CreateNewAccount(id: 101, sum: 2500, NotificationType.Email, adress: "jhon@gmail.com");
            AddNewClient(client);

            Client client1 = new Client(firstName: "Marry", lastName: "Simpson", age: 45, id: 12045);
            client1.CreateNewAccount(id: 102, sum: 23495, NotificationType.Sms, adress: "+3752965445653");
            AddNewClient(client1);

            Client client2 = new Client(firstName: "Peter", lastName: "Parker", age: 25, id: 34045);
            client2.CreateNewAccount(id: 103, sum: 1000000, NotificationType.Sms, adress: "+3752965445653");
            AddNewClient(client2);

            Client client3 = new Client(firstName: "Tommy", lastName: "Versetti", age: 35, id: 98645);
            client3.CreateNewAccount(id: 104, sum: 98543,NotificationType.Email, adress: "call2tommy@rambler.com");
            AddNewClient(client3);
        }

        /// <summary>
        /// Add new client to the bank database.
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddNewClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException();

            _clientBase.Add(key: client.ID, client);
        }

        /// <summary>
        /// Add new client to the bank database.
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException();

            if (_clientBase.ContainsKey(client.ID))
                _clientBase.Remove(client.ID);
            else
                throw new ArgumentOutOfRangeException("This client does not exist!");
        }

        /// <summary>
        /// Get number of bank clients.
        /// </summary>
        /// <returns>Clients number.</returns>
        public int GetClientsNumber() => _clientBase.Count;

        /// <summary>
        /// Return client in database by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Client GetClient(int key) => _clientBase.GetValueOrDefault(key);

        /// <summary>
        /// Check if bank is empty.
        /// </summary>
        /// <returns>True, if bank is empty.</returns>
        public bool IsEmpty() => _clientBase.Count == 0 ? true : false;

        /// <summary>
        /// Get list cliens IDs.
        /// </summary>
        /// <returns>List of IDs.</returns>
        public List<int> GetClientsIdList() => IsEmpty()? new List<int>() : _clientBase.Keys.ToList();

        /// <summary>
        /// Process connection request form cash machine.
        /// </summary>
        /// <param name="sender">Cash machine object.</param>
        /// <returns>Connection status (true/false).</returns>
        public bool RequestConnection(object sender) => (sender is CashMachine)? true : false;

        /// <summary>
        /// Process connection request from cash machine.
        /// </summary>
        /// <param name="sender">Cash machine object.</param>
        /// <param name="accountID">Account Identifier.</param>
        /// <returns>Connection status (true/false).</returns>
        public bool RequestConnection(object sender, int accountID)
        {
            if ((sender is CashMachine) && GetAccount(accountID) != null)
                return true;
            return false;
        }

        /// <summary>
        /// Print the whole client database.
        /// </summary>
        public void Show()
        {
            Console.WriteLine("\n\n\n\n\n************************************* ");
            Console.WriteLine("*********** Bank Database *********** ");
            Console.WriteLine("*************************************\n\n");
            foreach (var obj in _clientBase)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(obj.Value.ToString());
            }
            Console.WriteLine("----------------------------------------------");
        }

        /// <summary>
        /// Get account from client database.
        /// </summary>
        /// <param name="accountID">Account ID.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Account GetAccount(int accountID)
        {
            if (accountID < 0)
                throw new ArgumentOutOfRangeException("Account ID cannot be negative!");
            return _clientBase.Select(c => c.Value.GetAccountsList().FirstOrDefault(a => a.ID == accountID)).Where(f => f != null).FirstOrDefault();
        }
            
        /// <summary>
        /// Get account from client database.
        /// </summary>
        /// <param name="clientID">Client Identifier.</param>
        /// <param name="accountID">Account Identifier.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Account GetAccount(int clientID, int accountID)
        {
            if (clientID < 0)
                throw new ArgumentOutOfRangeException("Client ID cannot be negative!");

            if (accountID < 0)
                throw new ArgumentOutOfRangeException("Account ID cannot be negative!");

            if (_clientBase.ContainsKey(clientID))
                return _clientBase.GetValueOrDefault(clientID).GetAccountsList().FirstOrDefault(a => a.ID == accountID);
            else
                throw new ArgumentException("Unknown client ID!");
        }

        /// <summary>
        /// Print the whole client database.
        /// </summary>
        public void ShowAccount(int accountID)
        {
            var account = GetAccount(accountID);
            if (account == null)
                Console.WriteLine("There is no account with such ID");

            Console.WriteLine("Account info:");
            Console.WriteLine(account);
        }
    }
}
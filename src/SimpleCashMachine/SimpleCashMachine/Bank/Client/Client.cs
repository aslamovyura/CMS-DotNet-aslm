using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCashMachine
{
    /// <summary>
    /// Bank client.
    /// </summary>
    public class Client : Person
    {
        /// <summary>
        /// List of person accounts in bank;
        /// </summary>
        private List<Account> Accounts { get; set; } = new List<Account>();

        /// <summary>
        /// Type of notifications to sent to client.
        /// </summary>
        public NotificationType NotificationType { get; set; } = NotificationType.Sms;

        ///// <summary>
        ///// Client notification.
        ///// </summary>
        //public T Notification { get; set; }

        /// <summary>
        /// Defaul client constructor without parameters.
        /// </summary>
        public Client() { }

        /// <summary>
        /// Client constructor.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="age">Client age [years].</param>
        /// <param name="id">Identifier.</param>
        public Client(string firstName, string lastName, int age, int id)
            : base(firstName, lastName, age, id) { }

        /// <summary>
        /// Create new user account in the bank.
        /// </summary>
        /// <param name="id">Positive Identifier.</param>
        public void CreateNewAccount(int id) => CreateNewAccount(id, 0, NotificationType.None, string.Empty);

        /// <summary>
        /// Create new user account in the bank.
        /// </summary>
        /// <param name="id">Positive Identifier.</param>
        /// <param name="type">Type of notifications.</param>
        public void CreateNewAccount(int id, NotificationType type, string adress) => CreateNewAccount(id, 0, type, adress);

        /// <summary>
        /// Create new user account in the bank.
        /// </summary>
        /// <param name="id">Positive Identifier.</param>
        /// <param name="sum">Initial sum, $.</param>
        /// <param name="type">Type of notifications.</param>
        public void CreateNewAccount(int id, decimal sum, NotificationType type, string adress)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException();
            else
            {
                Account newAccount = new Account(id, sum, type, adress);
                Accounts.Add(newAccount);
            }
        }

        /// <summary>
        /// Get account with defined identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Client account.</returns>
        public Account GetAccount(int id) => Accounts.Where(a => a.ID == id).Select(a => a).FirstOrDefault();

        /// <summary>
        /// Get all accounts of the user.
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccountsList() => Accounts;

        /// <summary>
        /// Remove account with defined identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void RemoveAccount(int id)
        {
            var account = GetAccount(id);
            account.OnDelete();
            Accounts.Remove(account);
        }

        // ************************* IPay ************************** //

        /// <summary>
        /// Put money to the account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="sum">Sum of money, $.</param>
        public void PutMoney(int accountId, decimal sum)
        {
            var account = GetAccount(accountId);
            account.PutMoney(sum);
        }

        /// <summary>
        /// Take money from the account.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <param name="sum">Sum of money, $.</param>
        public void TakeMoney(int accountId, decimal sum)
        {
            var account = GetAccount(accountId);
            account.TakeMoney(sum);
        }

        /// <summary>
        /// Check if the account is empty.
        /// </summary>
        /// <param name="accountId">Account ID.</param>
        /// <returns>True, if account is empty.</returns>
        public bool IsEmpty(int accountId)
        {
            var account = GetAccount(accountId);
            return account.IsEmpty();
        }

        /// <summary>
        /// Convert client info to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info = $"Clint : {FirstName} {LastName} ({Age} y.), ID: {ID}\n";
            foreach (Account a in Accounts)
                info += a.ToString();
            return info;
        }
    }
}
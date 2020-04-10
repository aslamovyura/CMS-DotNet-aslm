using System;
using SimpleCashMachine.Interfaces;
using SimpleCashMachine.Bank.Notifications;

namespace SimpleCashMachine
{
    public class Account : IPay
    {
        /// <summary>
        /// The amount of money on the user account [$].
        /// </summary>
        private decimal _balance = 0;

        /// <summary>
        /// Account identifier.
        /// </summary>
        private int _id = 0;

        /// <summary>
        /// Account Identifier.
        /// </summary>
        public int ID
        {
            get => _id;
            set => _id = (value >= 0) ? value : throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// User notifications.
        /// </summary>
        private Notification Notification { get; set; }

        /// <summary>
        /// Default account constructor without parameters.
        /// </summary>
        public Account() => RegisterEvents();

        /// <summary>
        /// Account constructor.
        /// </summary>
        /// <param name="id">Account identifier.</param>
        /// <param name="sum">Initial sum [$].</param>
        public Account(int id, decimal sum)
        {
            ID = id;
            PutMoney(sum);

            RegisterEvents();
            OnCreate();
        }

        /// <summary>
        /// Account constructor.
        /// </summary>
        /// <param name="id">Account identifier.</param>
        /// <param name="sum">Initial sum [$].</param>
        public Account(int id, decimal sum, NotificationType type, string adress)
        {
            ID = id;
            PutMoney(sum);

            RegisterEvents(type, adress);
            OnCreate();
        }

        // *************************** Functions *************************** //

        /// <summary>
        /// Action on transaction.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="sum"></param>
        public void OnTransaction(string transaction, decimal sum) => Transaction?.Invoke(transaction, sum);

        /// <summary>
        /// Action on creation.
        /// </summary>
        public void OnCreate()
        {
            string message = OnCreateMessage();
            message += CurrentBananceMessage();
            Created?.Invoke(message);
        }

        /// <summary>
        /// Action of deletion.
        /// </summary>
        public void OnDelete() => Deleted?.Invoke(OnDeleteMessage());

        /// <summary>
        /// Register events of the bank account.
        /// </summary>
        public void RegisterEvents(NotificationType type, string adress)
        {
            // Configure user notifications.
            RegisterNotifications(type, adress);

            // Configure funcs & actions
            CalculationFunc = CalculateCapitalization;
            TransactionAction = OnTransaction;

            // Configure to send notifications on account events.
            Transaction += (transaction, sum) => this.Notification.Send(NewTransactionMessage(transaction, sum));
            Created += (msg) => this.Notification.Send(msg);
            Deleted += (msg) => this.Notification.Send(msg);
        }

        /// <summary>
        /// Register events of the bank account (disable events).
        /// </summary>
        public void RegisterEvents() => RegisterEvents(NotificationType.None, string.Empty);

        /// <summary>
        /// Register user notifications.
        /// </summary>
        /// <param name="type">Notifications type (sms, email, none).</param>
        /// <param name="adress">Notification adress (email, phone number).</param>
        public void RegisterNotifications(NotificationType type, string adress)
        {
            switch (type)
            {
                case NotificationType.Email:
                    this.Notification = new EmailNotification(adress);
                    break;

                case NotificationType.Sms:
                    this.Notification = new SmsNotification(adress);
                    break;

                case NotificationType.None:
                    break;

                default:
                    throw new ArgumentException("Unknown notification type!");
            }
        }

        /// <summary>
        /// Put some money to the account.
        /// </summary>
        /// <param name="sum">Sum of money [$].</param>
        public void PutMoney(decimal sum)
        {
            _balance += (sum >= 0) ? sum : throw new ArgumentOutOfRangeException();
            //Transaction?.Invoke("put", sum);      // push as event
            TransactionAction?.Invoke("take", sum); // push as action
        }

        /// <summary>
        /// Take some amout on money from the account.
        /// </summary>
        /// <param name="sum">Sum of money [$].</param>
        public void TakeMoney(decimal sum)
        {
            _balance -= (sum <= _balance) ? sum : throw new ArgumentOutOfRangeException();
            //Transaction?.Invoke("take", sum);     // push as event
            TransactionAction?.Invoke("take", sum); // push as action
        }

        /// <summary>
        /// Check if the account is empty.
        /// </summary>
        /// <returns>True, if account is empty.</returns>
        public bool IsEmpty() => (_balance == 0) ? true : false;

        /// <summary>
        /// Show current account balance.
        /// </summary>
        public void ViewAccountBanance() => Console.WriteLine($"Current balance: {_balance}$\n");

        /// <summary>
        /// Get string with info about current balance;
        /// </summary>
        /// <returns></returns>
        private string OnCreateMessage() => $"New account {ID} created!\n";

        /// <summary>
        /// Get string with info about current balance;
        /// </summary>
        /// <returns></returns>
        private string OnDeleteMessage() => $"Your account {ID} is deleted!\n";

        /// <summary>
        /// Get string with info about current balance;
        /// </summary>
        /// <returns></returns>
        private string CurrentBananceMessage() => $"Current balance: {_balance}$\n";

        /// <summary>
        /// Get new transaction message.
        /// </summary>
        /// <param name="operation">Operation name: put|take.</param>
        /// <param name="sum">Sum, $.</param>
        private string NewTransactionMessage(string operation, decimal sum)
        {
            string message = $"New transaction in your account #{ID}:\n";
            switch (operation.ToLower())
            {
                case "put":
                    message += $"{sum}$ credited to the account.\n";
                    break;
                case "take":
                    message += $"{sum}$ withdrawn from the account.\n";
                    break;
                default:
                    return "Unknown transaction type!";
            }
            message += $"Current balance: {_balance}$\n";
            return message;
        }

        /// <summary>
        /// Calculate possible capitalization of balance in the future.
        /// </summary>
        /// <param name="annualInterest">Annual balance capitalization interst, %.</param>
        /// <param name="years">Number of years.</param>
        /// <returns>Balance after the capitalization.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static decimal CalculateCapitalization(decimal sum, double annualInterest, int years)
        {
            if (sum < 0 || annualInterest < 0 || years < 0)
                throw new ArgumentOutOfRangeException();

            var percentCapitalization = Convert.ToDecimal(Math.Pow(1 + (annualInterest / 100), Convert.ToDouble(years)));
            return sum * percentCapitalization;
        }

        /// <summary>
        /// Print account info.
        /// </summary>
        /// <returns>Account info in string format.</returns>
        public override string ToString() => $"Account ID: #{ID}   balance: {_balance} $\n";

        // ***************************** Events ***************************** //

        /// <summary>
        /// Transaction event in user accout.
        /// </summary>
        public event TransactionHandler Transaction;

        /// <summary>
        /// Event on account creation.
        /// </summary>
        public event AccountHandler Created;

        /// <summary>
        /// Event on account deletion.
        /// </summary>
        public event AccountHandler Deleted;

        /// <summary>
        /// Account transactions events handler.
        /// </summary>
        /// <param name="msg">Message to send.</param>
        public delegate void TransactionHandler(string msg, decimal sum);

        /// <summary>
        /// Account state handler.
        /// </summary>
        /// <param name="msg">Message on account state.</param>
        public delegate void AccountHandler(string msg);

        /// <summary>
        /// Calculation handler.
        /// </summary>
        public Func<decimal, double, int, decimal> CalculationFunc;

        /// <summary>
        /// Action on transaction.
        /// </summary>
        public Action<string, decimal> TransactionAction;
    }
}
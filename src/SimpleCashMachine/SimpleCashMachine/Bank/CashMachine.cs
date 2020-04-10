using System;
namespace SimpleCashMachine.Bank
{
    public class CashMachine
    {
        /// <summary>
        /// Bank server.
        /// </summary>
        private BankServer _server = null;

        /// <summary>
        /// Current account/ card ID to perform operatios.
        /// </summary>
        public Account CurrentAccount { get; set; }

        /// <summary>
        /// Cash machine constructor.
        /// </summary>
        /// <param name="server">Bank server.</param>
        public CashMachine(BankServer server)
        {
            if (server == null)
                throw new ArgumentNullException("Unknown bank!");
            _server = server;

            RegistedEvents();
            InsertCardDialog();
        }

        /// <summary>
        /// Dialog with user while inserting credit card.
        /// </summary>
        public void InsertCardDialog()
        {
            Console.WriteLine("\n\n************************************* ");
            Console.WriteLine("************ Cash Machine *********** ");
            Console.WriteLine("*************************************\n ");

            Console.WriteLine("Insert your credit card in cash machine.\n");
            var cardID = ParseCardIdDialog();
            InsertCardDialog(cardID);
        }

        /// <summary>
        /// Dialog with user while inserting credit card.
        /// </summary>
        /// <param name="cardID">Account/credit card Identifier.</param>
        public void InsertCardDialog(int cardID)
        {
            bool success = _server.RequestConnection(this, cardID);
            if (success)
            {
                try
                {
                    CurrentAccount = _server.GetAccount(cardID);
                    if (CurrentAccount == null)
                        throw new ArgumentNullException();
                }
                catch
                {
                    Console.WriteLine("Your credit card is not valid!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Your credit card is invalid!");
                InvalidCard?.Invoke(cardID);
                InsertCardDialog();
            }
                
            ChooseOperationDialog();
        }

        /// <summary>
        /// Remove credit card in cash machine.
        /// </summary>
        public void RemoveCard()
        {
            CurrentAccount = null;
            CardIsRemoved?.Invoke();
        }

        /// <summary>
        /// Dialog with user while choosing the operation.
        /// </summary>
        public void ChooseOperationDialog()
        {
            Console.WriteLine("Choose operation with your card:");
            Console.WriteLine("  v, view   --- check bank account");
            Console.WriteLine("  p, put    --- put some money to the account");
            Console.WriteLine("  t, take   --- take som money from the account");
            Console.WriteLine("  q / quit  --- cancel operation\n");

            Console.Write("input: ");
            var userInput = Console.ReadLine().ToLower().Trim();

            switch (userInput)
            {
                case "v":
                case "view":
                    CheckAccountBalance();
                    break;

                case "p":
                case "put":
                    PutMoneyDialog();
                    break;

                case "t":
                case "take":
                    TakeMoneyDialog();
                    break;

                case "q":
                case "quit":
                    QuitDialog();
                    break;

                default:
                    Console.WriteLine("Incorrect input! Try again!");
                    ChooseOperationDialog();
                    break;
            }
        }

        /// <summary>
        /// Show current Account balance.
        /// </summary>
        public void CheckAccountBalance()
        {
            Console.WriteLine("\n--- Account info ---");
            Console.WriteLine(CurrentAccount);
            QuitDialog();
        }

        /// <summary>
        /// Put money to the account.
        /// </summary>
        public void PutMoneyDialog()
        {
            Console.WriteLine("\n-------- Balance replenishment --------- ");
            Console.WriteLine("Enter sum [$] to put to your account.\n");

            decimal sum = ParseSumDialog();
            CurrentAccount.PutMoney(sum);
            MoneyIsPut?.Invoke();
        }

        /// <summary>
        /// Take money from the accout.
        /// </summary>
        public void TakeMoneyDialog()
        {
            Console.WriteLine("\n-------- Withdraw funds --------- ");
            Console.WriteLine("Enter sum [$] to take from your account.\n");

            decimal sum = ParseSumDialog();
            CurrentAccount.TakeMoney(sum);
            MoneyIsTaken?.Invoke();
        }

        /// <summary>
        /// Process user input to get the sum of money.
        /// </summary>
        /// <returns>Sum of money for operations.</returns>
        public decimal ParseSumDialog()
        {
            decimal sum = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("sum: ");
                try
                {
                    sum = decimal.Parse(Console.ReadLine());
                    success = true;
                }
                catch
                {
                    Console.WriteLine("Incorrect input! Try again.\n");
                }
            }
            return sum;
        }

        /// <summary>
        /// Process user input to get the credit card ID.
        /// </summary>
        /// <returns>Credit card ID.</returns>
        public int ParseCardIdDialog()
        {
            int cardId = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("card ID: ");
                try
                {
                    cardId = int.Parse(Console.ReadLine());
                    success = true;
                }
                catch
                {
                    Console.WriteLine("Incorrect input! Try again.\n");
                }
            }
            return cardId;
        }

        public void QuitDialog()
        {
            Console.WriteLine("Would you like to continue? (y/n)");
            Console.Write("input: ");
            var userInput = Console.ReadLine().ToLower().Trim();

            switch (userInput)
            {
                case "n":
                    RemoveCard();
                    break;

                case "y":
                    ChooseOperationDialog();
                    break;
                default:
                    Console.WriteLine("Unknown command! Try again!\n");
                    QuitDialog();
                    break;
            }
        }

        // ************************* Events ************************* //

        public delegate void ConnectionHandler(int cardId);
        public event ConnectionHandler InvalidCard;

        public Action<int> CardIsInserted; // Action after inseting card.
        public Action CardIsRemoved;       // Action after removing card.
        public Action MoneyIsTaken;        // Action after taking a money from account.
        public Action MoneyIsPut;          // Action after putting a money from account.

        /// <summary>
        /// Register cash machine events.
        /// </summary>
        public void RegistedEvents()
        {
            InvalidCard += (cardID) => Console.WriteLine($"Connection to bank is failed! Your card {cardID} is not valid!\n");
            InvalidCard += (cardID) => RemoveCard();

            CardIsInserted += (cardID) =>
            {
                Console.WriteLine($"Hello! Your card {cardID} is reading!\n");
                InsertCardDialog(cardID);
            };

            CardIsRemoved += () => Console.WriteLine($"Your credit card was removed!\nDo not forget your card in cash machine!\n");

            MoneyIsTaken += () => QuitDialog();
            MoneyIsPut += () => QuitDialog();
        }
    }
}
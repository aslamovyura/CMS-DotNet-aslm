namespace SimpleCashMachine.Interfaces
{
    public interface IPay
    {
        /// <summary>
        /// Put money to the account.
        /// </summary>
        /// <param name="sum">Money, $.</param>
        public void PutMoney(decimal sum);

        /// <summary>
        /// Take money from the account.
        /// </summary>
        /// <param name="sum">Money, $.</param>
        public void TakeMoney(decimal sum);

        /// <summary>
        /// Check if account is empty.
        /// </summary>
        /// <returns>True,if balance is equal to zero.</returns>
        public bool IsEmpty();

        /// <summary>
        /// Get the sum of money on the account.
        /// </summary>
        /// <returns>Money, $</returns>
        decimal GetAccountBalance();
    }
}
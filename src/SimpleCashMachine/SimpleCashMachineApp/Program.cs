using SimpleCashMachine;
using SimpleCashMachine.Bank;

namespace SimpleCachMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load bank with client base.
            BankServer bank = new BankServer();
            bank.LoadDefaultClientBase();
            bank.Show();

            // Create cash machine to deal with credic cards.
            CashMachine cashMachine = new CashMachine(bank);
            while (true)
                cashMachine.InsertCardDialog();
        }
    }
}
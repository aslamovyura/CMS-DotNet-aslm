using System;
using StoreCashBoxes;

namespace StoreCashBoxesApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Store store = new Store(cashBoxesNumber: 10,
                                    fastCashBoxesNumber: 1,
                                    customerGenerationTimeInterval: 300);

            Greeting();
            Console.WriteLine("\nUser input: ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'o':
                    case 'O':
                        Console.WriteLine();
                        store.Open();
                        break;

                    case 'c':
                    case 'C':
                        Console.WriteLine();
                        store.Close();
                        Console.WriteLine("\nUser input: ");
                        break;

                    case 'h':
                    case 'H':
                        Console.WriteLine();
                        store.Close();
                        Greeting();
                        Console.WriteLine("\nUser input: ");
                        break;

                    case 'q':
                    case 'Q':
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Write("\nUser input:\n");
                        break;
                }

            }

            // Print greeting & help info.
            static void Greeting()
            {
                Console.WriteLine("\n**************************************");
                Console.WriteLine("**************** Store ****************");
                Console.WriteLine("***************************************\n");
                Console.WriteLine("The following commands are available:");
                Console.WriteLine("\t`o` --- open store");
                Console.WriteLine("\t`c` --- close store");
                Console.WriteLine("\t`h` --- help");
                Console.WriteLine("\t`q` --- quit");
            }
        }
    }
}
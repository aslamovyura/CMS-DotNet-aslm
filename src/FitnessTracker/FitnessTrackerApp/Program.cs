using System;
using FitnessTracker.Tracker;

namespace FitnessTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create health tracker.
            HealthTracker tracker = new HealthTracker();

            Greeting();
            Console.WriteLine("\nUser input: ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'h':
                    case 'H':
                        tracker.Stop();
                        Greeting();
                        break;

                    case 'r':
                    case 'R':
                        tracker.Reset();
                        break;

                    case 'q':
                    case 'Q':
                        tracker.Quit();
                        break;

                    default:
                        tracker.RunOrStop();
                        Console.Write("\nUser input: ");
                        break;
                }
            }
        }

        // Print greeting / help message to console.
        static void Greeting()
        {
            Console.WriteLine("\n*******************************************************");
            Console.WriteLine("******************* Fintess Tracker *******************");
            Console.WriteLine("*******************************************************\n");
            Console.WriteLine("The following commands are available:");
            Console.WriteLine("\t`r` --- reset");
            Console.WriteLine("\t`h` --- help");
            Console.WriteLine("\t`q` --- quit");
            Console.WriteLine("\t other --- start/stop\n");
        }
    }
}
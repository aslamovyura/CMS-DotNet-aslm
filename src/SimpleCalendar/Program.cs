using System;

namespace SimpleCalendar
{
    class Program
    {
        static void Main(string[] args)
        {

            // Print main screen info
            PrintGreeting();
            PrintHelpMessage();
            
            while (true)
            {
                Console.Write("User input: ");
                string UserInput = Console.ReadLine().Trim();
                Calendar myCalendar = Calendar.GetInstance();

                switch (UserInput)
                {
                    // Quite calculator
                    case "q":
                    case "quit":
                        Console.WriteLine("Goodbye! See you soon!");
                        return;

                    // Show help message
                    case "h":
                    case "help":
                        PrintHelpMessage();
                        PrintAddEventHelpMessage();
                        break;

                    case "a":
                    case "add":
                        myCalendar.AddEventAction();
                        break;

                    case "rm":
                    case "remove":
                        myCalendar.RemoveEventAction();
                        break;

                    case "rm -a":
                    case "remove -a":
                        myCalendar.RemoveAllEvents();
                        break;

                    case "p":
                    case "p -a":
                    case "print":
                    case "print -a":
                        myCalendar.PrintAll();
                        break;

                    case "p -d":
                    case "print -d":
                        myCalendar.PrintEventsForDate();
                        break;

                    default:
                        Console.WriteLine("Unknown command. Try again...");
                        break;
                }
            }
        }

        static void PrintGreeting()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("*************** SIMPLE CALENDAR **************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Hello, Amigo!");
            Console.WriteLine("This is your simple calendar app!");
        }

        static void PrintAddEventHelpMessage()
        {

            Console.WriteLine("\nType `add` to add new event to your calendar");
            Console.WriteLine("The following event parameters are required: ");
            Console.WriteLine("- start date/time, e.g. 10-12-2020 10:14:43");
            Console.WriteLine("                        10-12-2020 10:14");
            Console.WriteLine("                        10-12-2020 10");
            Console.WriteLine("                        10-12-2020");
            Console.WriteLine("- length [hours], e.g. 1.25");
            Console.WriteLine("- brief description, e.g. `Call to Harry`");
            Console.WriteLine("- priority description: 'High'   / '3'");
            Console.WriteLine("                        'Medium' / '2'");
            Console.WriteLine("                        'Low'    / '1'");
            Console.WriteLine("Type `q` for exit, and `h` for help\n");

        }

        static void PrintHelpMessage()
        {
            Console.WriteLine("\nThe following commands are available:");
            Console.WriteLine("+ `a`,`add`    -- add new event to the calendar");
            Console.WriteLine("+ `p`,`print`  -- print the whole list of events");
            Console.WriteLine("  `p/print -d` -- print the list of events for the certain date");
            Console.WriteLine("+ 'q',`quit`   -- quit program");
            Console.WriteLine("+ 'h',`help`   -- help");
            Console.WriteLine("Good luck, Amigo!\n");

        }
    }
}

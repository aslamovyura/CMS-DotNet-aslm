using System;
using Core.Constants;
using Core.Extensions;
using Core.Interfaces;
using Core.Services;

namespace App
{
    class Program
    {
        static void Main()
        {
            GreetingMessage();
            MainScreen();
        }

        static void MainScreen()
        {
            HelpMessageGeneral();
            ShowCursor();
            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "h":
                    case "help":
                        Console.WriteLine();
                        HelpMessageGeneral();
                        ShowCursor();
                        break;

                    case "s":
                    case "send":
                        SendMessage();
                        break;

                    case "q":
                    case "quit":
                        Console.WriteLine("\nThank's for using this app! See you soon!");
                        Environment.Exit(0);
                        break;

                    default:
                        {
                            Console.Write($"\n{ErrorConstants.UnknownCommand}\n");
                            ShowCursor();
                        }
                        break;
                }
            }
        }

        // Print greeting message
        static void GreetingMessage()
        {
            Console.WriteLine("\n**********************************************");
            Console.WriteLine("***************** Email App ******************");
            Console.WriteLine("**********************************************");
        }

        static void ShowCursor() => Console.Write("\nUser input: ");

        static void HelpMessageGeneral()
        {
            Console.WriteLine("\n`Email App` provides you with ability to send email to certain recipient.");
            Console.WriteLine("The following commands are available:");
            Console.WriteLine("  s | send      Send email.");
            Console.WriteLine("  h | help      Display help massage.");
            Console.WriteLine("  q | quit      Quit program.");
        }

        static void HelpMessageInitEmailService()
        {
            Console.WriteLine("\nChoose which setting of the email service is user:");
            Console.WriteLine("  d | default    Load default options from the emailsetting.json (Put it to the app directory).");
            Console.WriteLine("  n | new        Set new custom setting.");
            Console.WriteLine("or press `c|cancel` to go to previous screen.");
        }

        static void SendMessage()
        {
            IEmailService emailService = InitEmailService(); 
            (var email, var subject, var message) = CreateMessage();

            emailService.SendEmailAsync(email, subject, message).GetAwaiter().GetResult();

            MainScreen();
        }

        static IEmailService InitEmailService()
        {
            IEmailService emailService = default;

            HelpMessageInitEmailService();
            ShowCursor();

            var success = false;
            while (!success)
            {
                var input = Console.ReadLine().Trim().ToLower();
                switch (input)
                {
                    case "d":
                    case "default":
                        emailService = InitEmailServiceDefault();
                        success = true;
                        break;

                    case "n":
                    case "new":
                        emailService = InitEmailServiceCustom();
                        success = true;
                        break;

                    case "c":
                    case "cancel":
                        MainScreen();
                        break;

                    default:
                        {
                            Console.Write($"\n{ErrorConstants.UnknownCommand}\n");
                            ShowCursor();
                        }
                        break;
                }
            }

            return emailService;
        }

        static IEmailService InitEmailServiceDefault()
        {

            IEmailService emailService = default;

            try
            {
                emailService = new EmailService();
                Console.WriteLine(ErrorConstants.EmailSettingsLoaded);  
            }
            catch
            {
                Console.WriteLine(ErrorConstants.EmailSettingsNotFound);
                MainScreen();
            }

            return emailService;
        }

        static IEmailService InitEmailServiceCustom()
        {
            IEmailService emailService = default;
            var success = false;

            while (!success)
            {
                Console.WriteLine("Please, input parameters for email service (SMTP server, port, email and password):");
                var server = InputServer();
                var port = InputPort();
                var email = InputEmail();
                var password = InputPassword();

                try
                {
                    emailService = new EmailService(server, port, email, password);
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again please...");
                }
            }

            return emailService;
        }

        static (string email, string subject, string message) CreateMessage()
        {
            Console.WriteLine("\nPlease, input message parameters (recipient email, message subject and text):");

            string email = InputEmail();
            string subject = InputMessage(parameter: "subject");
            string message = InputMessage(parameter: "text");

            return (email, subject, message);
        }

        static bool CheckUserInput(string userInput, string dataType )
        {
            bool isValid = false;

            switch(dataType)
            {
                case CommonCostants.email:
                    isValid = userInput.IsValidEmail();
                    break;

                case CommonCostants.password:
                    isValid = true;
                    break;

                case CommonCostants.port:
                    isValid = userInput.IsValidPort();
                    break;

                case CommonCostants.server:
                    isValid = userInput.IsValidServer();
                    break;
            }
            return isValid;
        }

        static string InputServer()
        {
            string server = default;
            var success = false;

            while (!success)
            {
                Console.Write($"  {CommonCostants.server}: ");

                server = Console.ReadLine().Trim();
                if (CheckUserInput(server, CommonCostants.server))
                    success = true;
                else
                    Console.WriteLine(ErrorConstants.ServerFormatIssues);
            }

            return server;
        }

        static int InputPort()
        {
            string port = default;
            var success = false;

            while (!success)
            {
                Console.Write($"  {CommonCostants.port}: ");

                port = Console.ReadLine().Trim();
                if (CheckUserInput(port, CommonCostants.port))
                    success = true;
                else
                    Console.WriteLine(ErrorConstants.ServerPortIssues);
            }

            return Convert.ToInt32(port);
        }

        static string InputEmail()
        {
            string email = default;
            var success = false;

            while (!success)
            {
                Console.Write($"  {CommonCostants.email}: ");

                email = Console.ReadLine().Trim();
                if (CheckUserInput(email, CommonCostants.email))
                    success = true;
                else
                    Console.WriteLine(ErrorConstants.EmailFormatIssues);
            }

            return email;
        }

        static string InputPassword()
        {
            string password = default;
            var success = false;

            while (!success)
            {
                Console.Write($"  {CommonCostants.password}: ");

                password = Console.ReadLine().Trim();
                if (CheckUserInput(password, CommonCostants.server))
                    success = true;
                else
                    Console.WriteLine(ErrorConstants.ServerFormatIssues);
            }

            return password;
        }

        static string InputMessage(string parameter)
        {
            string text = default;
            var success = false;

            while (!success)
            {
                Console.Write($"  message {parameter}: ");

                text = Console.ReadLine().Trim();
                success = true;
            }

            return text;
        }
    }
}
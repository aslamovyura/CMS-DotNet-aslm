using System;
using SimpleCashMachine.Interfaces;

namespace SimpleCashMachine.Bank.Notifications
{
    public class EmailNotification : Notification, INotify
    {
        /// <summary>
        /// User e-mail.
        /// </summary>
        private string _email;

        /// <summary>
        /// User e-mail to send notificatinos.
        /// </summary>
        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Notification title.
        /// </summary>
        public override string Title { get; set; } =
            "\n**************** EMAIL NOTIFICATION ****************\n" +
            "Dear Customer!\n";

        /// <summary>
        /// Default notification constructor.
        /// </summary>
        public EmailNotification() { }

        /// <summary>
        /// Default notification constructor.
        /// </summary>
        public EmailNotification(string email) => Email = email;

        /// <summary>
        /// Constructor of SMS-notification.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="footer">Notification footer.</param>
        public EmailNotification(string title, string footer, string email)
            : base(title, footer) => Email = email;

        /// <summary>
        /// Send notificatino with particular message.
        /// </summary>
        /// <param name="Message">Notification main text.</param>
        public override void Send(string Message)
        {
            if (Email == null)
                throw new ArgumentNullException("There is no defined email to send notifications!");

            Console.WriteLine(Title);
            Console.WriteLine(Message);
            Console.WriteLine(Footer);

            OnSend();
        }

        /// <summary>
        /// Send notificatino with particular message.
        /// </summary>
        /// <param name="Message">Notification main text.</param>
        public override void Send()
        {
            if (Email == null)
                throw new ArgumentNullException("There is no defined email to send notifications!");

            Console.WriteLine(Title);
            Console.WriteLine(Message);
            Console.WriteLine(Footer);

            OnSend();
        }

        /// <summary>
        /// Action on notification send.
        /// </summary>
        public void OnSend()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"-- Notification to the email {Email} is been sent.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
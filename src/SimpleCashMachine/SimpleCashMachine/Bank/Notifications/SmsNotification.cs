using System;
using SimpleCashMachine.Interfaces;

namespace SimpleCashMachine.Bank.Notifications
{
    /// <summary>
    /// Class for sending sms-notifications.
    /// </summary>
    public class SmsNotification : Notification, INotify
    {
        /// <summary>
        /// User phone number.
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// User phone number to send sms-notificatinos.
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Notification title.
        /// </summary>
        public override string Title { get; set; } =
            "\n**************** SMS NOTIFICATION ****************\n" +
            "Dear Customer!\n";

        /// <summary>
        /// Default notification constructor.
        /// </summary>
        public SmsNotification() { }

        /// <summary>
        /// Notification constructor.
        /// </summary>
        public SmsNotification(string phoneNumber) => PhoneNumber = phoneNumber;

        /// <summary>
        /// Notification constructor.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="footer">Notification footer.</param>
        public SmsNotification(string title, string footer, string phoneNumber)
            : base(title, footer) => PhoneNumber = phoneNumber;

        /// <summary>
        /// Send notificatino with particular message.
        /// </summary>
        /// <param name="Message">Notification main text.</param>
        public override void Send(string Message)
        {
            if (PhoneNumber == null)
                throw new ArgumentNullException("There is no specific phone number to send notifications!");

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
            if (PhoneNumber == null)
                throw new ArgumentNullException("There is no specific phone number to send notifications!");

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
            Console.WriteLine($"-- Sms-notification to the phone number {PhoneNumber} is been sent.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
using System;
namespace SimpleCashMachine.Bank.Notifications
{
    /// <summary>
    /// Class for sending notifications.
    /// </summary>
    abstract public class Notification
    {
        /// <summary>
        /// Notification title.
        /// </summary>
        public virtual string Title { get; set; } =
            "\n**************** NOTIFICATION ****************\n" +
            "Dear Customer!\n";

        /// <summary>
        /// Default notification message.
        /// </summary>
        public virtual string Message { get; set; } = "No content.\n";

        /// <summary>
        /// Notification footer.
        /// </summary>
        public virtual string Footer { get; set; } = "Best wishes,\nyour bank!\n"+
            "\n***********************************************\n";

        /// <summary>
        /// Default notification constructor.
        /// </summary>
        public Notification() { }

        /// <summary>
        /// Notification constructor with message title and footer.
        /// </summary>
        /// <param name="title">Message title.</param>
        /// <param name="footer">Message footer.</param>
        public Notification(string title, string footer)
        {
            Title = title;
            Footer = footer;
        }

        /// <summary>
        /// Send notification with particular message.
        /// </summary>
        /// <param name="msg">Message to send.</param>
        public virtual void Send(string msg) { }

        /// <summary>
        /// Send notification with default message.
        /// </summary>
        public virtual void Send() { }
    }
}
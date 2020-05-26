namespace Core.Constants
{
    /// <summary>
    /// Define class containing constants for error messages.
    /// </summary>
    public class ErrorConstants
    {
        /// <summary>
        /// Email address form is not correct.
        /// </summary>
        public const string EmailFormatIssues = "Email address format is not valid!";

        /// <summary>
        /// SMTP server address is not correct.
        /// </summary>
        public const string ServerFormatIssues = "SMTP server address is not valid!";

        /// <summary>
        /// SMTP port is out of range.
        /// </summary>
        public const string ServerPortIssues = "Server port value is out of range!";

        /// <summary>
        /// Email settings are not found.
        /// </summary>
        public const string EmailSettingsNotFound = "Settings for email service are not found!";

        /// <summary>
        /// Email settings are invalid.
        /// </summary>
        public const string EmailSettingsInvalid = "Settings for email service are not valid!";

        /// <summary>
        /// Email settings are not found.
        /// </summary>
        public const string EmailSettingsLoaded = "Settings for email service are successfully loaded!";

        /// <summary>
        /// Message was successfully sent.
        /// </summary>
        public const string MessageSentIssues = "Error! Message was not sent!";

        /// <summary>
        /// Message was successfully sent.
        /// </summary>
        public const string MessageSentSuccess = "Message was successfully sent!";

        /// <summary>
        /// Unknown command.
        /// </summary>
        public const string UnknownCommand = "Unknown command! Try again, please.";
    }
}
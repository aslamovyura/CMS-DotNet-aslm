namespace Core.Constants
{
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
        /// Email settings are not found or not valid.
        /// </summary>
        public const string EmailSettingsIssues = "Settings for email service are not found or not valid!";

    }
}
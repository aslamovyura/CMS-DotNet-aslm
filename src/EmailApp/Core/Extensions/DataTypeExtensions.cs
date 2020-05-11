using System.Text.RegularExpressions;

namespace Core.Extensions
{
    public static class DataTypeExtensions
    {
        /// <summary>
        /// Check if SMTP server has a valid format.
        /// </summary>
        /// <param name="smtpServer">SMTP server.</param>
        /// <returns>True, if server format is valid, false if not.</returns>
        public static bool IsValidServer(this string smtpServer)
        {
            string pattern = @"^smtp.\w*";

            return Regex.IsMatch(smtpServer, pattern);
        }

        /// <summary>
        /// Check if email address has a valid format.
        /// </summary>
        /// <param name="email">email address.</param>
        /// <returns>True, if email format is valid, false if not.</returns>
        public static bool IsValidEmail(this string email)
        {
            string pattern = @"\A[a-z0-9!#$%&'*+/=?^_‘{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_‘{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\z";

            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Check if SMTP port is valid.
        /// </summary>
        /// <param name="port">SMTP port.</param>
        /// <returns>True, if SMTP port is valid, false if not.</returns>
        public static bool IsValidPort(this string port)
        {
            string pattern = @"(^25$)|(^465$)|(^587$)";

            return Regex.IsMatch(port, pattern);
        }
    }
}
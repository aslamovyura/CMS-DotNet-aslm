using System.ComponentModel.DataAnnotations;
using Core.Constants;

namespace Core.Models
{
    public class EmailSettings
    {
        /// <summary>
        /// SMTP Server.
        /// </summary>
        [Required]
        //[RegularExpression(@"^smtp\w*")]  % TODO: Validation is not working! Why?
        public string Server { get; set; }

        /// <summary>
        /// SMTP Server port.
        /// </summary>
        [Required]
        [Range(1,1000, ErrorMessage = ErrorConstants.ServerPortIssues)]
        public int Port { get; set; }

        /// <summary>
        /// Sender email adress.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = ErrorConstants.EmailFormatIssues)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password of the sender email.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
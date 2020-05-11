using System.Collections.Generic;
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
        //[RegularExpression(@"^smtp\w*")]
        public string Server { get; set; }

        /// <summary>
        /// SMTP Server port.
        /// </summary>
        [Required]
        [Range(1,500, ErrorMessage = ErrorConstants.ServerPortIssues)]
        public int Port { get; set; }

        /// <summary>
        /// Sender email adress.
        /// </summary>
        [Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = ErrorConstants.EmailFormatIssues)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Password of the sender email.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
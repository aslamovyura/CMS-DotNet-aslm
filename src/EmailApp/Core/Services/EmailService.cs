using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using Core.Interfaces;
using Core.Models;
using Core.Constants;
using Core.Extensions;

namespace Core.Services
{
    /// <summary>
    /// Define service to send messages to email.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <exception cref="Exception">Exception, when email settings is not found.</exception>
        /// <exception cref="ArgumentException">Exception, when email settings is not valid.</exception>
        public EmailService()
        {
            try
            {
                _emailSettings = EmailConfiguration();
            }
            catch
            {
                throw new Exception(ErrorConstants.EmailSettingsNotFound);
            }

            if (!_emailSettings.IsValid())
            {
                throw new ArgumentException(ErrorConstants.EmailSettingsInvalid);
            }
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="emailSettings">Setting for email service (Server, Port, EmailAddress, Password)</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Exception when emailSettings is not valid.</exception>
        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings ?? throw new ArgumentNullException(nameof(emailSettings));

            if (!_emailSettings.IsValid())
            {
                throw new ArgumentException(ErrorConstants.EmailSettingsInvalid);
            }
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="server">SMTP server.</param>
        /// <param name="port">SMTP server port.</param>
        /// <param name="email">Email adress to send from.</param>
        /// <param name="password">Password of the email address.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException">Exception, when one of the inner arguments is not valid.</exception>
        public EmailService(string server, int port, string email, string password)
        {
            server = server ?? throw new ArgumentNullException(nameof(server));
            port = port > 0 ? port : throw new ArgumentOutOfRangeException();
            email = email ?? throw new ArgumentNullException(nameof(email));
            password = password ?? throw new ArgumentNullException(nameof(password));

            _emailSettings = new EmailSettings()
            {
                Server = server,
                Port = port,
                EmailAddress = email,
                Password = password
            };

            if (!_emailSettings.IsValid())
            {
                throw new ArgumentException(ErrorConstants.EmailSettingsInvalid);
            }
        }

        ///<inheritdoc/>
        ///<exception cref="ArgumentNullException"></exception>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("MailApp", _emailSettings.EmailAddress));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port, true);
                    await client.AuthenticateAsync(_emailSettings.EmailAddress, _emailSettings.Password);
                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                    Console.WriteLine(ErrorConstants.MessageSentSuccess);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ErrorConstants.MessageSentIssues);
            }
        }

        private EmailSettings EmailConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("emailsettings.json")
                .Build();

            var emailSettings = configuration.GetSection("EmailSettings")
                .Get<EmailSettings>();

            return emailSettings;
        }
    }
}
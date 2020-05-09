using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    /// <summary>
    /// Define service to send messages to email.
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService()
        {
            _emailSettings = EmailConfiguration();
        }

        ///<inheritdoc/>
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
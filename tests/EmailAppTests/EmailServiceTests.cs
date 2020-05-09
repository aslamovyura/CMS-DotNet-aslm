using System;
using Core.Interfaces;
using Core.Services;
using Xunit;

namespace EmailAppTests
{
    public class EmailServiceTests
    {
        IEmailService _emailService;

        public EmailServiceTests()
        {
            _emailService = new EmailService();
        }

        [Fact]
        public void SendEmailAsync_WhenEmailAddressIsNull_Return_ArgumentNullException()
        {
            // Arrange
            string email = default;
            string subject = nameof(subject);
            string message = nameof(message);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => _emailService.SendEmailAsync(email, subject, message).GetAwaiter().GetResult());
        }
    }
}
using System;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Moq;
using Xunit;

namespace EmailAppTests
{
    public class EmailServiceTests
    {
        IEmailService _emailService;

        public EmailServiceTests() { }

        [Fact]
        public void SendEmailAsync_WhenEmailAddressIsNull_Return_ArgumentNullException()
        {
            // Arrange
            string email = default;
            string subject = nameof(subject);
            string message = nameof(message);

            _emailService = new EmailService();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => _emailService.SendEmailAsync(email, subject, message).GetAwaiter().GetResult());
        }

        [Fact]
        public void SendEmailAsync_WhenEmailAddressIsValid_Return_Success()
        {
            // Arrange
            string email = "some@gmail.com";
            string subject = nameof(subject);
            string message = nameof(message);

            _emailService = new EmailService();
            var success = true;

            // Act
            try
            {
                _emailService.SendEmailAsync(email, subject, message).GetAwaiter().GetResult();
            }
            catch
            {
                success = false;
            }

            // Assert
            Assert.True(success);
        }

        [Fact]
        public void EmailService_WhenInitWithNullSpmtpServer_Return_Exception()
        {
            // Arrange
            string smtpServer = default;
            int port = 465;
            string email = "some@mail.com";
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithNullEmail_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = 465;
            string email = default;
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithNullPassword_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = 465;
            string email = "some@mail.com";
            string password = default;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithNegativePort_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = -465;
            string email = "some@mail.com";
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithZeroPort_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = 0;
            string email = "some@mail.com";
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithGreater500_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = 2000;
            string email = "some@mail.com";
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithInvalidEmailFormat_Return_Exception()
        {
            // Arrange
            string smtpServer = "smtp.gmail.com";
            int port = 465;
            string email = "someAddress";
            string password = "somePassword";

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new EmailService(smtpServer, port, email, password));
        }

        [Fact]
        public void EmailService_WhenInitWithNullEmailSettings_Return_Exception()
        {
            // Arrange
            EmailSettings setting = default;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmailService(setting));
        }

        [Fact]
        public void EmailService_WhenInitWithInvalidEmailSettings_Return_Exception()
        {
            // Arrange
            EmailSettings setting = new EmailSettings { EmailAddress = "123" };

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new EmailService(setting));
        }
    }
}
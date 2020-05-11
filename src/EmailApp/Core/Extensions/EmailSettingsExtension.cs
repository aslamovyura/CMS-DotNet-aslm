using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.Extensions
{
    /// <summary>
    /// Define extensions to EmailSettings class.
    /// </summary>
    public static class EmailSettingsExtension
    {
        /// <summary>
        /// Validate model of email service settings.
        /// </summary>
        /// <param name="emailSettings">Email settings.</param>
        /// <returns>True if email settings is valid, and false if not.</returns>
        public static bool IsValid(this EmailSettings emailSettings)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(emailSettings);
            var result = Validator.TryValidateObject(emailSettings, context, results, true);

            foreach(var error in results)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return result;
        }
    }
}
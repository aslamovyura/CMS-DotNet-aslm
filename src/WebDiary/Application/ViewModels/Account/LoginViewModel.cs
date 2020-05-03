using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Account
{
    public class LoginViewModel
    {
        /// <summary>
        /// User email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Remember 
        /// </summary>
        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Return URL after login.
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
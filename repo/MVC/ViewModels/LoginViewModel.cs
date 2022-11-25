using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        /* public string Error { get; set; } = String.Empty;

         public string ReturnUrl { get; set; } = String.Empty;

         public IList<AuthenticationScheme>? ExternalLogins { get; set; }*/
    }
}

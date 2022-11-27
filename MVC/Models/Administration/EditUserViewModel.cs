using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Administration
{
    public class EditUserViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
    }
}

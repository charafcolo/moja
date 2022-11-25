using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

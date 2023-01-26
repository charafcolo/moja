using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Administration
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}

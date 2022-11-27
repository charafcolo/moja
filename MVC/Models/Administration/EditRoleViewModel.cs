using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Administration
{
    public class EditRoleViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        public string RoleName { get; set; } = string.Empty;

        public List<string> Users { get; set; } = new();
    }
}

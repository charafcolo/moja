using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class EditCandidatureViewModel
    {
        public enum StatusItem
        {
            Préparation,
            EnCours,
            Envoyé,
            Entretien
        }
        [Required]
        public string PostName { get; set; } = String.Empty;
        [Required]
        public string Status { get; set; }
        public List<SelectListItem> StatusList = new List<SelectListItem>();

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime ModificationDate { get; set; }
        public string Comment { get; set; } = String.Empty;

        public EditCandidatureViewModel(string postName, string status, string comment, DateTime modificationTime)
        {
            PostName = postName;
            Status = status;
            Comment = comment;
            ModificationDate= modificationTime;
            StatusList.Add(new SelectListItem
            {
                Value = "Préparation",
                Text = StatusItem.Préparation.ToString()
            });
            StatusList.Add(new SelectListItem
            {
                Value = "En cours",
                Text = "En cours"
            });
            StatusList.Add(new SelectListItem
            {
                Value = "Envoyé",
                Text = StatusItem.Envoyé.ToString()
            });
            StatusList.Add(new SelectListItem
            {
                Value = "Entretien",
                Text = StatusItem.Entretien.ToString()
            });

        }
        public EditCandidatureViewModel()
        {
            StatusList.Add(new SelectListItem
            {
                Value = "Préparation",
                Text = StatusItem.Préparation.ToString()
            });
            StatusList.Add(new SelectListItem
            {
                Value = "En cours",
                Text = "En cours"
            });
            StatusList.Add(new SelectListItem
            {
                Value = "Envoyé",
                Text = StatusItem.Envoyé.ToString()
            });
            StatusList.Add(new SelectListItem
            {
                Value = "Entretien",
                Text = StatusItem.Entretien.ToString()
            });
        }
    }
}

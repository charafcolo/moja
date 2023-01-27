using DAO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class AddCandidatureViewModel
    {
        //CandidaturesProperties
        public enum StatusItem
        {
            Préparation,
            EnCours,
            Envoyé,
            Entretien
        }
        [Required]
        public string PostName { get; set; }
        [Required]
        public string Status { get; set; }
        public List<SelectListItem> StatusList;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime ModificationDate { get; set; }
        public string Comment { get; set; }
        //EntrepriseProperties
        public string EntrepriseName { get; set; }
        public string EntrepriseCity { get; set; }

        public AddCandidatureViewModel()
        {
            StatusList= new List<SelectListItem>();
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
            this.ModificationDate= DateTime.Now;

        }
    }

}


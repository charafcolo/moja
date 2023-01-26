using DAO.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class AddCandidatureViewModel
    {
         public enum listOfStatus
        {
            Préparation,
            En_cours,
            Envoyé,
            Entretien

        }
        //CandidaturesProperties
        [Required]
        public string PostName { get; set; }
        [Required]
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime ModificationDate { get; set; }
        public string Comment { get; set; }
        //EntrepriseProperties
        public string EntrepriseName { get; set; }

        
    }
}

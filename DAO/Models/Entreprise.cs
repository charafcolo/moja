using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Entreprise
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string EntrepriseName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public string RespLastName { get; set; } = String.Empty;
        public string RespFirstName { get; set; } = String.Empty;
        public string PosteRep { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string StreetAdress { get; set; } = String.Empty;
        public string NumAdress { get; set; } = String.Empty;
        public string Sector { get; set; } = String.Empty;

        public Entreprise()
        {

        }

        public Entreprise(string nom)
        {
            EntrepriseName = nom;

        }

    }
}
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
        [MaxLength(100)]
        public string EntrepriseName { get; set; } = String.Empty;
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(10)]
        public string? Numero { get; set; }
        [MaxLength(50)]
        public string? RespLastName { get; set; }
        [MaxLength(50)]
        public string? RespFirstName { get; set; }
        [MaxLength(50)]
        public string? PosteRep { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? StreetAdress { get; set; }
        [MaxLength(5)]
        public string? NumAdress { get; set; }
        [MaxLength(50)]
        public string? Sector { get; set; }

        public Entreprise()
        {

        }

        public Entreprise(int id, string nom)
        {
            EntrepriseName = nom;
            Id = id;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAO.Models
{
    public class Candidature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string PostName { get; set; } = String.Empty;
        [Required]
        public DateTime ModificationDate { get; set; }
        [Required]
        [MaxLength(11)]
        public string Status { get; set; } = String.Empty;
        [MaxLength(255)]
        public string Comment { get; set; } = String.Empty;
        [Required]
        public Entreprise Entreprise { get; set; }
        public Candidature()
        {

        }

        public Candidature(int id, string postName, DateTime modificationDate, string status, string comment, Entreprise entreprise)
        {
            Id = id;
            PostName = postName;
            ModificationDate = modificationDate;
            Status = status;
            Comment = comment;
            Entreprise = entreprise;
        }
    }
}

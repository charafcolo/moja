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
        public string PostName { get; set; } = String.Empty;
        [Required]
        public DateTime ModificationDate { get; set; }
        [Required]
        public string Status { get; set; } = String.Empty;
        public string Comment { get; set; } = String.Empty;



    }
}

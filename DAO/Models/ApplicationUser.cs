using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = String.Empty;
        [Required]
        public string LastName { get; set; } = String.Empty;

        public List<Candidature>? Candidatures { get; set; }

        public ApplicationUser()
        {

        }

        public ApplicationUser(string firstName, string lastName, List<Candidature>? candidatures)
        {
            FirstName = firstName;
            LastName = lastName;
            Candidatures = new();
            Candidatures = candidatures;
        }
    }
}

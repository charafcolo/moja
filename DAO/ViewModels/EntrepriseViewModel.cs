using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.ViewModels
{
    public class EntrepriseViewModel
    {
        public int Id { get; set; }

        public string Nom { get; set; } = String.Empty;
        public EntrepriseViewModel(int id, string nom)
        {
            Id = id;
            Nom = nom;

        }
        public EntrepriseViewModel()
        {

        }
    }
}

namespace MVC.Models.Entreprise
{
    public class EntreprisePartialViewModel
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;
        public EntreprisePartialViewModel(int id, string nom)
        {
            Id = id;
            Nom = nom;

        }
    }
}

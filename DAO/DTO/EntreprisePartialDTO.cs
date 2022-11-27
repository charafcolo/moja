// Dossier ViewModels renommé DTO

namespace DAO.DTO // D.T.O. DATA TRANSFERT OBJECT
{
    public class EntreprisePartialDTO // Renomage de EntrepriseViewModel en EntreprisePartialDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; } = String.Empty;
        public EntreprisePartialDTO(int id, string nom)
        {
            Id = id;
            Nom = nom;

        }
        public EntreprisePartialDTO()
        {

        }
    }
}

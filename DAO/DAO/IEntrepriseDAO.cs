using DAO.Models;
using DAO.DTO;

namespace DAO.DAO
{
    public interface IEntrepriseDAO
    {
        Task<List<EntreprisePartialDTO>> GetAll();

        Task<Entreprise?> GetById(int id);

        Task Create(Entreprise entreprise);

        Task Update(Entreprise p);

        Task Delete(int id);
    }
}

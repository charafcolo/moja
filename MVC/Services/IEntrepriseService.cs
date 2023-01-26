using DAO.DTO;
using DAO.Models;
using MVC.Models.Entreprise;

namespace MVC.Services
{
    public interface IEntrepriseService
    {
        Task<List<EntreprisePartialViewModel>> GetAll();

        Task<Entreprise?> GetById(int id);

        Task Create(Entreprise entreprise);

        Task Update(Entreprise p);

        Task Delete(int id);
    }
}

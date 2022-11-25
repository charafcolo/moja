using DAO.Models;
using DAO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IEntrepriseDAO
    {
        Task<List<EntrepriseViewModel>> GetAll();

        Task<Entreprise?> GetById(int id);

        Task Create(Entreprise entreprise);

        Task Update(Entreprise p);

        Task Delete(int id);
    }
}

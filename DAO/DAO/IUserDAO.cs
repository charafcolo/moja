using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public interface IUserDAO
    {
        public Task AddCandidature(string id , Candidature c);
        public Task DeleteCandidature(int id, string userId);
        public Task<IQueryable<Candidature>> GetCandidatureByUser(string id);
        public Task<string> GetPost(string id);

    }
}

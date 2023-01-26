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
        public Task DeleteCandidature(int id);
        public Task<List<Candidature>> GetCandidatureByUser(string id);
        public string GetPost(string id);

    }
}

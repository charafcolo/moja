using DAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly ApplicationDbContext _db;
        public UserDAO(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddCandidature(string id, Candidature c)
        {
            ApplicationUser user = _db.Users.Find(id);
            c.linkedUser = user;
            _db.Candidatures.Add(c);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteCandidature(int id)
        {
            Candidature c = await _db.Candidatures.FindAsync(id);
            _db.Candidatures.Remove(c);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Candidature>> GetCandidatureByUser(string id)
        {
            List<Candidature> c = await _db.Candidatures.ToListAsync();
            c.Select(c => c.linkedUser.Id).Where(i => i == id);
            Debug.WriteLine(c.Count);
            return c;
        }
    }
}

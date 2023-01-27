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
        public async Task DeleteCandidature(int id, string userId)
        {
            {
                IQueryable<Candidature> c = _db.Candidatures.Where(c => c.linkedUser.Id == userId);
                c.Select(c => c.Id).Where(i => i == id);
                c.Select(c => c.linkedUser.Id).Where(i => userId== i);

                if( c.Count() > 0 )
                {
                    _db.Remove(c.First());
                    await _db.SaveChangesAsync();
                }
                
            }
        }
        public async Task UpdateCandidature(int id, string userId, Candidature updated)
        {
            {
                IQueryable<Candidature> c = _db.Candidatures.Where(c => c.linkedUser.Id == userId);
                c.Select(c => c.Id).Where(i => i == id);
                c.Select(c => c.linkedUser.Id).Where(i => userId == i);
                if (c.Count() > 0)
                {
                    updated.Id = c.First().Id;
                    _db.Update(updated);
                    await _db.SaveChangesAsync();
                }
                
            }
        }
        public async Task<IQueryable<Candidature>> GetCandidatureByUser(string id)
        {
            IQueryable<Candidature> c = _db.Candidatures.Where(c => c.linkedUser.Id == id);
            c.Select(c => c.linkedUser.Id).Where(i => i == id);
            return c;
        }
        public async Task<string> GetPost(string id)
        {
            IQueryable<Candidature> c = await GetCandidatureByUser(id);
            c.Select(c => c.linkedUser.Id).Where(i => i == id);
            List<Entreprise> e = _db.Entreprises.ToList();
            if (c.Count() == 0)
            {
                return "";
            }
            string postAndCity = c.First().PostName + " " + c.First().Entreprise.City;
            return postAndCity;
        }
        public async Task<Candidature> GetCandidatureById(int id, string userId)
        {
            IQueryable<Candidature> c = await this.GetCandidatureByUser(userId);
            c.Select(c => c.Id).Where(i => id == i);
            return c.First();
        }
    }
}

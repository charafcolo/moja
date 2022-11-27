using DAO.DTO;
using DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO.DAO
{
    public class EntrepriseDAO : IEntrepriseDAO
    {
        private readonly ApplicationDbContext _db;
        public EntrepriseDAO(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Delete(int id)
        {
            var entreprise = await _db.Entreprises.FindAsync(id);

            if (entreprise != null)
            {
                _db.Entreprises.Remove(entreprise);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<EntreprisePartialDTO>> GetAll()
        {
            return await _db.Entreprises
            .Select(e => new EntreprisePartialDTO() { Id = e.Id, Nom = e.EntrepriseName })
            .ToListAsync();
        }

        public async Task<Entreprise?> GetById(int id)
        {
            return await _db.Entreprises.FindAsync(id); // plus efficace
        }

        public async Task Create(Entreprise entreprise)
        {
            _db.Add(entreprise);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Entreprise entreprise)
        {
            _db.Update(entreprise);
            await _db.SaveChangesAsync();
        }
    }
}
